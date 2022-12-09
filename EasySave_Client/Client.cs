using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace EasySave
{
    internal class ServerConnect
    {
        public static void Main()
        {
            EcouterReseau(SeConnecter());
            Deconnecter(SeConnecter());
        }
        private static Socket SeConnecter()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connectAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            socket.Bind(connectAddress);
            socket.Connect(connectAddress);
            return socket;
        }

        private static void EcouterReseau(Socket client)
        {
            client.Listen(10);
            while (true)
            {
                Console.WriteLine("listen");
            }
        }
        private static void Deconnecter(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
