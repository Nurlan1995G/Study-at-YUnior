using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();

            Console.Write("Введите координаты по Х: ");
            int playerPositionX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите координаты по Y: ");
            int playerPositionY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите символ вашего персонажа и он будет виден на карте: ");
            char playerSymbol = Convert.ToChar(Console.ReadLine());

            Player player = new Player(playerPositionX, playerPositionY, playerSymbol);

            renderer.DrawPlayer(player.PlayerPositionX, player.PlayerPositionY, player.PlayerSymbol);
        }
    }

    class Renderer
    {
        public void DrawPlayer(int playerX, int playerY, char symbol)
        {
            Console.SetCursorPosition(playerY, playerX);
            Console.Write(symbol);
        }
    }

    class Player
    {
        public int PlayerPositionX { get; private set; }

        public int PlayerPositionY { get; private set; }

        public char PlayerSymbol { get; private set; }

        public Player(int playerPositionX, int playerPositionY, char playerSymbol)
        {
            PlayerPositionX = playerPositionX;
            PlayerPositionY = playerPositionY;
            PlayerSymbol = playerSymbol;
        }
    }
}
