using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
        private long startTime = 0;
        private long endTime = 0;
        private long encryptTime = 0;
        private string folderPath = "";
        private string defaultKey = "";
        private string secretKey = "";
        private string encryptOk = "";
        private string encryptMes = "";
        private string format = "";
        private List<string> fileList = new List<string>();

        public void Encrypt_En()
        {
            string[] fileNames = Directory.GetFiles(folderPath);

            Detection_ext det = new Detection_ext();
            fileList = det.Detection(fileNames);

            for (int i = 0; i < fileList.Count; i++)
            {
                startTime = DateTime.Now.Millisecond;
                string content = File.ReadAllText(fileList[i]);
                char[] data = content.ToCharArray();
                char[] key = secretKey.ToCharArray();

                for (int j = 0; j < data.Length; j++)
                {
                    data[j] ^= key[j % key.Length];
                }

                File.Delete(fileList[i]);
                StreamWriter writer = new StreamWriter(fileList[i]);
                writer.Write(data);
                writer.Close();
                endTime = DateTime.Now.Millisecond;
                encryptTime = endTime - startTime;

                if (encryptTime >= 0)
                {
                    if (encryptTime == 0)
                    {
                        encryptTime += 1;
                    }
                    Console.Clear();
                    Console.WriteLine("\r\n- Done -");
                    encryptMes = "<Encryption> (Time used: " + encryptTime + " ms / Status: successful" + ") (" + DateTime.Now + ") : " + fileList[i] + " --> " + fileList[i];
                }
                else if (encryptTime < 0)
                {
                    Console.Clear();
                    Console.WriteLine("\r\n- Error -");
                    encryptMes = "<Encryption> (Time used: " + encryptTime + " ms / Status: failure" + ") (" + DateTime.Now + ") : " + fileList[i] + " --> " + fileList[i];
                }
                StreamWriter Encryptlog = new StreamWriter(Values.Instance.PathConfig + "\\Dailylog\\Log" + format, true);
                Encryptlog.WriteLine(encryptMes);
                Encryptlog.Close();
            }
        }    
    }
}
