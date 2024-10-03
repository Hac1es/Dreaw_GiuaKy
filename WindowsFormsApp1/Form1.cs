using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Pen pen;
        Color color;
        int pensize;
        Boolean cursorMoving = false;
        int CursorX = -1;
        int CursorY = -1;
        Graphics graphic;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 2);
            graphic = canvas.CreateGraphics();
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog ChooseColor = new ColorDialog();
            ChooseColor.ShowDialog();
            color = ChooseColor.Color;
            pictureBox1.BackColor = color;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pensize = comboBox1.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pen = new Pen(color, pensize);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            cursorMoving = true;
            CursorX = e.X;
            CursorY = e.Y;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            cursorMoving = false;
            CursorX = -1;
            CursorY = -1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (CursorX != -1 && CursorY != -1 && cursorMoving == true)
            {
                graphic.DrawLine(pen, new Point(CursorX, CursorY), e.Location);
                CursorX = e.X;
                CursorY = e.Y;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }
    }
}
