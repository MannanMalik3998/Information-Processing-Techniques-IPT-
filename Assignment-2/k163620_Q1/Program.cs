using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q1
{
    class Program
    {
        private static byte[] buffer = new byte[1024];
        //sockets initialization
        private static List<Socket> Client = new List<Socket>();
        private static Socket Server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.Title = "Server";
            SetServer();//server startup
            Console.ReadKey();
        }

        private static void SetServer() {
            Console.WriteLine("Listening");//awaiting connections
            Server.Bind(new IPEndPoint(IPAddress.Any,100));
            Server.Listen(5);
            Server.BeginAccept(new AsyncCallback(CallBack),null);
        }

        private static void CallBack(IAsyncResult aSyncResult) {
            Socket socket = Server.EndAccept(aSyncResult);
            Client.Add(socket);
            Console.WriteLine("Client Added");

            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(recCallBack), socket);
            Server.BeginAccept(new AsyncCallback(CallBack),null);
        }

        private static void recCallBack(IAsyncResult asyncResult) {
            Socket socket = (Socket)asyncResult.AsyncState;
            int rec = socket.EndReceive(asyncResult);
            byte[] dataBuf = new byte[rec];
            Array.Copy(buffer,dataBuf,rec);
            string txt = Encoding.ASCII.GetString(dataBuf);
            Console.WriteLine("Received:    "+txt);//data receive from clientside

            //

            //

            string reply = string.Empty;

            reply = reverse(txt);
            Console.WriteLine("Sent:" + reply);


            if (!txt.Equals("")) {
                byte[] data = Encoding.ASCII.GetBytes(reply);
                socket.BeginSend(data,0,data.Length,SocketFlags.None,new AsyncCallback(sendCallBack),socket);
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(recCallBack), socket);
            }

        }

        private static string reverse(String str) {
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private static void sendCallBack(IAsyncResult asyncResult) {
            Socket socket = (Socket)asyncResult.AsyncState;
            socket.EndSend(asyncResult);
        }
    }
}
