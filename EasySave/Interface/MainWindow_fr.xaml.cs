using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace EasySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow_fr : Window
    {
        public MainWindow_fr()
        {
            InitializeComponent();
            if (new FileInfo(Values.Instance.PathConfig + "\\Dailylog\\Log.json").Length == 0)
            {
                ShowSaveButton.IsEnabled = false;
                ShowSaveButton.Opacity = 0.3;
            }
            if (new FileInfo(Values.Instance.PathConfig + "\\Dailylog\\Log.json").Length != 0)
            {
                ShowSaveButton.IsEnabled = true;
                ShowSaveButton.Opacity = 1;
            }
            Process[] pname = Process.GetProcessesByName("EasySaveServer");
            if (pname.Length > 0)
            {
                MessageBox.Show("true");
                Values.Instance.Connected = true;
            }
            if (pname.Length == 0)
            {
                MessageBox.Show("true");
                Values.Instance.Connected = false;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void WindowsBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateSave_fr window = new CreateSave_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ShowSave_fr window = new ShowSave_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
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

        private void French_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_en window = new MainWindow_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_fr window = new Config_fr();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Info_fr window = new Info_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }

        private void Crypt_Click(object sender, RoutedEventArgs e)
        {
            Crypt_fr window = new Crypt_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            Decrypt_fr window = new Decrypt_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void ConnectOff_Click(object sender, RoutedEventArgs e)
        {
            ServerConnect connect = new ServerConnect();
            if (connect.ServerConnectMain() == true)
            {
                Values.Instance.Connected = true;
            }
        }
    }
}
