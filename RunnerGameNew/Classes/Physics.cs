using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunnerGame.Classes
{
    public class Physics
    {
        public Transform transform;
        float gravity;
        float a;

        public bool isJumping;
        public bool isCrouching;

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position,size);
            gravity = 0;
            a = 0.4f;
            isJumping = false; 
            isCrouching = false;
        }

        public void ApplyPhysics()
        {
            calculatePhysics();
        }

        public void calculatePhysics()
        {
            if (transform.position.Y < 150 || isJumping)
            {
                transform.position.Y += gravity;
                gravity += a;
            }
            if (transform.position.Y > 150)
            {
                isJumping = false;
            }
        }

        public bool collide()
        {
            for (int i = 0; i < GameController.boxes.Count; i++)
            {
                var box = GameController.boxes[i];
                PointF delta =new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) - (box.transform.position.X + box.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) - (box.transform.position.Y + box.transform.size.Height / 2);
                if (Math.Abs(delta.X)<=transform.size.Width/2+box.transform.size.Width/2)
                {
                   if (Math.Abs(delta.Y) <= transform.size.Height / 2 + box.transform.size.Height / 2)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < GameController.baloons.Count; i++)
            {
                var baloon = GameController.baloons[i];
                PointF delta = new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) - (baloon.transform.position.X + baloon.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) - (baloon.transform.position.Y + baloon.transform.size.Height / 2);
                if (Math.Abs(delta.X) <= transform.size.Width / 2 + baloon.transform.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= transform.size.Height / 2 + baloon.transform.size.Height / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void addForce()
        {
            if(!isJumping)
            {
                isJumping = true;
                gravity = -10;
            }
        }
    }
}
