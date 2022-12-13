using System.Diagnostics;
using System.IO;
using System.Windows.Documents;
using System.Windows;
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
using System.Collections;

namespace EasySave
{
    internal class ProgressSave
    {
        public void AddLog(string source, string target, int start, int stop)
        {
            int Id = File.ReadAllLines(Values.Instance.PathConfig + "\\Dailylog\\Log.json").Count();
            StreamWriter log_json = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.json", true);
            log_json.Write("\nID : " + Id + " | Time : " + Math.Abs(stop - start) + "ms | " + source + " => " + target);
            log_json.Close();
            StreamWriter log_xml = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.xml", true);
            log_xml.Write("\nID : " + Id + " | Time : " + Math.Abs(stop - start) + "ms | " + source + " => " + target);
            log_xml.Close();
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
            StreamWriter log_xml = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
            log_xml.Write("\nINTERUPTION");
            log_xml.Close();
        }
        public bool SaveStop()
        {
            Process[] workers = Process.GetProcessesByName("cmd");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
                StreamWriter log_xml = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
                log_xml.Write("\nINTERUPTION");
                log_xml.Close();
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
                        StreamWriter log_xml = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
                        log_xml.Write("\nCONTINUE");
                        log_xml.Close();
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
                        StreamWriter log_xml = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
                        log_xml.Write("\nCONTINUE");
                        log_xml.Close();
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