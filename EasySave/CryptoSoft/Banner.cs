using System;

namespace CryptoSoft
{
    class Banner
    {
        public void CryptoSoftBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\r\n╔═══╗────────╔╗───╔═══╗───╔═╦╗\r\n║╔═╗║───────╔╝╚╗──║╔═╗║───║╔╝╚╗\r\n║║─╚╬═╦╗─╔╦═╩╗╔╬══╣╚══╦══╦╝╚╗╔╝\r\n║║─╔╣╔╣║─║║╔╗║║║╔╗╠══╗║╔╗╠╗╔╣║\r\n║╚═╝║║║╚═╝║╚╝║╚╣╚╝║╚═╝║╚╝║║║║╚╗\r\n╚═══╩╝╚═╗╔╣╔═╩═╩══╩═══╩══╝╚╝╚═╝\r\n──────╔═╝║║║\r\n──────╚══╝╚╝");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" .ProSoft\n\n");
            Console.WriteLine(("").PadRight(70, '='));
        }
    }
}