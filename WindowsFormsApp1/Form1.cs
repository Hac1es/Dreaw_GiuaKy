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

        Pen pen = new Pen(Color.Black, 2);
        static Pen eraser = new Pen(Color.White, 20);
        bool cursorMoving = false;
        int CursorX = -1;
        int CursorY = -1;
        Graphics graphic;
        Bitmap bitmap;
        int index = 1;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(canvas.Width, canvas.Height);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
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
        }

        private void canvas_MouseUp_1(object sender, MouseEventArgs e)
        {
            cursorMoving = false;
            CursorX = -1;
            CursorY = -1;
        }

        private void canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (CursorX != -1 && CursorY != -1 && cursorMoving == true)
            {
                switch (index)
                {
                    case 2:
                        graphic.DrawLine(eraser, new Point(CursorX, CursorY), e.Location);
                        break;
                    default:
                        graphic.DrawLine(pen, new Point(CursorX, CursorY), e.Location);
                        break;
                }

                CursorX = e.X;
                CursorY = e.Y;
            }

            canvas.Invalidate();
        }
    }
}
