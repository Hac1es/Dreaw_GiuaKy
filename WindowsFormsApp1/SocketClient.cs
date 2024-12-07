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
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    internal class SocketClient
    {
        #region Properties
        HubConnection _conn;
        string serverAdd = "https://localhost:7183/hub";
        #endregion

        public async void ConnectServer() //Kết nối tới server
        {
            _conn = new HubConnectionBuilder().WithUrl(serverAdd).Build();
            await _conn.StartAsync();
        }

        public async Task Send(string data) //Gửi data đi
        {
            await _conn.InvokeAsync("SendFlood", data);
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

        public void Listen(Action<DrawingData> ProcessData) //Lắng nghe dữ liệu từ Server
        {
            StringBuilder jsonBuffer = new StringBuilder(); // Bộ đệm để lưu trữ JSON nhận được
            _conn.On<string>("ReceiveData", (jsondata) =>
            {
                // Thêm dữ liệu mới vào bộ đệm
                jsonBuffer.Append(jsondata);

                // Tách các JSON bằng cách tìm ký tự newline
                string[] jsonObjects = jsonBuffer.ToString().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Xử lý từng JSON riêng lẻ
                foreach (var jsonObject in jsonObjects)
                {
                    try
                    {
                        DrawingData data = JsonConvert.DeserializeObject<DrawingData>(jsonObject);
                        if (data != null)
                        {
                            ProcessData(data);
                        }
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"JSON Parsing Error: {ex.Message}");
                    }
                }

                // Xóa phần đã xử lý khỏi bộ đệm
                int lastNewlineIndex = jsonBuffer.ToString().LastIndexOf('\n');
                if (lastNewlineIndex != -1)
                {
                    jsonBuffer.Remove(0, lastNewlineIndex + 1);
                }
            });
        }
    }
}
