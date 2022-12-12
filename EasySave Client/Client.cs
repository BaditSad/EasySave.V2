using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            ExecuteClient();
        }
        static void ExecuteClient()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
                Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.Connect(localEndPoint);
                    while(true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" \r\n███████╗░█████╗░░██████╗██╗░░░██╗░██████╗░█████╗░██╗░░░██╗███████╗\r\n██╔════╝██╔══██╗██╔════╝╚██╗░██╔╝██╔════╝██╔══██╗██║░░░██║██╔════╝\r\n█████╗░░███████║╚█████╗░░╚████╔╝░╚█████╗░███████║╚██╗░██╔╝█████╗░░\r\n██╔══╝░░██╔══██║░╚═══██╗░░╚██╔╝░░░╚═══██╗██╔══██║░╚████╔╝░██╔══╝░░\r\n███████╗██║░░██║██████╔╝░░░██║░░░██████╔╝██║░░██║░░╚██╔╝░░███████╗\r\n╚══════╝╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝ ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" .V1");
                        Console.Write(" (alpha)\n");
                        Console.WriteLine("connected to -> {0} \n", sender.RemoteEndPoint.ToString());
                        byte[] messageReceived = new byte[1024];
                        int byteRecv = sender.Receive(messageReceived);
                        Console.WriteLine("{0}",
                            Encoding.ASCII.GetString(messageReceived,
                                                        0, byteRecv));
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
