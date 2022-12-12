using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace EasySave
{
    public class ServerConnect
    {
        public bool ServerConnectMain()
        {
            return StartServer();
        }

        public static bool StartServer()
        {
            Process process = new Process();
            process.StartInfo.FileName = "EasySaveServer";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            Process[] cname = Process.GetProcessesByName("EasySaveServer");
            if (cname.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
