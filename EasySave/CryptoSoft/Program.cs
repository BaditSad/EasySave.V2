using System;
using System.IO;
using System.Threading;

namespace CryptoSoft
{
    class Program
    {
        static int Main(string[] args)
        {
            string lang = "en";
            string[] extension = { ".txt", ".jpg", ".nsp" };
            string choiceS = "";
            string choiceR = "";
            int nFiles = 0;
            int nFile = 1;

            DirectoryInfo place = new DirectoryInfo(args[0]);
            FileInfo[] Files = place.GetFiles();

            var banner = new Banner();
            banner.CryptoSoftBanner();
            var step = new Menu();

            //Print extension from json

            step.print0(lang);

            foreach (string i in extension)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("- ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(i);
            }

            step.print1(lang);
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
            step.print2(lang, args[0]);

            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                var check = Array.Exists(extension, x => x == b);

                if (check == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("- ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(a);
                    nFiles++;
                }
                /*else if (check == false)
                {
                    step.print3(lang);
                    Thread.Sleep(5000);
                    Console.Clear();
                }*/
            }

            step.print4(lang);
            choiceR = Console.ReadLine();

            if (choiceR == "n" | choiceR == "N")
            {
                return -1;
            }

            if (choiceR == "y" & choiceR == "Y")
            {
                Console.Clear();
                return 1;
            }

            //start process foreach files
            step.print5(lang);

            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                var check = Array.Exists(extension, x => x == b);

                if (check == true)
                {
                    step.print6(lang, a, nFile, nFiles);
                    var process = new Crypt();
                    process.Xor(args[0] + a, a, lang);
                    nFile++;
                }
            }

            step.print8(lang, args[0]);
            step.print9(lang);
            return 1;
        }
    }
}