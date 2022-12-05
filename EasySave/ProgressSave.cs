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

namespace EasySave
{
    internal class ProgressSave
    {
        public void SavePlay()
        {
            ListSave list = new ListSave();
            foreach (var items in list.LoadDataGridView(Values.Instance.PathConfig + "\\Config\\Save.csv"))
            {
                Process[] cname = Process.GetProcessesByName("calc"); //ATTENTION LE NOM EST PAS BON
                if (cname.Length == 0)
                {
                    //Nothing
                }
                else
                {
                    if (Values.Instance.Lang == "en")
                    {
                        MessageBox.Show("Calculator is running. Close it to continue.");
                    }
                    else if (Values.Instance.Lang == "fr")
                    {
                        MessageBox.Show("Calculatrice est ouvert. Fermé le pour continuer.");
                    }
                    return;
                }
                using (Process process = new Process())
                {
                    process.StartInfo.Arguments = string.Format("/c move {0} {1}", items.Source, items.Target);
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                }
            }
        }
        public void SavePause()
        {
            
        }
        public void SaveStop()
        {

        }
    }
}
