using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour CreateSave.xaml
    /// </summary>
    public partial class Save_fr : Window
    {
        public Save_fr()
        {
            InitializeComponent();
            dgvData.ItemsSource = LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void WindowsBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Check save = new Check();
            save.SaveCheck();
            this.Close();
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_en window = new MainWindow_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void French_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            Save_en window = new Save_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_en window = new Config_en();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }

        private void LaunchSave(object sender, RoutedEventArgs e)
        {
            CreateSave save = new CreateSave();
            save.LaunchSave();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var line_to_edit = dgvData.SelectedIndex;
            string newText = ";;";
            string fileName = Values.Instance.PathConfig + "\\Config\\Save.csv";
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
            dgvData.ItemsSource = LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            CreateSave_en window = new CreateSave_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        public class SaveLineDataGridView
        {
            public string Date
            {
                get; set;
            }
            public string Source
            {
                get; set;
            }
            public string Target
            {
                get; set;
            }
        }
        public List<SaveLineDataGridView> LoadDataGridView(string csvFile)
        {
            var query = from l in File.ReadLines(csvFile)
                        let data = l.Split(';')
                        select new SaveLineDataGridView
                        {
                            Source = data[0],
                            Target = data[1],
                            Date = data[2]
                        };
            return query.ToList();
        }
    }
}
