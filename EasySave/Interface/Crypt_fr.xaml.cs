using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour ShowSave.xaml
    /// </summary>
    public partial class Crypt_fr : Window
    {
        public Crypt_fr()
        {
            InitializeComponent();
            TextBox.Text = Values.Instance.PathTarget;
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
            MainWindow_fr window = new MainWindow_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter lang = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Lang.json");
            lang.WriteLine("en");
            lang.Close();
            Crypt_en window = new Crypt_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void French_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_fr window = new Config_fr();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }

        private void OpenExt(object sender, RoutedEventArgs e)
        {
            OpenExtFile open = new OpenExtFile();
            open.OpenFile();
        }

        private void CryptFolderFiles(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TextBox.Text = dialog.FileName;
                this.Topmost = true;
            }
        }

        private void Crypt_Click(object sender, RoutedEventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            encrypt.encryptFolder(TextBox.Text);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "";
        }
    }
}
