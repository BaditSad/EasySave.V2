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
                        StreamReader ReadSaveList = new StreamReader(Values.Instance.PathConfig + "\\Config\\Save.json");
                        Values.Instance.Save = ReadSaveList.ReadToEnd();
                        ReadSaveList.Close();
                        StreamWriter WriteSaveList = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Save.json");
                        WriteSaveList.Write(Values.Instance.Save);
                        WriteSaveList.WriteLine("\"" + pathFile + " --> " + _targetPath + "\": {");//id
                        WriteSaveList.WriteLine("\"date\": \"" + DateTime.Now + "\",");//date
                        WriteSaveList.WriteLine("\"source\": \"" + pathFile + "\",");//source
                        WriteSaveList.WriteLine("\"target\": \"" + _targetPath + "\"");//target
                        WriteSaveList.WriteLine("}, {");
                        WriteSaveList.Close();
                    }
                }
                else if (File.Exists(_sourcePath))
                {
                    StreamReader ReadSaveList = new StreamReader(Values.Instance.PathConfig + "\\Config\\Save.json");
                    Values.Instance.Save = ReadSaveList.ReadToEnd();
                    ReadSaveList.Close();
                    StreamWriter WriteSaveList = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Save.json");
                    WriteSaveList.Write(Values.Instance.Save);
                    WriteSaveList.WriteLine("\"" + _sourcePath + " --> " + _targetPath + "\": {");//id
                    WriteSaveList.WriteLine("\"date\": \"" + DateTime.Now + "\",");//date
                    WriteSaveList.WriteLine("\"source\": \"" + _sourcePath + "\",");//source
                    WriteSaveList.WriteLine("\"target\": \"" + _targetPath + "\"");//target
                    WriteSaveList.WriteLine("}, {");
                    WriteSaveList.Close();
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
