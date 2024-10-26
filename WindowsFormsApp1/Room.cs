using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Room : Form
    {
        #region Properties
        SocketClient client; 
        Pen pen = new Pen(Color.Black, 2); //Bút vẽ
        static Pen eraser = new Pen(Color.White, 20); //Gôm
        bool cursorMoving = false; //Check xem chuột có đang di chuyển không
        int CursorX = -1; //Tọa độ X con trỏ chuột
        int CursorY = -1; //Tọa độ Y con trỏ chuột
        int rcv_cursorX = -1;
        int rcv_cursorY = -1;
        bool rcv_cursorMV = false;
        int index = 1; //Bút hay gôm, mặc định là bút
        Graphics graphic; //Bảng vẽ
        #endregion
        public Room()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InitializeCanvas();
            client = new SocketClient();
            Thread ping_pong = new Thread(() => PingUpdate());
            ping_pong.IsBackground = true;
            ping_pong.Start();      
        }

        private void InitializeCanvas()
        {
            Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphic = Graphics.FromImage(bitmap);
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphic.Clear(Color.White);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            canvas.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog ChooseColor = new ColorDialog();
            ChooseColor.ShowDialog();
            Color color = ChooseColor.Color;
            pictureBox1.BackColor = color;
            pen.Color = color;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pen.Width = comboBox1.SelectedIndex;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            bool connStatus = await client.ConnectServer();
            if (!connStatus)
                this.Close();
            comboBox1.SelectedIndex = 1;
            urIP.Text = client.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (urIP.Text == null)
                urIP.Text = client.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            Listen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index == 2)
                index = 1;
            else
                index = 2;
        }

        private void canvas_MouseDown_1(object sender, MouseEventArgs e)
        {
            cursorMoving = true;
            CursorX = e.X;
            CursorY = e.Y;
            var Data = new DrawingData(e.X, e.Y, null, null, DrawingCommand.BEGIN);
            SendData(Data);
        }

        private void canvas_MouseUp_1(object sender, MouseEventArgs e)
        {
            cursorMoving = false;
            CursorX = -1;
            CursorY = -1;
            var Data = new DrawingData(null, null, null, null, DrawingCommand.STOP);
            SendData(Data);
        }

        private void canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (CursorX != -1 && CursorY != -1 && cursorMoving == true)
            {
                switch(index)
                {
                    case 1:
                        graphic.DrawLine(pen, new Point(CursorX, CursorY), e.Location);
                        var drawData = new DrawingData(e.X, e.Y, pen.Width, pen.Color, DrawingCommand.DRAW);
                        SendData(drawData);
                        break;
                    default:
                        graphic.DrawLine(eraser, new Point(CursorX, CursorY), e.Location);
                        var eraserData = new DrawingData(e.X, e.Y, null, null, DrawingCommand.ERASER);
                        SendData(eraserData);
                        break;
                }
                CursorX = e.X;
                CursorY = e.Y;
                canvas.Invalidate();
            }
        }

        private async void SendData(DrawingData data)
        {
            string jsondilla = JsonConvert.SerializeObject(data);
            jsondilla += "\n";
            await client.Send(jsondilla);
        }

        private long GetPing(IPAddress ip)
        {
            
            Ping ping = new Ping();
            PingReply reply = ping.Send(ip);
            if (reply.Status == IPStatus.Success)
                return reply.RoundtripTime;
            return -1;
        }

        private async void PingUpdate()
        {
            while (true)
            {
                long pinG = GetPing(IPAddress.Parse(client.IP));
                urPing.Text = pinG.ToString() + " ms";
                if (0 <= pinG && pinG <= 40)
                {
                    weakSignal.Visible = false;
                    moderateSignal.Visible = false;
                    strongSignal.Visible = true;
                }
                else if (pinG <= 150)
                {
                    weakSignal.Visible = false;
                    moderateSignal.Visible = true;
                    strongSignal.Visible = false;
                }    
                else
                {
                    weakSignal.Visible = true;
                    moderateSignal.Visible = false;
                    strongSignal.Visible = false;
                }    
                await Task.Delay(10000);
            }    
        }

        private void Listen()
        {
            Task listenThread = new Task(async () =>
            {
                while (true)
                {
                    StringBuilder jsonBuffer = new StringBuilder(); // Bộ đệm để lưu trữ JSON nhận được
                    while (true)
                    {
                        string jsondata = await client.Receive();

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
                                ProcessData(data);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error deserializing JSON: " + ex.Message);
                            }
                        }

                        // Xóa dữ liệu đã xử lý khỏi bộ đệm
                        jsonBuffer.Clear();
                    }
                } 
            });
            listenThread.Start();
        }

        private void ProcessData(DrawingData data)
        {
            switch ((int)data.Event)
                {
                case 0:
                    rcv_cursorMV = true;
                    rcv_cursorX = (int)data.X;
                    rcv_cursorY = (int)data.Y;
                    break;
                case 1:
                    if (rcv_cursorX != -1 && rcv_cursorY != -1 && rcv_cursorMV == true)
                    {
                        using (Pen rcvPen = new Pen((Color)data.color, (float)data.lineWidth))
                        graphic.DrawLine(rcvPen, new Point(rcv_cursorX, rcv_cursorY), new Point((int)data.X, (int)data.Y));
                        rcv_cursorX = (int)data.X;
                        rcv_cursorY = (int)data.Y;
                        canvas.Invalidate();
                    }
                    break;
                case 2:
                    if (rcv_cursorX != -1 && rcv_cursorY != -1 && rcv_cursorMV == true)
                    {
                        graphic.DrawLine(eraser, new Point(rcv_cursorX, rcv_cursorY), new Point((int)data.X, (int)data.Y));
                        rcv_cursorX = (int)data.X;
                        rcv_cursorY = (int)data.Y;
                        canvas.Invalidate();
                    }
                    break;
                default:
                    rcv_cursorMV = false;
                    rcv_cursorX = -1;
                    rcv_cursorY = -1;
                    break;
                }
        }
    }
}
