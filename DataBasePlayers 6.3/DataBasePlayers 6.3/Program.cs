namespace DataBasePlayers
{
    class Program 
    {
        static void Main(string[] args)
        { 
            DataBase dataBase = new DataBase();

            string AddPlayer = "1";
            string BanPlayer = "2";
            string UnBanPlayer = "3";
            string DeletePlayer = "4";
            string ShowInfoPlayer = "5";
            string Exit = "6";
            bool isWorking = true;
            
            while (isWorking) 
            {
                Console.WriteLine($"Введите команду с меню!");
                Console.WriteLine($"\n{AddPlayer} - Добавление персонажа;\n{BanPlayer} - Забанить персонажа;\n{UnBanPlayer} - Разбанить персонажа;\n{DeletePlayer} - Удалить персонажа;\n{ShowInfoPlayer} - Вывод информации о всех персонажах;\n{Exit} - выход из программы.");
                string userInput = Console.ReadLine();
                bool isNumber = int.TryParse(userInput, out int number);

                if (isNumber)
                {
                    if (userInput == AddPlayer)
                    {
                        dataBase.AddPlayer();
                    }
                    else if (userInput == BanPlayer)
                    {
                        dataBase.BanPlayer();
                    }
                    else if (userInput == UnBanPlayer)
                    {
                        dataBase.UnBanPlayer();
                    }
                    else if (userInput == DeletePlayer)
                    {
                        dataBase.DeletePlayer();
                    }
                    else if (userInput == ShowInfoPlayer)
                    {
                        dataBase.ShowAllInfoPlayer();
                    }
                    else if (userInput == Exit)
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

        public string NickName { get; private set; }
        public int LevelPlayer { get; private set; }
        public bool isBan { get; private set; }
        public int UniqueNumberPlayer { get; private set; }

        public Player(string nickName, int levelPlayer)
        {
            NickName = nickName;
            LevelPlayer = levelPlayer;
            isBan = false;
            CreateNumber();
        }

        public void CreateNumber()
        {
            UniqueNumberPlayer = ++_number;
        }

        public void Ban()
        {
            isBan = true;
        }

        public void UnBan()
        {
            isBan = false;
        }

        public void ShowInfo()
        {
            if (isBan)
            {
                Console.WriteLine("\nПользователь забанен!");
            }
            else
            {
                Console.WriteLine("\nНе забанен!");
            }

            Console.WriteLine($"Уникальный номер - {UniqueNumberPlayer} | Ник - {NickName} | уровень - {LevelPlayer}");
        }
    }


    class DataBase
    {
        Random random = new Random();
        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            Console.Write("Введите ваш ник:");
            string nickPlayer = Console.ReadLine();
            bool isnickPlayer = int.TryParse(nickPlayer, out int number);
            int minValue = 1;
            int maxValue = 11;

            int levelPlayer = random.Next(minValue, maxValue);

            _players.Add(new Player(nickPlayer, levelPlayer));
        }

        public void DeletePlayer()
        {
            if(GetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine($"\nИгрок с номером {player.UniqueNumberPlayer} удален!");
            }
            else
            {
                Console.WriteLine("Такого номера нет!");
            }
        }

        public void BanPlayer()
        {
            if(GetPlayer(out Player player))
            {
                player.Ban();
            }
            else
            {
                Console.WriteLine("Такого пользователья нет. Нет возможности забанить!");
            }
        }

        public void UnBanPlayer()
        {
            if(GetPlayer(out Player player))
            {
                player.UnBan();
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

        public bool GetPlayer(out Player player)
        {
            player = null;

            Console.Write("Введите уникальный номер игрока: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int uniqueNumberToFind);

            if (isNumber)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (uniqueNumberToFind == _players[i].UniqueNumberPlayer)
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
