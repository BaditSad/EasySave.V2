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
    internal class Reset
    {
        public void Log()
        {
            if (File.Exists(Values.Instance.PathConfig + "\\Dailylog\\Log.json"))
            {
                if (MessageBox.Show("Reset EasySave ?", "Save file", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Delete(Values.Instance.PathConfig + "\\Dailylog\\Log.json");
                }
            }
            else
            {
                if (Values.Instance.Lang == "en")
                {
                    MessageBox.Show("EasySave already reset.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (Values.Instance.Lang == "fr")
                {
                    MessageBox.Show("Easy Save déjà réinitialisé.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
