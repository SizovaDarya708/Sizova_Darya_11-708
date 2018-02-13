using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Racing
{
    class Interface
    {
        private int speed, score, HIscore, life;
        public Interface(int carSpeed, int playersScore, int hightScore, int playersLife)
        {
            speed = carSpeed; // Скорость машины
            score = playersScore; // Счет игрока
            HIscore = hightScore; // Лучший счет
            life = playersLife; // Жизнь игрока
        }

       
        public void Print(int x, int y)// Вывод на панель информации о статусе игры
        {
            Console.SetCursorPosition(x, y);
            Console.Write("High - score : ");
            Console.Write(HIscore);
            Console.SetCursorPosition(x, y + 2);
            Console.Write("                    ");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("Score : ");
            Console.Write(score);
            Console.SetCursorPosition(x, y + 4);
            Console.Write("Speed : ");
            Console.Write(speed);
            Console.SetCursorPosition(x, y + 6);
            Console.Write("Life : ");
            Console.Write(life);
        } 
        public int getSpeed()
        {
            return speed;
        }
        public void upScore() // Увеличение счета игрока
        {
            score += 10;
            if (score % 1000 == 0)
            {
                speed++; // увеличение скорости машины на 1 при получении 1000 очков
            }
        }
        public void downLife()
        {
            life--;
        }
        public int getLife()
        {
            return life;
        }
        public void setScore(int score_)
        {
            if (score > HIscore) // обновление лучшего счета игры
                HIscore = score;
            score = score_;
        }
        public void setSpeed(int speed_)
        {
            speed = speed_;
        }
       
    }

    class Car
    {
        int left, top;
        public int getLeft()
        {
            return left;
        }
        public int getTop()
        {
            return top;
        }
        public void Down(Map map)
        {
            if (top < 3)
            {
                for (int i = 0; i <= top; i++)
                {
                    map.SetValue(left, top - i, 0);
                    map.SetValue(left + 1, top - i, 0);
                    map.SetValue(left - 1, top - i, 0);
                }
                 top++; 

                map.SetValue(left + 1, top, 1);
                map.SetValue(left - 1, top, 1);
                if (top == 0)
                    return;
                map.SetValue(left, top - 1, 1);
                if (top == 1)
                    return;
                map.SetValue(left, top - 2, 1);
                map.SetValue(left - 1, top - 2, 1);
                map.SetValue(left + 1, top - 2, 1);
                if (top == 2)
                    return;
                map.SetValue(left, top - 3, 1);
                DrawCar(map);
                return;
            }

            if (top >= 3 && top < 19)
            {
                ClearCar(map); 
                top++;
                DrawCar(map);
                return;
            }
            if (top >= 19 && top < 24)
            {
                top++;
                for (int i = top - 4; i <= 19; i++)
                {
                    map.SetValue(left, i, 0);
                    map.SetValue(left + 1, i, 0);
                    map.SetValue(left - 1, i, 0);
                }
                if (top == 20)
                {
                    map.SetValue(left, top - 1, 1);
                    map.SetValue(left, top - 2, 1);
                    map.SetValue(left + 1, top - 2, 1);
                    map.SetValue(left - 1, top - 2, 1);
                    map.SetValue(left, top - 3, 1);
                }
                if (top == 21)
                {
                    map.SetValue(left, top - 2, 1);
                    map.SetValue(left - 1, top - 2, 1);
                    map.SetValue(left + 1, top - 2, 1);
                    map.SetValue(left, top - 3, 1);
                }
                if (top == 22)
                {
                    map.SetValue(left, top - 3, 1);
                }
            }
        }
        public bool Left(Map map)
        {
            if (left == 6 && IsCarCrush(map, 3))
            {
                return true;
            }
            ClearCar(map);
            left = 3;
            DrawCar(map);
            return false;
        }
        public bool Right(Map map)
        {
            if (left == 3 && IsCarCrush(map, 6))
            {
                return true;
            }
            ClearCar(map);
            left = 6;
            DrawCar(map);
            return false;
        }
        public Car(int left_, int top_)
        {
            left = left_;
            top = top_;
        }
        private void ClearCar(Map map)
        {
            map.SetValue(left + 1, top, 0);
            map.SetValue(left - 1, top, 0);
            map.SetValue(left, top - 1, 0);
            map.SetValue(left, top - 2, 0);
            map.SetValue(left + 1, top - 2, 0);
            map.SetValue(left - 1, top - 2, 0);
            map.SetValue(left, top - 3, 0);
        }
        public void DrawCar(Map map)
        {
            ClearCar(map);
            map.SetValue(left + 1, top, 1);
            map.SetValue(left - 1, top, 1);
            map.SetValue(left, top - 1, 1);
            map.SetValue(left, top - 2, 1);
            map.SetValue(left + 1, top - 2, 1);
            map.SetValue(left - 1, top - 2, 1);
            map.SetValue(left, top - 3, 1);
        }
        public bool IsCarCrush(Map map, int left_)
        {
            if (map.GetValue(left_, 19) != 0) return true;
            if (map.GetValue(left_ + 1, 19) != 0) return true;
            if (map.GetValue(left_ - 1, 19) != 0) return true;
            if (map.GetValue(left_, 18) != 0) return true;
            if (map.GetValue(left_ + 1, 18) != 0) return true;
            if (map.GetValue(left_ - 1, 18) != 0) return true;
            if (map.GetValue(left_, 17) != 0) return true;
            if (map.GetValue(left_ - 1, 17) != 0) return true;
            if (map.GetValue(left_ + 1, 17) != 0) return true;
            if (map.GetValue(left_, 16) != 0) return true;
            if (map.GetValue(left_ + 1, 16) != 0) return true;
            if (map.GetValue(left_ - 1, 16) != 0) return true;
            if (map.GetValue(left_, 15) != 0) return true;
            if (map.GetValue(left_ + 1, 15) != 0) return true;
            if (map.GetValue(left_ - 1, 15) != 0) return true;
            return false;
        }
    }
    class Map
    {
        int width, height, road;
        private int[][] map;
        public Map(int width_, int height_)
        {
            width = width_;
            height = height_;
            road = 0;
            map = new int[height][];
            for (int i = 0; i < height; i++)
            {
                map[i] = new int[width];
            }
        }
        public void update()
        {
            for (int i = 19; i > 0; i--)
            {
                SetValue(0, i, GetValue(0, i - 1));
                SetValue(9, i, GetValue(9, i - 1));
            }
            if (road < 3)
            {
                SetValue(0, 0, 0);
                SetValue(9, 0, 0);
            }
            if (road >= 3)
            {
                if (road == 5)
                {
                    road = 0;
                }
                SetValue(0, 0, 1);
                SetValue(9, 0, 1);
            }
            road++;
        }
        public int GetValue(int left, int top)
        {
            return map[top][left];
        }
        public void SetValue(int left, int top, int value)
        {
            map[top][left] = value;
        }
        public void PrintMap() // Рисовка игровой карты
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i][j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("■ ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
    class Racing
    {
        public static bool beep = false;
        public static int freq = 200;
        public static bool IsCrush(Map map, Car player)
        {
            if (map.GetValue(player.getLeft(), 15) != 0) return true;
            if (map.GetValue(player.getLeft() + 1, 15) != 0) return true;
            if (map.GetValue(player.getLeft() - 1, 15) != 0) return true;
            return false;
        }
        private static bool updatePlayer(Car player, Map map, ConsoleKey key) // Управление игроком
        {
            if (key == ConsoleKey.LeftArrow)
            {
                if (player.Left(map))
                {
                    return true;
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if (player.Right(map))
                {
                    return true;
                }
            }
            if (IsCrush(map, player))
            {
                return true;
            }
            return false;
        }
        public static ConsoleKey GetKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable) { Console.ReadKey(true); }

                return keyPressed.Key;
            }

            return ConsoleKey.NoName;
        }
        public static void updateEnemies(List<Car> Enemies, Map map)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Down(map);
                if (Enemies[i].getTop() == 23)
                {
                    Enemies.RemoveAt(i);
                }
            }
        }
        private static void CreateEnemy(List<Car> Enemies) // Лист машин соперников
        {
            Random random = new Random();
            int type = random.Next() % 2;
            if (type == 0)
                Enemies.Add(new Car(3, -1));
            else
                Enemies.Add(new Car(6, -1));
        }
        static void Main()
        {
            Interface interface_ = new Interface(1, 0, 0, 5);
            start:
            if (interface_.getLife() == 0)
                return;
            interface_.setScore(0);
            interface_.setSpeed(1);
            Map map = new Map(10, 20);
            Car Player = new Car(3, 19);
            List<Car> Enemies = new List<Car>();
            Player.DrawCar(map);
            int EnemyCreater = 0, counter = 0, gameLooper = 0;
            while (true)
            {
                beep = true;
                ConsoleKey key = GetKey();
                if (key == ConsoleKey.Spacebar)
                {
                    EnemyCreater += 20;
                    gameLooper += 20;
                }
                if (updatePlayer(Player, map, key))
                {
                    interface_.downLife();
                    goto start;
                }

                if (gameLooper > 20 - interface_.getSpeed() * 2)
                {
                    interface_.upScore();
                    updateEnemies(Enemies, map);
                    map.update();
                    gameLooper = 0;

                }
                if (EnemyCreater > 200)
                {
                    EnemyCreater = 0;
                    CreateEnemy(Enemies);
                }


                EnemyCreater++;
                gameLooper++;
                interface_.Print(25, 5);
                map.PrintMap();
            }
        }
    }
}
