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

    class Banner
    {
        public void CryptoSoftBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" \r\n╔═══╗────────╔╗───╔═══╗───╔═╦╗\r\n║╔═╗║───────╔╝╚╗──║╔═╗║───║╔╝╚╗\r\n║║─╚╬═╦╗─╔╦═╩╗╔╬══╣╚══╦══╦╝╚╗╔╝\r\n║║─╔╣╔╣║─║║╔╗║║║╔╗╠══╗║╔╗╠╗╔╣║\r\n║╚═╝║║║╚═╝║╚╝║╚╣╚╝║╚═╝║╚╝║║║║╚╗\r\n╚═══╩╝╚═╗╔╣╔═╩═╩══╩═══╩══╝╚╝╚═╝\r\n──────╔═╝║║║\r\n──────╚══╝╚╝");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" .ProSoft\n");
            Console.WriteLine("\r___________________________________________________________________");
        }
    }

    class Crypt
    {
        public int Xor(string path)
        {
            try
            {
                DateTime mstart = DateTime.Now;

                byte[] byteToEncrypt = File.ReadAllBytes(path);
                BitArray bitToEncrypt = new BitArray(byteToEncrypt);

                byte[] byteKey = new byte[8] { 9, 43, 102, 147, 8, 52, 157, 183 };
                BitArray bitKey = new BitArray(byteKey);

                byte[] byteCrypted = new byte[byteToEncrypt.Length];
                BitArray bitCrypted = new BitArray(bitToEncrypt.Length);

                int j = 0;

                for (int i = 0; i < bitToEncrypt.Length; i++)
                {
                    j = i % byteKey.Length;
                    bitCrypted[i] = bitToEncrypt[i] ^ bitKey[j];
                }

                bitCrypted.CopyTo(byteCrypted, 0);

                File.WriteAllBytes(path, byteCrypted);

                TimeSpan mend = DateTime.Now - mstart;

                int c = mend.Milliseconds;

                Console.WriteLine("File crypted in " + c + "ms\n");

                if (c == 0)
                {
                    return 0;
                }

                if (c > 0)
                {
                    return c;
                }

                return 1;
            }

            catch
            {
                Console.WriteLine("Error cannot crypt this file\n");
                return -1;
            }
        }
    }
}
