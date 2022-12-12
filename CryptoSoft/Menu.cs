using System;
using System.Threading;

namespace CryptoSoft
{
    class Menu
    {
        public void print0(string lang)
        {
            if (lang == "en")
            {
                Console.WriteLine(("").PadRight(70, '='));
                Console.WriteLine(("").PadRight(70, '='));
                Console.WriteLine("\nExtensions found in EasySave3.0 configuration's file:");
            }

            if (lang == "fr")
            {
                Console.WriteLine(("").PadRight(88, '='));
                Console.WriteLine(("").PadRight(88, '='));
                Console.WriteLine("\nExtensions trouvées dans le fichier de configuration de EasySave3.0 :");
            }
        }

        public void print1(string lang)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (lang == "en")
            {
                Console.WriteLine("\nDo you want to continue [Y/N]?");
                Console.WriteLine("\nNote: add and remove an extension from EasySave3.0.");
            }

            if (lang == "fr")
            {
                Console.WriteLine("\nVoulez-vous continuer [Y/N] ?");
                Console.WriteLine("\nNote: ajouter ou supprimer une extension depuis EasySave3.0.");
            }
        }

        public void print2(string lang, string file)
        {
            if (lang == "en")
            {
                Console.WriteLine(("").PadRight(70, '='));
                Console.Write("\nFiles about to get manipulate by the process, from: ");
            }

            if (lang == "fr")
            {
                Console.WriteLine(("").PadRight(88, '='));
                Console.Write("\nFichiers qui vont être manipulés par le processus, depuis : ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(file + "\n");
        }

        public void print3(string lang)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (lang == "en")
            {
                Console.WriteLine("Warning: no file matched the selected extensions configured in EasySave3.0!\n");
                for (int i = 5; i > 0; i--)
                {
                    Console.Write("\rApplication terminate in {0}s!", i);
                    Thread.Sleep(1000);
                }
            }

            if (lang == "fr")
            {
                Console.WriteLine("Attention : aucun fichier trouvé qui correspond aux extensions configuré dans EasySave3.0 !\n,");
                for (int i = 5; i > 0; i--)
                {
                    Console.Write("\rL'application va se fermer dans {0}s !", i);
                    Thread.Sleep(1000);
                }
            }
        }

        public void print4(string lang)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (lang == "en")
            {
                Console.WriteLine("\nDo you want to run the process [Y/N]?");
            }

            if (lang == "fr")
            {
                Console.WriteLine("\nVoulez-vous lancer le processus [Y/N] ?");
            }
        }

        public void print5(string lang)
        {
            if (lang == "en")
            {
                Console.WriteLine(("").PadRight(70, '='));
                Console.WriteLine("\nWarning: don't shutdown the console while processes are in progress!\n");
            }

            if (lang == "fr")
            {
                Console.WriteLine(("").PadRight(88, '='));
                Console.WriteLine("\nAttention : ne fermez pas la console tant que les processus sont en cours !\n");
            }
        }

        public void print6(string lang, string file, int nb, int nbs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (lang == "en")
            {
                Console.Write("[0" + nb + "/" + nbs + "] Start process on: ");
            }

            if (lang == "fr")
            {
                Console.Write("[0" + nb + "/" + nbs + "] Lancement du processus sur : ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(file);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("...");
        }

        public void print61(string lang, string file, int nb, int nbs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (lang == "en")
            {
                Console.Write("[" + nb + "/" + nbs + "] Start process on: ");
            }

            if (lang == "fr")
            {
                Console.Write("[" + nb + "/" + nbs + "] Lancement du processus sur : ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(file);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("...");
        }

        public void print71(string lang, string file, int k)
        {
            if (lang == "en")
            {
                Console.Write("\r        Process running on: " + file + " [{0}%]   ", k);
            }

            if (lang == "fr")
            {
                Console.Write("\r        Processus s'execute sur : " + file + " [{0}%]   ", k);
            }
        }

        public void print72(string lang, string file)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (lang == "en")
            {
                Console.Write("\r        Process running on: " + file + " [{0}]   ", "Done");
            }

            if (lang == "fr")
            {
                Console.Write("\r        Processus s'execute sur : " + file + " [{0}]   ", "Done");
            }
        }

        public void print73(string lang, int time)
        {
            if (lang == "en")
            {
                Console.WriteLine("\n        Process successful! Duration " + time + "ms!\n");
            }

            if (lang == "fr")
            {
                Console.WriteLine("\n        Processus terminé! Durée " + time + "ms!\n");
            }
        }

        public void print74(string lang, string file)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            if (lang == "en")
            {
                Console.WriteLine("\r        Process running on: " + file + " [Error]");
                Console.WriteLine("\r        Error during process! Process aborted! \n");
            }

            if (lang == "fr")
            {
                Console.WriteLine("\r        Processus en cours: " + file + " [Error]");
                Console.WriteLine("\r        Erreur during le processus ! \n");
            }
        }

        public void print8(string lang, string path)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (lang == "en")
            {
                Console.Write("All process executed! Files should be in: ");
            }

            if (lang == "fr")
            {
                Console.Write("Tous les processus terminés ! Les fichiers devraient se trouver dans : ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(path + "\n");
        }

        public void print9(string lang)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (lang == "en")
            {
                Console.WriteLine(("").PadRight(70, '=')); 
                Console.WriteLine("\nPress Enter to close the console.");
            }

            if (lang == "fr")
            {
                Console.WriteLine(("").PadRight(88, '=')); 
                Console.WriteLine("\nAppuyez sur Entrer pour quitter la console.");
            }

            Console.Read();
        }
    }
}
