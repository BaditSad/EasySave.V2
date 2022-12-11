using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
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
