using System;
using System.IO;
using System.Collections;
using System.Threading;

namespace CryptoSoft
{
    class Crypt
    {
        public int Xor(string path, string file, string lang)
        {
            var step = new Menu();
            
            try
            {
                DateTime mstart = DateTime.Now;

                byte[] byteToEncrypt = File.ReadAllBytes(path);
                BitArray bitToEncrypt = new BitArray(byteToEncrypt);

                byte[] byteKey = new byte[64] {9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183, 9, 43, 102, 147, 8, 52, 157, 183};
                BitArray bitKey = new BitArray(byteKey);

                byte[] byteCrypted = new byte[byteToEncrypt.Length];
                BitArray bitCrypted = new BitArray(bitToEncrypt.Length);

                int j = 0;

                for (int i = 0; i < bitToEncrypt.Length; i++)
                {
                    //int k = 100 * i / bitToEncrypt.Length;
                    j = i % byteKey.Length;
                    bitCrypted[i] = bitToEncrypt[i] ^ bitKey[j];
                    //step.print71(lang, file, k);
                }

                step.print72(lang, file);

                bitCrypted.CopyTo(byteCrypted, 0);
                File.WriteAllBytes(path, byteCrypted);

                TimeSpan mend = DateTime.Now - mstart;
                int time = mend.Milliseconds;

                step.print73(lang, time);
                return time;
            }

            catch
            {
                step.print74(lang, file);
                return -1;
            }
        }
    }
}