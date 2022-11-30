using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class Check
    {
        public void ChekFolder()
        {
            Values.Instance.PathConfig = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Values.Instance.PathConfig + "\\Config"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\Config");
                Values.Instance.PathTarget = Values.Instance.PathConfig;
                StreamWriter path = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Path.json");
                path.WriteLine(Values.Instance.PathTarget);
                path.Close();
                Values.Instance.Lang = "en";
                StreamWriter lang = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Lang.json");
                lang.WriteLine(Values.Instance.Lang);
                lang.Close();
            }
            else if (Directory.Exists(Values.Instance.PathConfig + "\\Config"))
            {
                StreamReader lang = new StreamReader(Values.Instance.PathConfig + "\\Config\\Lang.json");
                Values.Instance.Lang = lang.ReadLine();
                lang.Close();
            }
            if (!Directory.Exists(Values.Instance.PathConfig + "\\Dailylog"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\Dailylog");
                File.Create(Values.Instance.PathConfig + "\\Dailylog\\Log.json");
            }
            if (!Directory.Exists(Values.Instance.PathConfig + "\\Statelog"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\Statelog");
                File.Create(Values.Instance.PathConfig + "\\Statelog\\Statelog.json");
            }
        }
    }
}
