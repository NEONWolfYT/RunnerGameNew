using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame.Classes
{
    public class Box
    {
        public Transform transform;
        int scrX = 0;

        public Box(PointF pos, Size size)
        {
            transform = new Transform (pos, size);
            ChooseRandomPic();
        }

        public void ChooseRandomPic()
        { 
            Random r= new Random ();
            int rnd = r.Next (0,3);
            switch(rnd)
            { 
                case 0:
                    scrX = 754;
                    break;
                case 1:
                    scrX = 804;
                    break;
                case 2:
                    scrX = 704;
                    break;
            }
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(GameController.spriteSheet, new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y), new Size(transform.size.Width, transform.size.Height)), scrX, 0, 48, 100, GraphicsUnit.Pixel);
        }
    }
}
