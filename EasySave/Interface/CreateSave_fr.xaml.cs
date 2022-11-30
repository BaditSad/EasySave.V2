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
using System.Windows.Shapes;

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour CreateSave.xaml
    /// </summary>
    public partial class CreateSave_fr : Window
    {
        public CreateSave_fr()
        {
            InitializeComponent();
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
            this.Close();
            window.Show();
        }
        private void French_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            CreateSave_en window = new CreateSave_en();
            window.Top = this.Top;
            window.Left = this.Left;
            this.Close();
            window.Show();
        }
        private void SourceFolderFiles(object sender, RoutedEventArgs e)
        {

        }
        private void TargetFolderFiles(object sender, RoutedEventArgs e)
        {

        }
        private void SaveFiles(object sender, RoutedEventArgs e)
        {

        }
        private void ClearFiles(object sender, RoutedEventArgs e)
        {

        }
        private void SourceFolderFile(object sender, RoutedEventArgs e)
        {

        }
        private void TargetFolderFile(object sender, RoutedEventArgs e)
        {

        }
        private void SaveFile(object sender, RoutedEventArgs e)
        {

        }
        private void ClearFile(object sender, RoutedEventArgs e)
        {

        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_fr window = new Config_fr();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }
    }
}
