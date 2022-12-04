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
    internal class Detection_ext
    {
        // Detection if the extention exists
        string[] extentions = Values.Instance.ext;
        List<string> fileList = new List<string>();
        
        public List<string> Detection(string[] fileNames)
        {
            for (int i = 0; i < fileNames.Length; i++)
            {
                for (int j = 0; j < extentions.Length; j++)
                {
                    if (fileNames[i].IndexOf(extentions[j]) > 0)
                    {
                        fileList.Add(fileNames[i]);
                        break;
                    }
                }
            }
            return fileList;
        }
    }
}
