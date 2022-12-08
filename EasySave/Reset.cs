using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave
{
    internal class Reset
    {
        public void Log()
        {
            string dataLog;
            StreamReader readLog = new StreamReader(Values.Instance.PathConfig + "\\Dailylog\\Log.json");
            dataLog = readLog.ReadToEnd();
            readLog.Close();
            if (dataLog == "")
            {
                if (Values.Instance.Lang == "en")
                {
                    if (MessageBox.Show("Reset log ?", "Save file", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        StreamWriter json = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.json", true);
                        json.WriteLine("");
                        json.Close();
                        StreamWriter xml = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.xml", true);
                        xml.WriteLine("");
                        xml.Close();
                        StreamWriter log_json = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
                        log_json.WriteLine("");
                        log_json.Close();
                    }
                }
                else if (Values.Instance.Lang == "fr")
                {
                    if (MessageBox.Show("Reset logs ?", "Save file", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        StreamWriter json = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.json", true);
                        json.WriteLine("");
                        json.Close();
                        StreamWriter xml = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.xml", true);
                        xml.WriteLine("");
                        xml.Close();
                        StreamWriter log_json = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json", true);
                        log_json.WriteLine("");
                        log_json.Close();
                    }
                }
            }
            else
            {
                if (Values.Instance.Lang == "en")
                {
                    MessageBox.Show("Log already clean.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (Values.Instance.Lang == "fr")
                {
                    MessageBox.Show("Logs déjà supprimé.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
