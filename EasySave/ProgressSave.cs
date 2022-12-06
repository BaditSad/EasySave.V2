using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Shell;

namespace EasySave
{
    internal class ProgressSave
    {
        public void SavePlay()
        {
            ListSave list = new ListSave();
            foreach (var items in list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv"))
            {
                var lines = File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv");
                File.WriteAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv", lines.Skip(1).ToArray());
                Process[] cname = Process.GetProcessesByName("CalculatorApp");
                if (cname.Length == 0)
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.Arguments = string.Format("/c move {0} {1}", items.Source, items.Target);
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                    }
                }
                else
                {
                    if (Values.Instance.Lang == "en")
                    {
                        MessageBox.Show("Calculator is running. Close it to continue.", "EasySave", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (Values.Instance.Lang == "fr")
                    {
                        MessageBox.Show("Calculatrice est ouvert. Fermé le pour continuer.", "EasySave", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    return;
                }
            }
        }
        public void SavePause()
        {
            Process[] workers = Process.GetProcessesByName("cmd");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
        }
        public bool SaveStop()
        {
            Process[] workers = Process.GetProcessesByName("cmd");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
            if (new FileInfo(Values.Instance.PathConfig + "\\Config\\Save.csv").Length != 0)
            {
                if (Values.Instance.Lang == "en")
                {
                    if (MessageBox.Show("Do you want to close this window ? Save is actually running.", "EasySave", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        SavePlay();
                        return false;
                    }
                }
                else if (Values.Instance.Lang == "fr")
                {
                    if (MessageBox.Show("Voulez - vous fermer la fenêtre ? Une sauvegarde est en cours.", "EasySave", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        SavePlay();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}