using System;
using System.IO;
using System.Collections;
using System.Threading;



namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] extension = { ".txt", ".nsp" };

            DirectoryInfo place = new DirectoryInfo(args[0]);
            FileInfo[] Files = place.GetFiles();

            var banner = new Banner();
            banner.CryptoSoftBanner();

            Console.WriteLine(("").PadRight(63, '=')); ;

            //Print extension from json

            Console.WriteLine("\nExtension in EasySave configuration's file:\n");

            foreach (string i in extension)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("- ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(i);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nDo you want to continue [Y/N]?");
            Console.WriteLine("\nNote: add and remove extension from EasySave.");

            string choiceS = "";
            choiceS = Console.ReadLine();
            if (choiceS == "n" | choiceS == "N")
            {
                return;
            }
            if (choiceS == "y" & choiceS == "Y")
            {
                Console.Clear();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(("").PadRight(63, '=')); ;

            //Print files from folder where extension.file == extension.json

            Console.Write("\nFiles about to get run by the process from: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(args[0] + ":\n");

            int nFiles = 0;

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
                    Console.WriteLine("\nNo file found with the selected extension! Application terminate in 5s!");
                    Thread.Sleep(5000);
                    Console.Clear();
                }*/
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nDo you want to run the process [Y/N]?");

            string choiceR = "";
            choiceR = Console.ReadLine();
            if (choiceR == "n" | choiceR == "N")
            {
                return;
            }
            if (choiceR == "y" & choiceR == "Y")
            {
                Console.Clear();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(("").PadRight(63, '='));

            //start process foreach files

            Console.WriteLine("\nWarning: don't shutdown the application until the end of process!\n");
            
            int nFile = 1;

            foreach (FileInfo i in Files)
            {
                string a = i.Name;
                string b = i.Extension;
                var check = Array.Exists(extension, x => x == b);

                if (check == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[" + nFile + "/" + nFiles + "] Start process on: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(a);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("...");
                    var process = new Crypt();
                    process.Xor(args[0] + a, a);
                    nFile++;
                }  
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nAll process executed! Files should be in: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(args[0] + "\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(("").PadRight(63, '=')); ;
            Console.WriteLine("\nPress enter to close the application.");
            Console.Read();
        }
    }

    class Banner
    {
        public void CryptoSoftBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\r\n╔═══╗────────╔╗───╔═══╗───╔═╦╗\r\n║╔═╗║───────╔╝╚╗──║╔═╗║───║╔╝╚╗\r\n║║─╚╬═╦╗─╔╦═╩╗╔╬══╣╚══╦══╦╝╚╗╔╝\r\n║║─╔╣╔╣║─║║╔╗║║║╔╗╠══╗║╔╗╠╗╔╣║\r\n║╚═╝║║║╚═╝║╚╝║╚╣╚╝║╚═╝║╚╝║║║║╚╗\r\n╚═══╩╝╚═╗╔╣╔═╩═╩══╩═══╩══╝╚╝╚═╝\r\n──────╔═╝║║║\r\n──────╚══╝╚╝");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" .ProSoft\n\n");
            Console.WriteLine(("").PadRight(63, '='));
        }
    }

    class Crypt
    {
        public int Xor(string path, string file)
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
                    int k = 100 * i / bitToEncrypt.Length;
                    j = i % byteKey.Length;
                    bitCrypted[i] = bitToEncrypt[i] ^ bitKey[j];
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\r      Process running on: " + file + " [{0}]   ", k);
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\r      Process running on: " + file + " [{0}]   ", "Done");

                bitCrypted.CopyTo(byteCrypted, 0);

                File.WriteAllBytes(path, byteCrypted);

                TimeSpan mend = DateTime.Now - mstart;

                int time = mend.Milliseconds;

                Console.WriteLine("\n      Process successful! Duration " + time + "ms!");

                if (time == 0)
                {
                    return 0;
                }

                if (time > 0)
                {
                    return time;
                }

                return 1;
            }

            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\r      Process running on: " + file + " [Error]");
                Console.WriteLine("\r      Error during process! Process aborted! \n");
                return -1;
            }
        }
    }
}