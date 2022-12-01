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
            TextBoxPathTargetFr.Text = Values.Instance.PathTarget;
            if (Values.Instance.FileExt == ".json")
            {
                ComboBox.SelectedIndex = 0;
            }
            else if (Values.Instance.FileExt == ".xml")
            {
                ComboBox.SelectedIndex = 1;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void TextBoxPathTargetFr_TextChanged(object sender, EventArgs e)
        {
            Values.Instance.PathTarget = TextBoxPathTargetFr.Text;
        }
        private void DefaultTargetPath(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            dialog.FileName = "Folder Selection.";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Values.Instance.PathTarget = dialog.FileName;
                TextBoxPathTargetFr.Text = Values.Instance.PathTarget;
            }
        }
        private void ResetLog(object sender, RoutedEventArgs e)
        {
            Reset method = new Reset();
            method.Log();
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            Values.Instance.PathTarget = TextBoxPathTargetFr.Text;
            Values.Instance.FileExt = ComboBox.Text;
            Check save = new Check();
            save.SaveCheck();
            this.Close();
        }
        private void DragConfigMenu(object sender, MouseEventArgs e)
        {
            this.DragMove();
        }
    }
}
