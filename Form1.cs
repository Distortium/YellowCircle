using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YellowCircle
{
    public partial class Form1 : Form
    {
        private Color currentCircleColor = Color.Empty;
        private bool circleVisible;
        private Dictionary<(int x, int y, int d), Color> containsCircles = new Dictionary<(int x, int y, int d), Color>();
        private readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentCircleColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            circleVisible = true;

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (circleVisible)
            {
                Graphics g = e.Graphics;
                circleVisible = false;

                foreach (var circle in containsCircles)
                    using (SolidBrush brush = new SolidBrush(circle.Value))
                        g.FillEllipse(brush, circle.Key.x, circle.Key.y, circle.Key.d, circle.Key.d);

                int diametr = rnd.Next(10, 50);
                int x = rnd.Next(ClientSize.Width) - diametr;
                int y = rnd.Next(ClientSize.Height) - diametr;

                containsCircles.Add((x, y, diametr), currentCircleColor);

                using (SolidBrush brush = new SolidBrush(currentCircleColor))
                {
                    g.FillEllipse(brush, x, y, diametr, diametr);
                }
            }
        }
    }
}
