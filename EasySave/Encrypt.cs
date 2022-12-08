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
    internal class Encrypt
    {
        public void encryptFolder(string path)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"";
            process.StartInfo.Arguments = path;
            process.Start();
        }
    }
}
