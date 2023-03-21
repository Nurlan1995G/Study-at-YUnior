namespace DataBasePlayers
{
    class Program 
    {
        static void Main(string[] args)
        { 
            Database database = new Database();

            string addPlayer = "1";
            string banPlayer = "2";
            string unbanPlayer = "3";
            string deletePlayer = "4";
            string showInfoPlayer = "5";
            string exit = "6";
            bool isWorking = true;
            
            while (isWorking) 
            {
                Console.WriteLine($"Введите команду с меню!");
                Console.WriteLine($"\n{addPlayer} - Добавление персонажа;\n{banPlayer} - Забанить персонажа;\n{unbanPlayer} - Разбанить персонажа;\n{deletePlayer} - Удалить персонажа;\n{showInfoPlayer} - Вывод информации о всех персонажах;\n{exit} - выход из программы.\n");
                string userInput = Console.ReadLine();
                bool isNumber = int.TryParse(userInput, out int number);

                if (isNumber)
                {
                    if (userInput == addPlayer)
                    {
                        database.AddPlayer();
                    }
                    else if (userInput == banPlayer)
                    {
                        database.BanPlayer();
                    }
                    else if (userInput == unbanPlayer)
                    {
                        database.UnbanPlayer();
                    }
                    else if (userInput == deletePlayer)
                    {
                        database.DeletePlayer();
                    }
                    else if (userInput == showInfoPlayer)
                    {
                        database.ShowAllInfoPlayer();
                    }
                    else if (userInput == exit)
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

        public Player(string nickName, int level)
        {
            NickName = nickName;
            Level = level;
            isBanned = false;
            CreateNumber();
        }

        public string NickName { get; private set; }
        public int Level { get; private set; }
        public bool isBanned { get; private set; }
        public int UniqueNumber { get; private set; }

        public void CreateNumber()
        {
            UniqueNumber = ++_number;
        }

        public void Ban()
        {
            isBanned = true;
            Console.WriteLine("Пользователь забанен!");
        }

        public void Unban()
        {
            isBanned = false;
            Console.WriteLine("Пользователь разбанен!");
        }

        public void ShowInfo()
        {
            if (isBanned)
            {
                Console.WriteLine("\nПользователь забанен!");
            }
            else
            {
                Console.WriteLine("\nНе забанен!");
            }

            Console.WriteLine($"Уникальный номер - {UniqueNumber} | Ник - {NickName} | уровень - {Level}");
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

        public bool TryGetPlayer(out Player player)
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
