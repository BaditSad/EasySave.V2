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
            //Create folders
            Values.Instance.PathConfig = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Values.Instance.PathConfig + "\\Config"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\Config");
                Values.Instance.PathTarget = Values.Instance.PathConfig;
            }
            if (!Directory.Exists(Values.Instance.PathConfig + "\\Dailylog"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\Dailylog");
            }
            if (!Directory.Exists(Values.Instance.PathConfig + "\\Statelog"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\Statelog");
            }
            if (!Directory.Exists(Values.Instance.PathConfig + "\\CryptoSoft"))
            {
                Directory.CreateDirectory(Values.Instance.PathConfig + "\\CryptoSoft");
            }
            //Create files
            if (!File.Exists(Values.Instance.PathConfig + "\\CryptoSoft\\Ext.json"))
            {
                StreamWriter crypt = new StreamWriter(Values.Instance.PathConfig + "\\CryptoSoft\\Ext.json");
                crypt.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Config\\Save.csv"))
            {
                StreamWriter save = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Save.csv");
                save.Close();
            }
            if(!File.Exists(Values.Instance.PathConfig + "\\Dailylog\\Log.json"))
            {
                StreamWriter log = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.json");
                log.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Dailylog\\Log.xml"))
            {
                StreamWriter log = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log.xml");
                log.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Statelog\\Statelog.json"))
            {
                StreamWriter state = new StreamWriter(Values.Instance.PathConfig + "\\Statelog\\Statelog.json");
                state.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Config\\Path.json"))
            {
                StreamWriter path = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Path.json");
                path.WriteLine(Values.Instance.PathTarget);
                path.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Config\\Lang.json"))
            {
                Values.Instance.Lang = "en";
                StreamWriter lang = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Lang.json");
                lang.WriteLine(Values.Instance.Lang);
                lang.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Config\\Ext.json"))
            {
                StreamWriter ext = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Ext.json");
                ext.Close();
            }
            if (!File.Exists(Values.Instance.PathConfig + "\\Config\\File.json"))
            {
                Values.Instance.FileExt = ".json";
                StreamWriter file = new StreamWriter(Values.Instance.PathConfig + "\\Config\\File.json");
                file.WriteLine(Values.Instance.FileExt);
                file.Close();
            }
            //Reader files
            if (File.Exists(Values.Instance.PathConfig + "\\Config\\Lang.json"))
            {
                StreamReader lang = new StreamReader(Values.Instance.PathConfig + "\\Config\\Lang.json");
                Values.Instance.Lang = lang.ReadLine();
                lang.Close();
            }
            if (File.Exists(Values.Instance.PathConfig + "\\Config\\Path.json"))
            {
                StreamReader path = new StreamReader(Values.Instance.PathConfig + "\\Config\\Path.json");
                Values.Instance.PathTarget = path.ReadLine();
                path.Close();
            }
            if (File.Exists(Values.Instance.PathConfig + "\\Config\\File.json"))
            {
                StreamReader file = new StreamReader(Values.Instance.PathConfig + "\\Config\\File.json");
                Values.Instance.FileExt = file.ReadLine();
                file.Close();
            }
        }
        public void SaveCheck()
        {
            StreamWriter path = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Path.json");
            path.WriteLine(Values.Instance.PathTarget);
            path.Close();
            StreamWriter lang = new StreamWriter(Values.Instance.PathConfig + "\\Config\\Lang.json");
            lang.WriteLine(Values.Instance.Lang);
            lang.Close();
            StreamWriter file = new StreamWriter(Values.Instance.PathConfig + "\\Config\\File.json");
            file.WriteLine(Values.Instance.FileExt);
            file.Close();
        }
    }
}
