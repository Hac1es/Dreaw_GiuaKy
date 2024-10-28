using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    internal class SocketClient
    {
        #region Properties
        Socket client; //Socket của Client
        //Thông tin Server
        public string IP = "192.168.43.212";
        public int PORT = 9999;
        public const int BUFFER = 2048; //Bộ đệm
        #endregion
       
        public async Task<bool> ConnectServer() //Kết nối tới server
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                await client.ConnectAsync(iep);
                return true;
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại! Vui lòng kiểm tra kết nối của bạn!");
                return false;
            }
        }

        public async Task Send(string data) //Gửi data đi
        {
            byte[] sendData = Encoding.UTF8.GetBytes(data);
            await client.SendAsync(new ArraySegment<byte>(sendData), SocketFlags.None);
        }

        public async Task<string> Receive() //Nhận data
        {
            byte[] receiveData = new byte[BUFFER];
            int bytesRcv 
                = await client.ReceiveAsync(new ArraySegment<byte>(receiveData), SocketFlags.None);
            if (bytesRcv == 0)
                return null;
            return Encoding.UTF8.GetString(receiveData, 0, bytesRcv);
        }

        public string GetLocalIPv4(NetworkInterfaceType _type) //Lấy ra địa chỉ IPv4
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
}
