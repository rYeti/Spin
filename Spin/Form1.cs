using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spin
{
    public partial class Form1 : Form
    {
        Thread th;
        Graphics g;
        Graphics fG;
        Bitmap btm;
        public Form1()
        {
            InitializeComponent();
        }

        bool drawing = true;
        int numFrames = 100;
        int frameCount = 1;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            btm = new Bitmap(1600, 1600);
            g = Graphics.FromImage(btm);
            fG = CreateGraphics();
            th = new Thread(Draw)
            {
                IsBackground = true
            };
            th.Start();

        }
        private void Draw()
        {
            float r = 100f;
            Brush aBrush = (Brush)Brushes.Red;
            Graphics g = this.CreateGraphics();
            RectangleF circle = new RectangleF(Width/2, Height/2, 20, 20);
            PointF loc = PointF.Empty;
            PointF img = new PointF(500, 200);

            while (drawing)
            {
                g.Clear(Color.Black);
                float t = 1.0f * frameCount / numFrames;
                
                circle.X = (float)((Width / 2) + r * Math.Cos(Math.PI * 2 * t));
                circle.Y = (float)(Height / 2 + r * Math.Sin(Math.PI * 2 * t));

                g.FillEllipse(aBrush, circle);

                fG.DrawImage(btm, img);

                frameCount++;
            }
        }
    }
}
