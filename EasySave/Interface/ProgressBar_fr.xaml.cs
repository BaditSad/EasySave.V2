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
    /// Logique d'interaction pour ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar_fr : Window
    {
        public ProgressBar_fr()
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

        private void Button_play(object sender, RoutedEventArgs e)
        {

        }

        private void Button_pause(object sender, RoutedEventArgs e)
        {

        }

        private void Button_stop(object sender, RoutedEventArgs e)
        {

        }
    }
}
