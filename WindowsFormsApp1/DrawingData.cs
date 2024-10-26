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
        public int? X { get; set; } //Tọa độ X của nét vẽ
        public int? Y { get; set; } //Tọa độ Y của nét vẽ
        public float? lineWidth { get; set; } //Độ dày nét vẽ
        [JsonIgnore]
        public Color? color { get; set; } //Màu vẽ
        public string ColorHex // Chuyển đổi Color thành chuỗi HexRGB để convert thành JSON
        {
            get => color.HasValue ? $"#{color.Value.ToArgb():X8}" : null;
            set => color = value != null ? ColorTranslator.FromHtml(value) : (Color?)null;
        }
        public DrawingCommand Event { get; set; } // Các lệnh vẽ

        public DrawingData(int? x, int? y, float? width, Color? coloR, DrawingCommand evenT) //Constructor
        {
            X = x;
            Y = y;
            lineWidth = width;
            color = coloR;
            Event = evenT;  
        }
    }

    public enum DrawingCommand //Danh sách lệnh vẽ
    {
        BEGIN,
        DRAW,
        ERASER,
        STOP
    }

}
