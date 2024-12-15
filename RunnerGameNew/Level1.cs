using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RunnerGame.Classes;

namespace RunnerGame
{
    public partial class Level1 : Form
    {
        Player player;
        Timer mainTimer;

        public Level1()
        {
            InitializeComponent();

            this.Width = 700;
            this.Height = 300;
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(drawGame);
            this.KeyUp += new KeyEventHandler(onKeyBoardUp);
            this.KeyDown += new KeyEventHandler(onKeyBoardDown);
            mainTimer = new Timer();
            mainTimer.Interval = 10;
            mainTimer.Tick += new EventHandler(Update);
            Init();
        }

        private void onKeyBoardDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (!player.physics.isJumping)
                    {
                        player.physics.isCrouching = true;
                        player.physics.isJumping = false;
                        player.physics.transform.size.Height = 25;
                        player.physics.transform.position.Y = 174;
                    }
                    break;
            }
        }
        private void onKeyBoardUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!player.physics.isCrouching)
                    {
                        player.physics.isCrouching = false;
                        player.physics.addForce();
                    }
                    break;
                case Keys.Down:
                    player.physics.isCrouching = false;
                    player.physics.transform.size.Height = 50;
                    player.physics.transform.position.Y = 150.2f;
                    break;
            }
        }

        public void Init()
        {
            GameController.Init();
            player = new Player(new PointF(50, 149), new Size(50, 50));
            mainTimer.Start();
            Invalidate();
        }

        public void Update(object sender, EventArgs e)
        {
            player.score++;
            this.Text = "Cat - Score: " + player.score;
            if (player.physics.collide())
                Init();
            player.physics.ApplyPhysics();
            GameController.moveMap();
            Invalidate();
        }

        private void drawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.drawSprite(g);
            GameController.drawObjects(g);
        }

        private void Level1_Load(object sender, EventArgs e)
        {

        }
    }
}
