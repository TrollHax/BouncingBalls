using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Main
{
    public class Ball
    {
        private Vector2 pos;
        private Vector2 vel;
        private Color fillColor, borderColor;
        private int size, velX, velY, red, green, blue, winWidth, winHeight;
        Random random = new Random();

        public Ball(int winWidth, int winHeight, int size)
        {
            velX = random.Next(-10, 11);
            velY = random.Next(-10, 11);
            red = random.Next(0, 256);
            green = random.Next(0, 256);
            blue = random.Next(0, 256);

            if (velX <= 2 &&
                velX >= -2)
            {
                while (velX <= 2 &&
                       velX >= -2)
                {
                    velX = random.Next(-10, 10);
                }
            }
            if (velY <= 2 &&
                velY >= -2)
            {
                while (velY <= 2 &&
                       velY >= -2)
                {
                    velY = random.Next(-10, 10);
                }
            }

            this.winWidth = winWidth;
            this.winHeight = winHeight;
            pos = new Vector2(winWidth / 2 - size / 2, winHeight / 2 - size / 2);
            vel = new Vector2(velX, velY);
            this.size = size;
            fillColor = Color.FromArgb(red, green, blue);
            borderColor = Color.Black;
        }
        public void draw(Graphics e)
        {
            e.FillEllipse(new SolidBrush(fillColor), pos.X, pos.Y, size, size);
        }
        public void update(int winWidth, int winHeight)
        {
            pos = Vector2.Add(pos, vel);
            this.winWidth = winWidth;
            this.winHeight = winHeight;

            if (pos.X >= winWidth - size)
            {
                pos.X = winWidth - size;
                vel.X *= -1;
            }
            if (pos.Y >= winHeight - size)
            {
                pos.Y = winHeight - size;
                vel.Y *= -1;
            }
            if (pos.X <= 0)
            {
                pos.X = 0;
                vel.X *= -1;
            }
            if (pos.Y <= 0)
            {
                pos.Y = 0;
                vel.Y *= -1;
            }
        }

    }
}
