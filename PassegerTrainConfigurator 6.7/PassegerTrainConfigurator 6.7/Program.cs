using System;

namespace PassengerTrainConfiguration
{
    class Program  
    {
        static void Main(string[] args)
        {
            Station station = new Station();

            bool isWorking = true;
            string menuCreateDirection = "1";
            string menuSellTickets = "2";
            string menuCreateTrain = "3";
            string menuSendTrain = "4";
            string menuExit = "5";

            while (isWorking)
            {
                Console.WriteLine("\nДобро пожаловать В Ж/Д вокзал.");
                Console.WriteLine($"Главное меню:\n{menuCreateDirection} - Создать направление;\n{menuSellTickets} - Продать билеты;\n{menuCreateTrain} - Создать поезд;\n{menuSendTrain} - Отправить поезд;\n{menuExit} - выход из программы");
                Console.Write("\nВведите команду с меню: ");
                string userInput = Console.ReadLine();

                if(userInput == menuCreateDirection)
                {
                    station.CreateDirection();
                }
                else if(userInput == menuSellTickets)
                {
                    station.SellTickets();
                }
                else if(userInput == menuCreateTrain)
                {
                    station.CreateTrain();
                }
                else if(userInput == menuSendTrain)
                {
                    station.SendTrain();
                }
                else if(userInput == menuExit)
                {
                    Console.WriteLine("Вы вели команду завершения программы.");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Вы вели некоректную команду.");
                }

                Console.ReadKey();
            }
        }
    }

    class Train
    {
        private Wagon _wagon = new Wagon();

        public int CountWagon { get; private set; }

        public void CreateTrain()
        {
            CreateCountOfWagon();
            _wagon.NumberPlaceOfWagon();
        }

        public void ShowTrain()
        {
            Console.WriteLine($"Поезд создан. Кол-во вагонов - {CountWagon}, кол-во мест в вагоне - {_wagon.Places}");
            Console.WriteLine($"Всего мест {CountWagon * _wagon.Places}");
        }

        public bool TryBuildTrain(int passagerCount)  
        {
            if(CountWagon * _wagon.Places > passagerCount)
            {
                Console.WriteLine($"Поезд успешно создан и укомплетован.\nВ вагоне свободных {CountWagon * _wagon.Places - passagerCount} мест");
                return true;
            }
            else
            {
                Console.WriteLine($"В поезде не хватило {passagerCount - _wagon.Places * CountWagon} мест пассажирам");
                return false;
            }
        }

        private void CreateCountOfWagon()
        {
            bool isWorking = true;
            int maxCountOfWagon = 15;
            int minCountOfWagon = 1;

            while (isWorking)
            {
                Console.Write($"Введите кол-во вагонов: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int numberCountWagon);

                if (isNumber)
                {
                    if (numberCountWagon > maxCountOfWagon || numberCountWagon < minCountOfWagon)
                    {
                        Console.WriteLine("Ошибка. Столько вагонов нет. Попробуйте вести другое значение");
                    }
                    else
                    {
                        CountWagon = numberCountWagon;
                        Console.WriteLine($"Количество вагонов - {CountWagon}");
                        isWorking = false;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                }
            }
        }
    }

    class Wagon
    {
        public int Places { get; private set; }
        public int CountWagon { get; private set; }

        public void NumberPlaceOfWagon()   
        {
            bool isWorking = true;
            int maxNumberPlaceOfWagon = 100;
            int minNumberPlaceOfWagon = 1;

            while (isWorking)
            {
                Console.Write($"Введите кол-во мест в вагоне: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int numberSeatsOfWagon);

                if (isNumber)
                {
                    if (numberSeatsOfWagon > maxNumberPlaceOfWagon || numberSeatsOfWagon < minNumberPlaceOfWagon)
                    {
                        Console.WriteLine("Ошибка. Мест в одном вагоне не достаточно.");
                    }
                    else
                    {
                        Places = numberSeatsOfWagon;
                        Console.WriteLine($"В вагоне {Places} мест");
                        isWorking = false;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Попробуйте вести другую команду.");
                }
            }
        }
    }

    class Direction
    {
        public Direction(string departurePoint, string arrivePoint)
        {
            DeparturePoint = departurePoint;
            ArrivePoint = arrivePoint;
        }

        public string DeparturePoint { get; private set; }  
        public string ArrivePoint { get; private set; }  
    }

    class Station
    {
        private Random _random = new Random();
        private List<Direction> _directions = new List<Direction>();
        private Train _train = new Train();

        public int SoldTickets { get; private set; } 

        public void CreateDirection()
        {
            int countDirections = 1;

            Console.Write("Введите город, откуда вы собираетесь отправится: ");
            string departurePoint = Console.ReadLine();
            Console.Write("Введите конечную точку: ");
            string arrivePoint = Console.ReadLine();

            if(departurePoint.ToLower() == arrivePoint.ToLower() || _directions.Count >= countDirections)
            {
                Console.WriteLine("Ошибка! Вы вели один и тот же город или направление уже создано.");
            }
            else
            {
                _directions.Add(new Direction(departurePoint, arrivePoint));
                Console.WriteLine("Направление создано!");
                ShowDirection();
            }
        }

        public void ShowDirection()
        {
            foreach (Direction direction in _directions)
            {
                Console.WriteLine($"Начальный пункт - {direction.DeparturePoint} | Конечный пункт - {direction.ArrivePoint}");
            }
        }

        public int SellTickets()  
        {
            int minCountTickets = 0;
            int maxCountTickets = 300;

            if(_directions.Count == 0)
            {
                Console.WriteLine($"Купить билеты невозможно. Направление еще не создано.");
            }
            else
            {
                SoldTickets = _random.Next(minCountTickets, maxCountTickets);
                Console.WriteLine($"Продажа билетов:\n{SoldTickets} билетов продано на этот поезд\n");
                ShowDirection();
            }

            return SoldTickets;
        }

        public void CreateTrain()
        {
            if (TakeTrain() == false) 
            {
                return;
            }
            else
            {
                _train.CreateTrain();
                ShowInfo();
            }
        }

        public void SendTrain()  
        {
            if (_train.TryBuildTrain(SoldTickets))
            {
                if (TakeTrain() == false) 
                {
                    return;
                }
                else
                {
                    ShowInfo();
                    _directions.RemoveAt(0);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void ShowInfo()
        {
            ShowDirection();
            _train.ShowTrain();
            Console.WriteLine("Поезд отправлен.");
            Console.WriteLine($"{SoldTickets} билетов продано на поезд");
            Console.WriteLine("Вы можете создать следующее направление.");
        }

        private bool TakeTrain()
        {
            if (SoldTickets == 0)
            {
                Console.WriteLine("Билет еще не куплены.");
            }
            else if (_directions.Count == 0)
            {
                Console.WriteLine("Не создано направление.");
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}
