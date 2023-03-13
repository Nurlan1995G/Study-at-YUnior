using System;
using System.Reflection.Metadata;
using System.Collections.Generic;

namespace DataBasePlayers
{
    class Program  //Реализовать базу данных игроков и методы для работы с ней.
                   //У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool).
                   //Реализовать возможность добавления игрока, бана игрока по уникальный номеру, разбана игрока по уникальный номеру и удаление игрока.
                   //Создание самой БД не требуется, задание выполняется инструментами, которые вы уже изучили в рамках курса.Но нужен класс, который содержит игроков и её можно назвать "База данных".
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
                bool isUserNumber = int.TryParse(userInput, out int number);

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
                else if(userInput == ShowInfoPlayer)
                {
                    dataBase.ShowAllInfoPlayer();
                }
                else if (userInput == Exit)
                {
                    isWorking = false;
                }
                else
                {
                    isUserNumber = false;
                    Console.WriteLine("Вы вели некоректную команду!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }

    class DataBase
    {
        Random random = new Random();
        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            Console.Write("Введите ник вашего персонажа: ");
            string userInputNick = Console.ReadLine();
            int level = random.Next(1, 11);

            _players.Add(new Player(userInputNick, level));
        }

        public void DeletePlayer()
        {
            if(TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine("\nПользователь удален!\n");
            }
            else
            {
                Console.WriteLine("Такого персонажа нет!");
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
                Console.WriteLine("Такого персонажа нет!");
            }
        }

        public void UnBanPlayer()
        {
            if(TryGetPlayer(out Player player))
            {
                player.UnBan();
            }
            else
            {
                Console.WriteLine("Такого персонажа нет!");
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
                Console.WriteLine("Еще нет пользователей!");
            }
        }

        public bool TryGetPlayer(out Player player)
        {
            player = null;

            Console.Write("Введите номер игрока для продолжения операции: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < _players.Count; i++)
            {
                if(userInput == _players[i].UniqueNumberPlayer)
                {
                    player = _players[i];
                    return true;
                }
            }

            return false;
        }

        public void CheckInfo()
        {
            
        }
    }


    class Player
    {
        private static int _number;
        public Player( string namePlayer, int levelPlayer)
        {
            NickPlayer = namePlayer;
            LevelPlayer = levelPlayer;
            IsBan = false;
            IncreaseNumber();
        }

        public int UniqueNumberPlayer { get; private set; }
        public string NickPlayer { get; private set; }
        public int LevelPlayer { get; private set; }
        public bool IsBan { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер - {UniqueNumberPlayer} | Ник пользователя - {NickPlayer} | Уровень - {LevelPlayer}");

            if (IsBan)
            {
                Console.WriteLine("Пользователь забанен!\n");
            }
            else
            {
                Console.WriteLine("Пользователь не забанен!\n");
            }
        }

        public void Ban()
        {
            IsBan = true;
        }

        public void UnBan()
        {
            IsBan = false;
        }

        public void IncreaseNumber()
        {
            UniqueNumberPlayer = ++_number; ;
        }
    }
}
