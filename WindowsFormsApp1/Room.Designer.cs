namespace WindowsFormsApp1
{
    partial class Room
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.urIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.strongSignal = new System.Windows.Forms.PictureBox();
            this.moderateSignal = new System.Windows.Forms.PictureBox();
            this.weakSignal = new System.Windows.Forms.PictureBox();
            this.urPing = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strongSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moderateSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weakSignal)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Chọn màu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(216, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(199, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Chọn cỡ bút";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(65, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 37);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(391, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Gôm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(15, 119);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(822, 351);
            this.canvas.TabIndex = 7;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown_1);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove_1);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp_1);
            // 
            // urIP
            // 
            this.urIP.BackColor = System.Drawing.SystemColors.Control;
            this.urIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urIP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urIP.Location = new System.Drawing.Point(659, 29);
            this.urIP.Name = "urIP";
            this.urIP.Size = new System.Drawing.Size(178, 23);
            this.urIP.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(580, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Your IP: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // strongSignal
            // 
            this.strongSignal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("strongSignal.BackgroundImage")));
            this.strongSignal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.strongSignal.Location = new System.Drawing.Point(581, 68);
            this.strongSignal.Name = "strongSignal";
            this.strongSignal.Size = new System.Drawing.Size(44, 35);
            this.strongSignal.TabIndex = 10;
            this.strongSignal.TabStop = false;
            // 
            // moderateSignal
            // 
            this.moderateSignal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moderateSignal.BackgroundImage")));
            this.moderateSignal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moderateSignal.Location = new System.Drawing.Point(581, 67);
            this.moderateSignal.Name = "moderateSignal";
            this.moderateSignal.Size = new System.Drawing.Size(44, 35);
            this.moderateSignal.TabIndex = 11;
            this.moderateSignal.TabStop = false;
            // 
            // weakSignal
            // 
            this.weakSignal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("weakSignal.BackgroundImage")));
            this.weakSignal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.weakSignal.Location = new System.Drawing.Point(581, 68);
            this.weakSignal.Name = "weakSignal";
            this.weakSignal.Size = new System.Drawing.Size(44, 35);
            this.weakSignal.TabIndex = 12;
            this.weakSignal.TabStop = false;
            // 
            // urPing
            // 
            this.urPing.BackColor = System.Drawing.SystemColors.Control;
            this.urPing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urPing.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urPing.Location = new System.Drawing.Point(644, 72);
            this.urPing.Name = "urPing";
            this.urPing.Size = new System.Drawing.Size(178, 23);
            this.urPing.TabIndex = 13;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 481);
            this.Controls.Add(this.urPing);
            this.Controls.Add(this.weakSignal);
            this.Controls.Add(this.moderateSignal);
            this.Controls.Add(this.strongSignal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urIP);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Room";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strongSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moderateSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weakSignal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox urIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox strongSignal;
        private System.Windows.Forms.PictureBox moderateSignal;
        private System.Windows.Forms.PictureBox weakSignal;
        private System.Windows.Forms.TextBox urPing;
    }
}

