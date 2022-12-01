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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour Config.xaml
    /// </summary>
    public partial class Config_en : Window
    {
        public Config_en()
        {
            InitializeComponent();
            TextBoxPathTargetEn.Text = Values.Instance.PathTarget;
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
        private void DefaultTargetPath(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TextBoxPathTargetEn.Text = dialog.FileName;
                this.Topmost = true;
            }
        }
        private void ResetLog(object sender, RoutedEventArgs e)
        {
            Reset method = new Reset();
            method.Log();
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            Values.Instance.PathTarget = TextBoxPathTargetEn.Text;
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
