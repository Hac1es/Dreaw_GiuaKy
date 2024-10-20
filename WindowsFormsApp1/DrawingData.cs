using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    internal class DrawingData
    {
        public int StartX { get; set; }  // Tọa độ bắt đầu
        public int StartY { get; set; }  // Tọa độ kết thúc
        public int EndX { get; set; }    // Tọa độ kết thúc
        public int EndY { get; set; }    // Tọa độ kết thúc
        public Color penColor { get; set; }  // Màu bút vẽ
        public int PenWidth { get; set; }  // Độ rộng của bút vẽ
        public bool whatTool { get; set; }   // Loại công cụ (ví dụ: pen, eraser)

        // Hàm constructor
        public DrawingData(int startX, int startY, int endX, int endY, Color color, int penWidth, bool tool)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
            penColor = color;
            PenWidth = penWidth;
            whatTool = tool;
        }
    }
}
