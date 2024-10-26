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
        public int? X { get; set; } 
        public int? Y { get; set; }
        public float? lineWidth { get; set; }
        [JsonIgnore]
        public Color? color { get; set; }
        public string ColorHex // Thuộc tính này sẽ chuyển đổi Color thành chuỗi Hex
        {
            get => color.HasValue ? $"#{color.Value.ToArgb():X8}" : null;
            set => color = value != null ? ColorTranslator.FromHtml(value) : (Color?)null;
        }
        public DrawingCommand Event { get; set; }

        public DrawingData(int? x, int? y, float? width, Color? coloR, DrawingCommand evenT)
        {
            X = x;
            Y = y;
            lineWidth = width;
            color = coloR;
            Event = evenT;  
        }
    }

    public enum DrawingCommand
    {
        BEGIN,
        DRAW,
        ERASER,
        STOP
    }

}
