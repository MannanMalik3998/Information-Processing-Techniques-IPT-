using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace clientt
{
    class Program
    {
        private static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//socket initialization

        static void Main(string[] args)
        {
            Console.Title = "Client";
            connect();//connection initiated
            Send();//sending requests
            Console.ReadKey();
        }

        private static void Send()
        {
            while (true)
            {
                Console.Write("Enter a request: ");
                string req = Console.ReadLine();

                Console.WriteLine("Sent:" + req);//message to be sent

                if (req.Equals("exit"))
                {
                    Console.WriteLine(req + "\nExiting.......");
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    Console.WriteLine("ConnectionClosed");
                    return;
                }

                byte[] buffer = Encoding.ASCII.GetBytes(req);
                client.Send(buffer);//message sent

                byte[] received = new byte[1024];
                int rec = client.Receive(received);//reply received from server

                byte[] data = new byte[rec];
                Array.Copy(received, data, rec);
                Console.WriteLine("Received:    " + Encoding.ASCII.GetString(data));//displayed
            }
        }
        private static void connect()
        {//making connection with server
            int atmpts = 0;
            while (!client.Connected)
            {
                try
                {
                    atmpts++;
                    client.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    //Console.WriteLine("Connections: "+atmpts.ToString());
                }
            }
            Console.Clear();
            Console.WriteLine("Connected");
        }
    }
}
