using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave
{
    internal class CreateSave
    {
        public void SaveFiles(string _sourcePath, string _targetPath)
        {
            if (Directory.Exists(_targetPath))
            {
                if (Directory.Exists(_sourcePath))
                {
                    foreach (string pathFile in Directory.GetFiles(_sourcePath))
                    {
                        using (StreamWriter file = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Save.csv", true))
                        {
                            file.WriteLine(_sourcePath + ";" + _targetPath + ";" + DateTime.Now);
                        }
                    }
                }
                else if (File.Exists(_sourcePath))
                {
                    using (StreamWriter file = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Save.csv", true))
                    {
                        file.WriteLine(_sourcePath + ";" + _targetPath + ";" + DateTime.Now);
                    }
                }
                else
                {
                    if (Values.Instance.Lang == "en")
                    {
                        MessageBox.Show("Source path invalid.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (Values.Instance.Lang == "fr")
                    {
                        MessageBox.Show("Chemin source invalide.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                if (Values.Instance.Lang == "en")
                {
                    MessageBox.Show("Target path invalid.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Values.Instance.Lang == "fr")
                {
                    MessageBox.Show("Chemin cible invalide.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        public void LaunchSave()
        {
            
        }
    }
}
