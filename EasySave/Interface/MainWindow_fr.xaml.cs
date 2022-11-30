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
            this.Close();
            window.Show();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ShowSave_fr window = new ShowSave_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            this.Close();
            window.Show();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
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
            this.Close();
            window.Show();
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
            this.Close();
            window.Show();
        }
    }
}
