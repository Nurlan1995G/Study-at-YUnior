using System;

namespace TopPlayersServer
{
    class Program  
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Work();
        }
    }

    class Server
    {
        private Random _random = new Random();
        private List<Player> _players = new List<Player>();

        public Server()
        {
            _players.Add(new Player("Пинки",GetLevel(),GetPower()));
            _players.Add(new Player("Хрюша", GetLevel(), GetPower()));
            _players.Add(new Player("Крош", GetLevel(), GetPower()));
            _players.Add(new Player("Ежик", GetLevel(), GetPower()));
            _players.Add(new Player("Локи", GetLevel(), GetPower()));
            _players.Add(new Player("Тор", GetLevel(), GetPower()));
            _players.Add(new Player("Халк", GetLevel(), GetPower()));
            _players.Add(new Player("Мелкий", GetLevel(), GetPower()));
            _players.Add(new Player("Железный человек", GetLevel(), GetPower()));
            _players.Add(new Player("Человек паук", GetLevel(), GetPower()));
            _players.Add(new Player("Зимний солдат", GetLevel(), GetPower()));
            _players.Add(new Player("Танос", GetLevel(), GetPower()));
        }

        public void Work()
        {
            const string commandShowToLevel = "1";
            const string commandShowToPower = "2";
            const string commandExit = "3";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Ну что по чем, по порядку что ли?");
                Console.WriteLine($"\n{commandShowToLevel} - Показать определение 3 игроков по уровню;\n{commandShowToLevel} - Показать определение 3 игроков по силе;\n{commandExit} - выход\n");
                Console.Write("Введите номер команды: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case commandShowToLevel:
                        ShowFindToLevel();
                        break;
                    case commandShowToPower:
                        ShowFindToPower();
                        break;
                    case commandExit:
                        Console.WriteLine("Выход из программы");
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Вы вели что-то не то");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowFindToLevel()
        {
            int topPlayers = 3;
            var playerLevel = _players.OrderByDescending(player => player.Level).Take(topPlayers).ToList();
            Console.WriteLine($"Топ {topPlayers} по уровню");
            ShowInfo(playerLevel);
        }

        private void ShowFindToPower()
        {
            int topPlayers = 3;
            var playerPower = _players.OrderByDescending(player => player.Power).Take(topPlayers).ToList();
            Console.WriteLine($"Топ {topPlayers} по силе");
            ShowInfo(playerPower);
        }

        private void ShowInfo(List<Player> players)
        {
            foreach (Player player in players)
            {
                player.ShowDetail();
            }
        }

        private int GetLevel()
        {
            int minLevel = 5;
            int maxLevel = 50;
            int level = _random.Next(minLevel,maxLevel);
            return level;
        }

        private int GetPower()
        {
            int minPower = 30;
            int maxPower = 100;
            int power = _random.Next(minPower,maxPower);
            return power;
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public void ShowDetail()
        {
            Console.WriteLine($"Имя - {Name} | Уровень - {Level} | Сила - {Power}");
        }
    }
}
