using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public class PilotGame
    {
        struct Enemy
        {
            public int x;
            public int y;
            public int speed;

            public string[] enemyChar = new string[]
            {
                "  w  ",
                "-{#}-",
                " \\/  "
            };

            public Enemy(int X, int Y)
            {
                x = X;
                y = Y;
                speed = 1;
            }
        }

        struct Projectile
        {
            public int x;
            public int y;
            public int speed;

            public string[] projectileChar = new string[]
            {
                "\\./",
                " | ",
                " V "
            };

            public Projectile(int X, int Y)
            {
                x = X;
                y = Y;
                speed = 1;
            }
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////

        private int _lives;
        private int _playerX;
        private int _playerY;
        public string[] PlayerChar = new string[]
        {
            "  ▲  ",
            "<-#->",
            " \\w/ "
        };

        List<Enemy> enemies = new List<Enemy>();
        List<Projectile> projectiles = new List<Projectile>();

        public PilotGame()
        {
            Lives = 3;
            PlayerX = Console.WindowWidth / 2;
            PlayerY = Console.WindowHeight / 2;
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int PlayerX
        {
            get { return _playerX; }
            set { _playerX = value; }
        }

        public int PlayerY
        {
            get { return _playerY; }
            set { _playerY = value; }
        }

        public void CharMovement()
        {
            while (Lives > 0)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        PlayerY++;
                        break;
                    case ConsoleKey.S:
                        PlayerY--;
                        break;
                    case ConsoleKey.D:
                        PlayerX++;
                        break;
                    case ConsoleKey.A:
                        PlayerX--;
                        break;
                }
            }
        }

        public void Draw()
        {

        }
    }
}
