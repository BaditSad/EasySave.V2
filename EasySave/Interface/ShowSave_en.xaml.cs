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
    public partial class ShowSave_en : Window
    {
        public ShowSave_en()
        {
            InitializeComponent();
            if (Values.Instance.FileExt == ".json")
            {
                StreamReader log = new StreamReader(Values.Instance.PathConfig + "\\Dailylog\\Log.json");
                Log.Text = log.ReadToEnd();
                log.Close();
            }
            else if (Values.Instance.FileExt == ".xml")
            {
                StreamReader log = new StreamReader(Values.Instance.PathConfig + "\\Dailylog\\Log.xml");
                Log.Text = log.ReadToEnd();
                log.Close();
            }
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
            this.Close();
            window.Show();
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void French_Click(object sender, RoutedEventArgs e)
        {
            ShowSave_fr window = new ShowSave_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            this.Close();
            window.Show();
        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_en window = new Config_en();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }
    }
}
