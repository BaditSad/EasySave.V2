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
    public partial class CreateSave : Window
    {
        public CreateSave()
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

        }

        private void French_Click(object sender, RoutedEventArgs e)
        {

        }

        private void English_Click(object sender, RoutedEventArgs e)
        {

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

        }
    }
}
