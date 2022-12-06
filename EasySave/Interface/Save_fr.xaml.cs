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
            Values.Instance.FileToSave = 0;
            ListSave list = new ListSave();
            dgvData.ItemsSource = list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv");
            DeleteButton.IsEnabled = false;
            DeleteButton.Opacity = 0.3;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void CellsChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteButton.IsEnabled = true;
            DeleteButton.Opacity = 1;
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
            Values.Instance.FileToSave = File.ReadLines(Values.Instance.PathConfig + "\\Config\\Save.csv").Count();
            ProgressBar_fr window = new ProgressBar_fr();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var line_to_edit = dgvData.SelectedIndex;
            string newText = ";;";
            string fileName = Values.Instance.PathConfig + "\\Config\\Save.csv";
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
            ListSave list = new ListSave();
            dgvData.ItemsSource = list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv");
            if (dgvData.Items.Count == 0)
            {
                DeleteButton.IsEnabled = false;
                DeleteButton.Opacity = 0.3;
                SaveButton.IsEnabled = false;
                SaveButton.Opacity = 0.3;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            CreateSave_en window = new CreateSave_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
    }
}
