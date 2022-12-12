using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
    class Program
    {
        //int Main
        static int Main(string[] args)
        {
            Values.Instance.EasySavePath = args[0];
            Values.Instance.Lang = Values.Instance.EasySavePath + "\\Config\\Lang.json";
            Values.Instance.ExtValues = Values.Instance.EasySavePath + "\\CryptoSoft\\Ext.json";
            Values.Instance.PathToCrypt = Values.Instance.EasySavePath + "\\CryptoSoft\\PathToCrypt.json";
            List list = new List();
            string choiceS = "";
            string choiceR = "";
            int nFiles = 0;
            int nFile = 1;
            bool B = false;

            DirectoryInfo place = new DirectoryInfo(Values.Instance.PathToCrypt);
            FileInfo[] Files = place.GetFiles();

            var banner = new Banner();
            banner.CryptoSoftBanner();

            var step = new Menu();

            //Print extension from json

            step.print0(Values.Instance.Lang);

            foreach (var items in list.ExtListDo())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("- ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(items);
            }

            step.print1(Values.Instance.Lang);
            choiceS = Console.ReadLine();

            if (choiceS == "n" | choiceS == "N")
            {
                return -1;
            }

            if (choiceS == "y" & choiceS == "Y")
            {
                Console.Clear();
                return 1;
            }

            //Print files from folder where extension.file == extension.json
            step.print2(Values.Instance.Lang, Values.Instance.PathToCrypt);

            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                foreach (var items in list.ExtListDo())
                {
                    if (b == items.ToString())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("- ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(a);
                        nFiles++;
                    }
                }
                /*if (B == false)
                {
                    step.print3(Values.Instance.Lang);
                    return -1;
                }*/
            }

            step.print4(Values.Instance.Lang);
            choiceR = Console.ReadLine();

            if (choiceR == "n" | choiceR == "N")
            {
                return -1;
            }

            if (choiceR == "y" & choiceR == "Y")
            {
                return 1;
            }

            //start process foreach files
            step.print5(Values.Instance.Lang);

            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                foreach (var items in list.ExtListDo())
                {
                    if (b == items.ToString())
                    {
                        if(nFile < 10)
                        {
                            step.print6(Values.Instance.Lang, a, nFile, nFiles);
                        }
                        
                        else 
                        {
                            step.print61(Values.Instance.Lang, a, nFile, nFiles);
                        }

                        var process = new Crypt();
                        process.Xor(Values.Instance.PathToCrypt + a, a, Values.Instance.Lang);
                        nFile++;
                    }
                }
            }

            step.print8(Values.Instance.Lang, Values.Instance.PathToCrypt);
            step.print9(Values.Instance.Lang);
            return 1;
        }
    }
}
