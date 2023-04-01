namespace DataBasePlayers
{
    class Program 
    {
        static void Main(string[] args)
        { 
            Database database = new Database();

            string commandAddPlayer = "1";
            string commandBanPlayer = "2";
            string commandUnbanPlayer = "3";
            string commandDeletePlayer = "4";
            string commandShowInfoPlayer = "5";
            string commandExit = "6";
            bool isWorking = true;
            
            while (isWorking) 
            {
                Console.WriteLine($"Введите команду с меню!");
                Console.WriteLine($"\n{commandAddPlayer} - Добавление персонажа;\n{commandBanPlayer} - Забанить персонажа;\n{commandUnbanPlayer} - Разбанить персонажа;\n{commandDeletePlayer} - Удалить персонажа;\n{commandShowInfoPlayer} - Вывод информации о всех персонажах;\n{commandExit} - выход из программы.\n");
                string userInput = Console.ReadLine();
                bool isNumber = int.TryParse(userInput, out int number);

                if (isNumber)
                {
                    if (userInput == commandAddPlayer)
                    {
                        database.AddPlayer();
                    }
                    else if (userInput == commandBanPlayer)
                    {
                        database.BanPlayer();
                    }
                    else if (userInput == commandUnbanPlayer)
                    {
                        database.UnbanPlayer();
                    }
                    else if (userInput == commandDeletePlayer)
                    {
                        database.DeletePlayer();
                    }
                    else if (userInput == commandShowInfoPlayer)
                    {
                        database.ShowAllInfoPlayer();
                    }
                    else if (userInput == commandExit)
                    {
                        Console.WriteLine("\nВы вели команду выхода из программы!");
                        isWorking = false;
                    }
                }
                else
                {
                    Console.WriteLine("\nЧто-то вы вели не то. Попробуйте еще раз!\n");
                    Console.ReadKey();
                }

                Console.WriteLine("Нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        private static int _number;
        private string _nickName;
        private int _level;
        private bool _isBanned;

        public Player(string nickName, int level)
        {
            _nickName = nickName;
            _level = level;
            _isBanned = false;
            CreateNumber();
        }

        public int UniqueNumber { get; private set; }

        private void CreateNumber()
        {
            UniqueNumber = ++_number;
        }

        public void Ban()
        {
            _isBanned = true;
            Console.WriteLine("Пользователь забанен!");
        }

        public void Unban()
        {
            _isBanned = false;
            Console.WriteLine("Пользователь разбанен!");
        }

        public void ShowInfo()
        {
            if (_isBanned)
            {
                Console.WriteLine("\nПользователь забанен!");
            }
            else
            {
                Console.WriteLine("\nНе забанен!");
            }

            Console.WriteLine($"Уникальный номер - {UniqueNumber} | Ник - {_nickName} | уровень - {_level}");
        }
    }

    class Database
    {
        private Random _random = new Random();
        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            Console.Write("Введите ваш ник:");
            string nickPlayer = Console.ReadLine();
            int minValue = 1;
            int maxValue = 11;

            int levelPlayer = _random.Next(minValue, maxValue);

            _players.Add(new Player(nickPlayer, levelPlayer));
        }

        public void DeletePlayer()
        {
            if(TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine($"\nИгрок с номером {player.UniqueNumber} удален!");
            }
            else
            {
                Console.WriteLine("Такого номера нет!");
            }
        }

        public void BanPlayer()
        {
            if(TryGetPlayer(out Player player))
            {
                player.Ban();
            }
            else
            {
                Console.WriteLine("Такого пользователья нет. Нет возможности забанить!");
            }
        }

        public void UnbanPlayer()
        {
            if(TryGetPlayer(out Player player))
            {
                player.Unban();
            }
            else
            {
                Console.WriteLine("Разбанить не получилось, может его просто нет!");
            }
        }

        public void ShowAllInfoPlayer()
        {
            if (_players.Count != 0)
            {
                foreach (Player player in _players)
                {
                    player.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("У вас пока нет ни одного игрока!");
            }
        }

        private bool TryGetPlayer(out Player player)
        {
            player = null;

            Console.Write("Введите уникальный номер игрока: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int uniqueNumberToFind);

            if (isNumber)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (uniqueNumberToFind == _players[i].UniqueNumber)
                    {
                        player = _players[i];
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы вели неверную команду. Попробуйте еще раз!");
                Console.ReadKey();
            }

            return false;
        }
    }
}
