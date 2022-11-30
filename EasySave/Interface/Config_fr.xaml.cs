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
    /// Logique d'interaction pour Config.xaml
    /// </summary>
    public partial class Config_fr : Window
    {
        public Config_fr()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void DefaultTargetPath(object sender, RoutedEventArgs e)
        {

        }

        private void OpenExt(object sender, RoutedEventArgs e)
        {

        }

        private void ResetLog(object sender, RoutedEventArgs e)
        {

        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DragConfigMenu(object sender, MouseEventArgs e)
        {
            this.DragMove();
        }
    }
}
