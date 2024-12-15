using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame.Classes
{
    public class Player
    {
        public Physics physics;
        public int framesCount = 0;
        public int animationCount = 0;
        public int score = 0;

        public Player(PointF position, Size size) 
        { 
            physics = new Physics(position, size);
            framesCount = 0;
            score = 0;
        }

        public void drawSprite(Graphics g)
        {
            if (physics.isCrouching)
            {
                drawNeededSprite(g, 1870, 40, 109, 51, 118, 1.35f);
            }
            else
            {
                drawNeededSprite(g, 1518, 0, 79, 91, 88, 1);
            }
        }

        public void drawNeededSprite(Graphics g, int scrX, int scrY, int width, int height, int delta, float multiplier)
        {
            framesCount++;
            if (framesCount <= 10)
                animationCount = 0;
            else if (framesCount > 10 && framesCount <= 20)
                animationCount = 1;
            else if (framesCount > 20)
                framesCount = 0;

            g.DrawImage(GameController.spriteSheet, new Rectangle(new Point((int)physics.transform.position.X, (int)physics.transform.position.Y), new Size((int)(physics.transform.size.Width*multiplier),physics.transform.size.Height)),scrX+delta*animationCount,scrY,width,height,GraphicsUnit.Pixel);
        }
    }
}
