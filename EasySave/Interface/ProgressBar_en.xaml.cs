using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar_en : Window
    {
        int IdFiledSaved = 1;
        int NumberOfLines = File.ReadLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count();
        public ProgressBar_en()
        {
            InitializeComponent();
            pbStatusEn.Minimum = 0;
            pbStatusEn.Maximum = 100;
            PauseButton.IsEnabled = false;
            PauseButton.Opacity = 0.3;
            PlayButton.IsEnabled = true;
            PlayButton.Opacity = 1;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void WindowsBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private delegate void EmptyDelegate();
        protected void DoEvents()
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new EmptyDelegate(delegate { }));
        }
        public void Button_play(object sender, RoutedEventArgs e)
        {
            PlayButton.IsEnabled = false;
            PlayButton.Opacity = 0.3;
            PauseButton.IsEnabled = true;
            PauseButton.Opacity = 1;
            ListSave list = new ListSave();
            foreach (var items in list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv"))
            {
                string FileSaved = File.ReadLines(Values.Instance.PathConfig + "\\Config\\Save.csv").First();
                var lines = File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv");
                File.WriteAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv", lines.Skip(1).ToArray());
                Process[] cname = Process.GetProcessesByName("CalculatorApp");
                if (cname.Length == 0)
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.Arguments = string.Format("/c move {0} {1}", items.Source, items.Target);
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                        if (Ressources.Text == "")
                        {
                            pbStatusEn.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                            Ressources.Text = IdFiledSaved + " - " + FileSaved + "\n";
                            IdFiledSaved++;
                            Thread.Sleep(300);
                            DoEvents();
                        }
                        else
                        {
                            pbStatusEn.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                            Ressources.Text = Ressources.Text + "\n" + IdFiledSaved + " - " + FileSaved + "\n";
                            IdFiledSaved++;
                            Thread.Sleep(300);
                            DoEvents();
                        }
                    }
                }
                else
                {
                    if (Values.Instance.Lang == "en")
                    {
                        MessageBox.Show("Calculator is running. Close it to continue.", "EasySave", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (Values.Instance.Lang == "fr")
                    {
                        MessageBox.Show("Calculatrice est ouvert. Fermé le pour continuer.", "EasySave", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            PlayButton.IsEnabled = false;
            PlayButton.Opacity = 0.3;
            PauseButton.IsEnabled = false;
            PauseButton.Opacity = 0.3;
        }

        private void Button_pause(object sender, RoutedEventArgs e)
        {
            ProgressSave progress = new ProgressSave();
            progress.SavePause();
            PauseButton.IsEnabled = false;
            PauseButton.Opacity = 0.3;
            PlayButton.IsEnabled = true;
            PlayButton.Opacity = 1;
        }

        public void Button_stop(object sender, RoutedEventArgs e)
        {
            ProgressSave progress = new ProgressSave();
            if (progress.SaveStop() == true)
            {
                CreateSave_en save = new CreateSave_en();
                save.Top = this.Top - 100;
                save.Left = this.Left - 250;
                save.Show();
                this.Close();
            }
            else
            {
                PlayButton.IsEnabled = false;
                PlayButton.Opacity = 0.3;
                PauseButton.IsEnabled = true;
                PauseButton.Opacity = 1;
                ListSave list = new ListSave();
                foreach (var items in list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv"))
                {
                    string FileSaved = File.ReadLines(Values.Instance.PathConfig + "\\Config\\Save.csv").First();
                    var lines = File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv");
                    File.WriteAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv", lines.Skip(1).ToArray());
                    Process[] cname = Process.GetProcessesByName("CalculatorApp");
                    if (cname.Length == 0)
                    {
                        using (Process process = new Process())
                        {
                            process.StartInfo.Arguments = string.Format("/c move {0} {1}", items.Source, items.Target);
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.CreateNoWindow = true;
                            process.Start();
                            if (Ressources.Text == "")
                            {
                                pbStatusEn.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                                Ressources.Text = IdFiledSaved + " - " + FileSaved + "\n";
                                IdFiledSaved++;
                                Thread.Sleep(300);
                                DoEvents();
                            }
                            else
                            {
                                pbStatusEn.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                                Ressources.Text = Ressources.Text + "\n" + IdFiledSaved + " - " + FileSaved + "\n";
                                IdFiledSaved++;
                                Thread.Sleep(300);
                                DoEvents();
                            }
                        }
                    }
                    else
                    {
                        if (Values.Instance.Lang == "en")
                        {
                            MessageBox.Show("Calculator is running. Close it to continue.", "EasySave", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        else if (Values.Instance.Lang == "fr")
                        {
                            MessageBox.Show("Calculatrice est ouvert. Fermé le pour continuer.", "EasySave", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
                PlayButton.IsEnabled = false;
                PlayButton.Opacity = 0.3;
                PauseButton.IsEnabled = false;
                PauseButton.Opacity = 0.3;
            }
        }
    }
}
