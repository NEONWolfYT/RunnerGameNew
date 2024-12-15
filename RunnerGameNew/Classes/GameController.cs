using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame.Classes
{
    public static class GameController
    {
        public static Image spriteSheet;
        public static List<Road> roads;
        public static List<Box> boxes;
        public static List<Baloon> baloons;
        public static int dangerSpawn = 10;
        public static int countDangerSpawn = 0;

        public static void Init()
        {
            roads = new List<Road>();
            boxes = new List<Box>();
            baloons = new List<Baloon>();
            spriteSheet = RunnerGameNew.Properties.Resources.sprite;
            generateRoad();
        }

        public static void moveMap()
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].transform.position.X -= 4;
                if (roads[i].transform.position.X + roads[i].transform.size.Width < 0)
                {
                    roads.RemoveAt(i);
                    getNewRoad();
                }
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                boxes[i].transform.position.X -= 4;
                if (boxes[i].transform.position.X + boxes[i].transform.size.Width < 0)
                {
                    boxes.RemoveAt(i);
                }
            }

            for (int i = 0; i < baloons.Count; i++)
            {
                baloons[i].transform.position.X -= 4;
                if (baloons[i].transform.position.X + baloons[i].transform.size.Width < 0)
                {
                    baloons.RemoveAt(i);
                }
            }
        }

        public static void getNewRoad()
        {
            Road road = new Road(new PointF(0 + 100 * 9, 200), new Size(100, 17));
            roads.Add(road);
            countDangerSpawn++;

            if (countDangerSpawn >= dangerSpawn)
            {
                Random r = new Random();
                dangerSpawn = r.Next(5, 9);
                countDangerSpawn = 0;
                int obj = r.Next(0, 2);
                switch (obj)
                {
                    case 0:
                        Box box = new Box(new PointF(0 + 100 * 9, 150), new Size(50, 50));
                        boxes.Add(box);
                        break;
                    case 1:
                        Baloon baloon = new Baloon(new PointF(0 + 100 * 9, 150), new Size(50, 50));
                        baloons.Add(baloon);
                        break;
                }
            }
        }

        public static void generateRoad()
        {
            for (int i = 0; i < 10; i++)
            {
                Road road = new Road(new PointF(0 + 100 * i, 200), new Size(100, 17));
                roads.Add(road);
                countDangerSpawn++;
            }
        }

        public static void drawObjects(Graphics g)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].DrawSprite(g);
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                boxes[i].DrawSprite(g);
            }
            for (int i = 0; i < baloons.Count; i++)
            {
                baloons[i].DrawSprite(g);
            }
        }
    }
}
