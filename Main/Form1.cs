using System.Numerics;

namespace Main
{
    public partial class Form1 : Form
    {
        List<Ball> balls;
        public Form1()
        {
            InitializeComponent();
            balls = new List<Ball>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Ball ball in balls)
            {
                ball.draw(e.Graphics);
                ball.update(this.ClientSize.Width, this.ClientSize.Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            balls.Add(new Ball(this.ClientSize.Width, this.ClientSize.Height, 50));
        }
    }
}