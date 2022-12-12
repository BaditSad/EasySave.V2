using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class Values
    {
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
        public string FileExt
        {
            get; set;
        }
        public bool Connected
        {
            get; set;
        }
        private Values() { }
        public static readonly Values Instance = new Values();
    }
}
