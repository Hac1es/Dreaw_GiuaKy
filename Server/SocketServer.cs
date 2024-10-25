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
        TcpListener server; //nơi Server lắng nghe
        int PORT = 9999; //số Port mặc định
        public const int BUFFER = 1024; //kích thước bộ đệm dữ liệu mặc định
        static int connection = 0; //số lượng kết nối
        static List<Socket> clientList = new List<Socket>();//danh sách Client
        #endregion

        public ServerClass()
        {
            server = new TcpListener(IPAddress.Any, PORT); //khởi tạo TcpListener
            server.Start(); //bắt đầu lắng nghe
            Console.WriteLine("Waiting for client...");
            while (true)
            {
                Socket client = server.AcceptSocket(); //Chấp nhận kết nối
                //Tạo luổng riêng để xử lý Client
                Thread handleClient = new Thread(() => HandleClient(client));
                handleClient.Start();
            }

        }

        private void HandleClient(Socket client)
        {
            int recvWind; // kích thước dữ liệu nhận được
            byte[] data; // bộ đệm dữ liệu
            connection++; // tăng số lượng kết nối hiện tại
            //Lấy thông tin client
            IPEndPoint? client_in4 = client.RemoteEndPoint as IPEndPoint;
            if (client_in4 != null) //nếu lấy được thông tin 
            {
                Console.WriteLine("New Dreawer {0}::{1} has connected!", client_in4.Address.ToString(), client_in4.Port);
            }
            else //nếu không lấy được
            {
                Console.WriteLine("Unable to retrieve client information.");
            }
            Console.WriteLine("Current status: {0} active connections", connection);
            clientList.Add(client); //thêm Client mới kết nối vào danh sách
            try //Vòng lặp gửi nhận dữ liệu
            {
                while (true)
                {
                    //Nhận dữ liệu
                    data = new byte[BUFFER];
                    recvWind = client.Receive(data);
                    if (recvWind == 0) //Không data == ngắt kết nối? Tui cũng đéo hiểu:v
                    {
                        Console.WriteLine("A Dreawer has disconnected!");
                        break;
                    }
                    //Gửi flood tới mọi node đang conn tới server
                    foreach (Socket c in clientList)
                        if (c != client && c.Connected == true)
                        {
                            c.Send(data, 0, recvWind, SocketFlags.None);
                        }
                        else 
                            continue;
                }
            }
            catch (SocketException) //Exception khi đang gửi/nhận mà client socket ngắt kết nối đột ngột
            {
                //Do nothing
            }
            finally //Giải phóng tài nguyên
            {
                //Ngắt kết nối với client
                client.Close();
                clientList.Remove(client);
                connection--; // giảm số lượng conn
                Console.WriteLine("A Dreawer has disconnected!");
                Console.WriteLine("Current status: {0} active connections", connection);
            }
        }
    }
}