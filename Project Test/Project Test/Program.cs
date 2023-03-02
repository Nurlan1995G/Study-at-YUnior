using System;
using System.Drawing;

namespace Program
{
    class ProgramTest
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            ComputerClub computerClub = new ComputerClub(8, random);
            computerClub.Work();
        }
    }

    class ComputerClub
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Schoolboy> _schoolboys = new Queue<Schoolboy>();

        public ComputerClub(int computerCount, Random random)
        {
            for (int i = 0; i < computerCount; i++)
            {
                _computers.Add(new Computer(random.Next(5, 15)));
            }

            CreateNewSchoolboy(25);
        }

        private void CreateNewSchoolboy(int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                _schoolboys.Enqueue( new Schoolboy(random.Next(100, 250),random));
            }
        }

        public void Work()
        {
            while(_schoolboys.Count > 0)
            {
                Console.WriteLine($"Компьтерный клуб, в кассе {_money} рублей. Добро пожаловать!");
                Schoolboy schoolboy = _schoolboys.Dequeue();
                Console.WriteLine($"В очереди находится школьник, он хочет приобрести {schoolboy.DesiredMinutes} минут");
                Console.WriteLine("\nСписок компьютеров: ");
                ShowAllComputers();

                Console.Write("\nвы предлагается пк под номером - ");
                int computerNumber = Convert.ToInt32(Console.ReadLine());

                if(computerNumber >= 0 && computerNumber < _computers.Count)
                {
                    if (_computers[computerNumber].isBusy)
                    {
                        Console.WriteLine("Вы предложили клиенту компьютер, который уже занят. Клиент ушел.");
                    }
                    else
                    {
                        if (schoolboy.CheckSolvancy(_computers[computerNumber]))
                        {
                            Console.WriteLine("Пересчитав деньги, клиент оплатил покупку и сел за компьютер");
                            _money += schoolboy.ToPay();

                            _computers[computerNumber].TakeThePlace(schoolboy);
                        }
                        else
                        {
                            Console.WriteLine("У клиента не хватило денег. Он ушел!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы сами не понимаете за какой комп его посадить.");
                }

                Console.WriteLine("Для того, чтобы перейти к новуму клиенту, нажмите на любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                SkipMinute();
            }
        }

        public void SkipMinute()
        {
            foreach (var computer in _computers)
            {
                computer.SkipMinutes();
            }
        }


        private void ShowAllComputers()
        {
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write($"{i} - ");
                _computers[i].ShowInfo();
            }
        }
    }

    class Computer
    {
        private Schoolboy _schoolboy;
        private int _minutesLeft;

        public int PriceForMinutes { get; private set; }
        public bool isBusy
        {
            get
            {
                return _minutesLeft > 0;
            }
        }

        public Computer(int priceForMinutes)
        {
            PriceForMinutes = priceForMinutes;
        }

        public void TakeThePlace(Schoolboy schoolboy)
        {
            _schoolboy = schoolboy;
            _minutesLeft = schoolboy.DesiredMinutes;
        }

        public void FreeThePlace()
        {
            _schoolboy = null;
        }

        public void SkipMinutes()
        {
            _minutesLeft--;
        }
        
        public void ShowInfo()
        {
            if(isBusy)
                Console.WriteLine($"Компьютер занят. Осталось - {_minutesLeft} минут");
            else
            {
                Console.WriteLine($"Компьтер свободен. Цена за минуту - {PriceForMinutes}");
            }
        }
    }

    class Schoolboy
    {
        private int _money;
        private int _moneyToPay;

        public int DesiredMinutes { get; private set; }

        public Schoolboy(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(10, 31);
        }

        public bool CheckSolvancy(Computer computer)
        {
            _moneyToPay = computer.PriceForMinutes * DesiredMinutes;

            if (_money >= _moneyToPay)
            {
                return true;
            }
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public int ToPay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}