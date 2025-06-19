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
            public double x;
            public double y;

            public double dx;
            public double dy;

            public int speed;

            public string[] projectileChar = new string[]
            {
                "\\./",
                " | ",
                " V "
            };

            public Projectile(double startX, double startY, int playerX, int playerY)
            {
                x = startX;
                y = startY;

                double diffX = playerX - startX;
                double diffY = playerY - startY;

                double length = Math.Sqrt(diffX * diffX + diffY * diffY);
                dy = diffX / length;
                dx = diffY / length;
                speed = 1;
            }

            public void Update()
            {
                x += dx;
                y += dy;
            }

            public int IntX => (int)Math.Round(x);
            public int IntY => (int)Math.Round(y);
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

        private int _frameCount;
        private int _difficultyLevel;
        private int _spawnRate;

        private Random rand;

        List<Enemy> enemies = new List<Enemy>();
        List<Projectile> projectiles = new List<Projectile>();

        public PilotGame()
        {
            _lives = 3;
            _playerX = Console.WindowWidth / 2;
            _playerY = Console.WindowHeight / 2;

            _difficultyLevel = 0;
        }

        public void CharMovement()
        {
            while (_lives > 0)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        _playerY++;
                        break;
                    case ConsoleKey.S:
                        _playerY--;
                        break;
                    case ConsoleKey.D:
                        _playerX++;
                        break;
                    case ConsoleKey.A:
                        _playerX--;
                        break;
                }
            }
        }

        public void StartGame()
        {
            Task.Run(() => CharMovement()); // Ensure player movement is still checked in a separate task loop

            while (_lives > 0)
            {
                _frameCount++;

                UpdateDifficulty();
                SpawnProjectiles();
                UpdateProjectiles();
            }
        }

        public void UpdateDifficulty()
        {
            if (_frameCount % 500 == 0)
            {
                _difficultyLevel++;

                _spawnRate = Math.Max(10, _spawnRate - 5);
            }
        }

        public void SpawnProjectiles()
        {
            if (_frameCount % _spawnRate == 0)
            {
                double projX = rand.Next(0, Console.WindowWidth);
                double projY = rand.Next(0, Console.WindowHeight);

                Projectile projectile = new Projectile(projX, projY, _playerX, _playerY);
                projectiles.Add(projectile);
            }
        }

        public void UpdateProjectiles()
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.Update();
            }

            projectiles.RemoveAll(p => p.IntX < 0 || p.IntX >= Console.WindowWidth || p.IntY < 0 || p.IntY >= Console.WindowWidth);
        }

        public void Draw()
        {

        }
    }
}
