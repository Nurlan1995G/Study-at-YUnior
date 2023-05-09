using System;

namespace BraveNewWorld
{
    class Program  
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isWorking = true;
            int userPositionX;
            int userPositionY;
            int userDirectionX = 0;
            int userDirectionY = 0;
            int allDots = 0;
            int collectDots = 0;

            char[,] map = RedMap(out userPositionX, out userPositionY, ref allDots);
            DrawMap(map);

            while (isWorking)
            {
                Console.SetCursorPosition(0, 15);
                Console.WriteLine($"Собрано ягод - {collectDots} из {allDots}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref userDirectionX, ref userDirectionY);

                    if (map[userPositionX + userDirectionX, userPositionY + userDirectionY] != '#')
                    {
                        Move(ref userPositionX, ref userPositionY, userDirectionX, userDirectionY);

                        CollectDots(map, userPositionX, userPositionY, ref collectDots);
                    }
                }

                if(collectDots == allDots)
                {
                    Console.Clear();
                    Console.WriteLine("Конец игры. Все ягоды собраны!");
                    isWorking = false;
                }
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY) 
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;    
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
            }
        }

        static void Move(ref int positionX, ref int positionY, int directionX, int directionY)  
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(" ");

            positionX += directionX;
            positionY += directionY;

            Console.SetCursorPosition(positionY,positionX);
            Console.Write('@');
        }

        static void CollectDots(char[,] map, int positionX, int positionY, ref int collectDots)  
        {
            if (map[positionX,positionY] == '*')
            {
                collectDots++;
                map[positionX, positionY] = ' ';
            }
        }

        static char[,] RedMap(out int positionX,out int positionY, ref int allDots)    
        {
            positionX = 0;
            positionY = 0;

            char[,] map =
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', '*', '#', ' ', ' ', '*', '#', ' ', '*', ' ', '#', ' ', '*', '#', '#'},
                {'#', ' ', ' ', '*', '#', ' ', ' ', ' ', '#', ' ', '*', '#', '@', ' ', '#'},
                {'#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '*', '#'},
                {'#', '*', ' ', '#', ' ', '*', ' ', ' ', ' ', ' ', '*', '#', ' ', ' ', '#'},
                {'#', '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#', '#', ' ', '#', '#'},
                {'#', '*', ' ', ' ', ' ', '#', ' ', ' ', '*', ' ', ' ', ' ', ' ', '*', '#'},
                {'#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', '*', ' ', ' ', ' ', ' ', ' ', '*', ' ', '#', ' ', '*', ' ', '#'},
                {'#', ' ', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', '#', '#', ' ', '#'},
                {'#', ' ', ' ', '#', '*', ' ', '#', ' ', ' ', ' ', ' ', ' ', '*', ' ', '#'},
                {'#', '#', ' ', '#', '#', '#', '#', ' ', '#', '#', '#', '#', ' ', '#', '#'},
                {'#', ' ', '*', ' ', ' ', '#', '*', ' ', ' ', '*', '#', ' ', ' ', '*', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == '@')
                    {
                        positionX = i;
                        positionY = j;
                    }
                    else if (map[i,j] == '*')
                    {
                        allDots++; 
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)   
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}