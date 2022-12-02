using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class Values
    {
        public readonly string[] ext = new string[]
        { ".json", ".xml", ".doc", ".docx", ".css", ".html", ".js", ".php" };

        public string SecretKey //secretKey for encryption
        {
            get; set;
        }

        public string Lang //Language
        {
            get; set;
        }
        public string PathConfig //Config path folder
        {
            get; set;
        }
        public string PathTarget //Target path folder
        {
            get; set;
        }
        public string FileExt //Target path folder
        {
            get; set;
        }
        private Values() { }
        public static readonly Values Instance = new Values();
    }
}
