﻿using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
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
            TargetFiles.Text = Values.Instance.PathTarget;
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
        private void French_Click(object sender, RoutedEventArgs e)
        {
            //Nothing
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            CreateSave_en window = new CreateSave_en();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
        private void SourceFolderFiles(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SourceFiles.Text = dialog.FileName;
                this.Topmost = true;
            }
        }
        private void TargetFolderFiles(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TargetFiles.Text = dialog.FileName;
                this.Topmost = true;
            }
        }
        private void ListSaveFiles(object sender, RoutedEventArgs e)
        {
            if (SourceFile.Text == "" & SourceFiles.Text == "")
            {
                MessageBox.Show("Source file needed.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (SourceFile.Text != "" & SourceFiles.Text != "")
            {
                MessageBox.Show("Complete only one source path.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                SourceFiles.Text = "";
                SourceFile.Text = "";
            }
            else if (SourceFile.Text == "" & SourceFiles.Text != "")
            {
                CreateSave save = new CreateSave();
                save.SaveFiles(SourceFiles.Text, TargetFiles.Text);
                SourceFiles.Text = "";
                SourceFile.Text = "";
            }
            else if (SourceFile.Text != "" & SourceFiles.Text == "")
            {
                CreateSave save = new CreateSave();
                save.SaveFiles(SourceFile.Text, TargetFiles.Text);
                SourceFiles.Text = "";
                SourceFile.Text = "";
            }
        }
        private void ClearFiles(object sender, RoutedEventArgs e)
        {
            SourceFiles.Text = "";
            SourceFile.Text = "";
        }
        private void SourceFolderFile(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SourceFile.Text = dialog.FileName;
                this.Topmost = true;
            }
        }
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            Config_en window = new Config_en();
            window.Top = this.Top + 100;
            window.Left = this.Left + 250;
            window.Show();
        }

        private void CreateSave(object sender, RoutedEventArgs e)
        {
            Save_fr window = new Save_fr();
            window.Top = this.Top;
            window.Left = this.Left;
            window.Show();
            this.Close();
        }
    }
}
