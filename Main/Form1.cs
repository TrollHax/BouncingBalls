using System.Numerics;

namespace Main
{
    public partial class Form1 : Form
    {
        List<Ball> balls;
        bool removeBall;
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
            for (int i = 0; i < balls.Count(); i++)
            {
                Ball ball = balls[i];
                if (removeBall)
                {
                    balls.Remove(ball);
                    removeBall = false;
                }

                ball.draw(e.Graphics);
                ball.update(this.ClientSize.Width, this.ClientSize.Height);
            }
            label1.Text = ("Amount of balls: " + balls.Count());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            balls.Add(new Ball(this.ClientSize.Width, this.ClientSize.Height, 50));
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (balls.Count > 0)
            {
                removeBall = true;
            }
        }
    }
}