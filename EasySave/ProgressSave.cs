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
            Process[] cname = Process.GetProcessesByName("calc");
            if (cname.Length == 0)
            {
                //Importation de la list ou creation si on peut pas l'inporter
                //foreach(//Item in list)
                //{
                //    using (Process p = new Process())
                //    {
                //        p.StartInfo.Arguments = string.Format("/C ROBOCOPY {0} {1} {2}",
                //                sourceDirName, destDirName, fileName);
                //        p.StartInfo.FileName = "CMD.EXE";
                //        p.StartInfo.UseShellExecute = false;
                //        p.Start();
                //    }
                //}
            }
            else
            {
                if (Values.Instance.Lang == "en")
                {
                    MessageBox.Show("Calculator is running. Close it to continue.");
                }
                if (Values.Instance.Lang == "fr")
                {
                    MessageBox.Show("Calculatrice est ouvert. Fermé le pour continuer.");
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
