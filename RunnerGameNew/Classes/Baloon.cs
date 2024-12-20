﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame.Classes
{
    public class Baloon
    {
        public Transform transform;
        int frameCount = 0;
        int animationCount = 0;

        public Baloon(PointF pos, Size size)
        {
            transform = new Transform (pos, size);
        }

        public void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 10)
                animationCount = 0;
            else if (frameCount > 10 && frameCount <= 20)
                animationCount = 1;
            else if (frameCount > 20)
                frameCount = 0;

            g.DrawImage(GameController.spriteSheet, new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y), new Size(transform.size.Width, transform.size.Height)), 264 + 92 * animationCount, 6, 83, 71, GraphicsUnit.Pixel);   
        }

    }
}
