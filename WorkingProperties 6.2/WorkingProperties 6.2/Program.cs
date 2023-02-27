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
        private int _playerPositionX;
        private int _playerPositionY;
        private char _playerSymbol;

        public int PlayerPositionX
        {
            get { return _playerPositionX; }
            private set { _playerPositionX = value; }
        }

        public int PlayerPositionY
        {
            get { return _playerPositionY; }
            private set { _playerPositionY = value; }
        }

        public char PlayerSymbol
        {
            get { return _playerSymbol; }
            private set { _playerSymbol = value; }  
        }

        public Player(int playerPositionX, int playerPositionY, char playerSymbol)
        {
            _playerPositionX = playerPositionX;
            _playerPositionY = playerPositionY;
            _playerSymbol = playerSymbol;
        }
    }
}
