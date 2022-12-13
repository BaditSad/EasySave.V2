
// A C# Program for Server
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{

    class Program
    {

        // Main Method
        static void Main(string[] args)
        {
            ExecuteServerAsync();
        }

        public static async Task ExecuteServerAsync()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                Socket clientSocket = listener.Accept();
                while (true)
                {
                    byte[] bytes = new Byte[1024];
                    while (true)
                    {
                        string data = Directory.GetCurrentDirectory();
                        data = data + "\\Statelog\\Statelog.json";
                        StreamReader read = new StreamReader(data, Encoding.UTF8);
                        byte[] message = Encoding.ASCII.GetBytes(read.ReadToEnd());
                        read.Close();
                        _ = await clientSocket.SendAsync(message, SocketFlags.None);
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}