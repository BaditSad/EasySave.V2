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
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar_fr : Window
    {
        int IdFiledSaved = 1;
        int NumberOfLines = File.ReadLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count();
        public ProgressBar_fr()
        {
            InitializeComponent();
            pbStatusFr.Minimum = 0;
            pbStatusFr.Maximum = 100;
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
            int start = DateTime.Now.Millisecond;
            ListSave list = new ListSave();
            foreach (var items in list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv"))
            {
                int startW = DateTime.Now.Millisecond;
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
                            pbStatusFr.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                            Ressources.Text = IdFiledSaved + " - " + FileSaved + "\n";
                            IdFiledSaved++;
                            int stopW = DateTime.Now.Millisecond;
                            ProgressSave log = new ProgressSave();
                            log.AddLog(items.Source, items.Target, startW, stopW);
                            Thread.Sleep(300);
                            DoEvents();
                        }
                        else
                        {
                            pbStatusFr.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                            Ressources.Text = Ressources.Text + "\n" + IdFiledSaved + " - " + FileSaved + "\n";
                            IdFiledSaved++;
                            int stopW = DateTime.Now.Millisecond;
                            ProgressSave log = new ProgressSave();
                            log.AddLog(items.Source, items.Target, startW, stopW);
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
            int stop = DateTime.Now.Millisecond;
            int Id = File.ReadAllLines(Values.Instance.PathConfig + "\\Statelog\\Statelog.json").Count();
            StreamWriter log_json = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
            log_json.Write("\nSAVE ID : " + Id + " | DATE : " + DateTime.Now + " | TIME : " + (stop - start) + " | STATE : Done");
            log_json.Close();
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
                CreateSave_fr save = new CreateSave_fr();
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
                int start = DateTime.Now.Millisecond;
                ListSave list = new ListSave();
                foreach (var items in list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv"))
                {
                    int startW = DateTime.Now.Millisecond;
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
                                pbStatusFr.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                                Ressources.Text = IdFiledSaved + " - " + FileSaved + "\n";
                                IdFiledSaved++;
                                int stopW = DateTime.Now.Millisecond;
                                ProgressSave log = new ProgressSave();
                                log.AddLog(items.Source, items.Target, startW, stopW);
                                Thread.Sleep(300);
                                DoEvents();
                            }
                            else
                            {
                                pbStatusFr.Value = (((NumberOfLines - File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count()) * 100) / NumberOfLines);
                                Ressources.Text = Ressources.Text + "\n" + IdFiledSaved + " - " + FileSaved + "\n";
                                IdFiledSaved++;
                                int stopW = DateTime.Now.Millisecond;
                                ProgressSave log = new ProgressSave();
                                log.AddLog(items.Source, items.Target, startW, stopW);
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
                int stop = DateTime.Now.Millisecond;
                int Id = File.ReadAllLines(Values.Instance.PathConfig + "\\Statelog\\Statelog.json").Count();
                StreamWriter log_json = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
                log_json.Write("\nSAVE ID : " + Id + " | DATE : " + DateTime.Now + " | TIME : " + (stop - start) + " | STATE : Done");
                log_json.Close();
                PlayButton.IsEnabled = false;
                PlayButton.Opacity = 0.3;
                PauseButton.IsEnabled = false;
                PauseButton.Opacity = 0.3;
            }
        }
    }
}
