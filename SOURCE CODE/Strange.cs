﻿using System;
using System.Drawing;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;

namespace Puspula
{
    public partial class Strange : Form
    {
        private Timer timer;
        private Bitmap bitmap;
        public Strange()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            this.Controls.Add(pictureBox);

            bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (s, e) => EfeitoStaticoUpdate(pictureBox);
            timer.Start();
        }

        private void EfeitoStaticoUpdate(PictureBox pictureBox)
        {
            Random rand = new Random();
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int intensity = rand.Next(200);
                    Color staticColor = Color.FromArgb(intensity, intensity, intensity);
                    bitmap.SetPixel(x, y, staticColor);
                }
            }
            pictureBox.Image = bitmap;
        }

        private void Strange_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Strange_Load(object sender, EventArgs e)
        {

        }

        private void Move_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            if (this.DesktopLocation == Point.Empty)
            {
                this.DesktopLocation = new Point(r.Next(1, 900), r.Next(1, 900));
            }
            else
            {
                this.DesktopLocation = new Point(r.Next(1, 900), r.Next(1, 900));
            }
        }
    }
}