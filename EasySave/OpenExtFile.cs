using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class OpenExtFile
    {
        public void OpenFile()
        {
            Process.Start(Values.Instance.PathConfig + "\\Config\\Ext.json");
        }
    }
}
