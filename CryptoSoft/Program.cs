using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
    class Program
    {
        //int Main
        static void Main(string[] args)
        {
            //string lang = "";
            string[] extension = { ".PNG", ".txt", ".nsp" };

            int T = 0; 

            DirectoryInfo place = new DirectoryInfo(args[0]);
            FileInfo[] Files = place.GetFiles();

            var banner = new Banner();
            banner.CryptoSoftBanner();

            Console.WriteLine("\nExtension selected:\n");
            foreach (string i in extension)
            {
                Console.WriteLine("- " + i);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r___________________________________________________________________");
            Console.WriteLine("\nFiles about to get crypt from the selected folder, " + args[0] + ":\n");
            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                var check = Array.Exists(extension, x => x == b);

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
                    process.Xor(args[0] + a);
                }
            }
            Console.WriteLine("\r___________________________________________________________________");
            Console.WriteLine("\nPress enter to close the application.");
            Console.WriteLine("\n T = " + T);
            Console.Read();
        }
    }
}
