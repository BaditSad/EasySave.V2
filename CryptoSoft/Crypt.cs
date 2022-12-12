using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
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
