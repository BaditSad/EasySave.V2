using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
    class Program
    {
        //int Main
        static void Main(string[] arg_PathExt, string[] arg_PathFolder, string[] arg_lang)
        {
            //string lang = "";
            Values getExt = new Values();

            int T = 0; 

            DirectoryInfo place = new DirectoryInfo(arg_PathFolder[0]);
            FileInfo[] Files = place.GetFiles();

            var banner = new Banner();
            banner.CryptoSoftBanner();

            Console.WriteLine("\nExtension selected:\n");
            foreach (object item in getExt.ExtListDo(arg_PathExt[0]))
            {
                Console.WriteLine("- " + item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r___________________________________________________________________");
            Console.WriteLine("\nFiles about to get crypt from the selected folder, " + arg_PathFolder[0] + ":\n");
            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                var check = Array.Exists(/*Extension*\, x => x == b);

                if (check == true)
                {   
                    Console.WriteLine("- " + a);
                }
            }
            
            Console.WriteLine("\nDo you want to run the process ? (y/n)");
            string test = Console.ReadLine();


            Console.ReadLine();

            Console.WriteLine("\r___________________________________________________________________");
            Console.WriteLine("\nDon't shutdown the application until the end of the procedure!\n");

            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                var check = Array.Exists(extension, x => x == b);

                if (check == true)
                {
                    Console.WriteLine("File: " + a + " being crypt");
                    var process = new Crypt();
                    process.Xor(arg_PathFolder[0] + a);
                }
            }
            Console.WriteLine("\r___________________________________________________________________");
            Console.WriteLine("\nPress enter to close the application.");
            Console.WriteLine("\n T = " + T);
            Console.Read();
        }
    }
}
