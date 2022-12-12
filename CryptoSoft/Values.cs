using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSoft
{
    internal class Values
    {
        public string EasySavePath
        {
            get; set;
        }
        public string Lang
        {
            get; set;
        }
        public string ExtValues
        {
            get; set;
        }
        public string PathToCrypt
        {
            get; set;
        }
        private Values() { }
        public static readonly Values Instance = new Values();
    }
}
