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
using System.Net.Sockets;

namespace EasySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow_en : Window
    {
        public MainWindow_en()
        {
            Process[] cname = Process.GetProcessesByName("EasySave");
            if (cname.Length != 0)
            {
                this.Close();
            }

            ServerConnect server = new ServerConnect();
            server.AccepterConnexionAsync(server.SeConnecter());
            server.EcouterReseau(server.SeConnecter());
            server.Deconnecter(server.SeConnecter());

            Check method = new Check();
            method.ChekFolder();
            if (Values.Instance.Lang == "en")
            {
                InitializeComponent();
                if (new FileInfo(Values.Instance.PathConfig + "\\Dailylog\\Log.json").Length == 0)
                {
                    ShowSaveButton.IsEnabled = false;
                    ShowSaveButton.Opacity = 0.3;
                }
                else
                {
                    ShowSaveButton.IsEnabled = true;
                    ShowSaveButton.Opacity = 1;
                }
            }
            else if (Values.Instance.Lang == "fr")
            { 
                MainWindow_fr window = new MainWindow_fr();
                window.Top = this.Top;
                window.Left = this.Left;
                window.Show();
                this.Close();
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
            CreateSave_en window = new CreateSave_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ShowSave_en window = new ShowSave_en();
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
            MainWindow_fr window = new MainWindow_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_en window = new Config_en();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Info_en window = new Info_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void Crypt_Click(object sender, RoutedEventArgs e)
        {
            Crypt_en window = new Crypt_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            Decrypt_en window = new Decrypt_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
    }
}
