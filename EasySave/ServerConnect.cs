using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;

namespace EasySave
{
    class ServerConnect
    {
        public Socket SeConnecter()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connectAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5037);
            //socket.Bind(connectAddress);
            socket.Connect(connectAddress);
            //socket.Listen(10);
            return socket;
        }

        public Socket AccepterConnexionAsync(Socket socket)
        {
            Socket accept = socket.Accept();
            return accept;
        }

        public void EcouterReseau(Socket client)
        {
            client.Listen(10);
        }
        public void Deconnecter(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
