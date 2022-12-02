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
    internal class ShowSaves
    {
        public static string Show_Saves()
        {
            if (Values.Instance.FileExt == ".json")
            {
                StreamReader log = new StreamReader(Values.Instance.PathConfig + "\\Dailylog\\Log.json");
                string Log = log.ReadToEnd();
                log.Close();
                return Log;
            }
            else if (Values.Instance.FileExt == ".xml")
            {
                StreamReader log = new StreamReader(Values.Instance.PathConfig + "\\Dailylog\\Log.xml");
                string Log = log.ReadToEnd();
                log.Close();
                return Log;
            }
            else
            {
                return "";
            }
        }
    }
}
