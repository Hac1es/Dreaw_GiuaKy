using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    internal class ServerClass
    {
        #region Properties
        TcpListener server;
        string IP = "127.0.0.1";
        int PORT = 9999;
        public const int BUFFER = 1024;
        static int connection = 0;
        static List<TcpClient> clientList = new List<TcpClient> ();
        #endregion

        public void CreateServer()
        {
            server = new TcpListener(IPAddress.Any, PORT);
            Thread serverThread = new Thread(() =>
            {
                while (true)
                {
                    Socket socket = server.AcceptSocket();
                    Thread clientThread = new Thread(() => HandleClient(socket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }    
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void HandleClient(Socket client)
        {
        }

        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }

        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        private byte[] BytedData(string chars)
        {
            return Encoding.UTF8.GetBytes(chars);
        }

        private string DebytedData(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}