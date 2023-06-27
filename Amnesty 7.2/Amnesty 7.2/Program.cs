using System;

namespace TaskAmnesty
{
    class Program  
    {
        static void Main(string[] args)
        {
            Jail jain = new Jail();
            jain.Work();
        }
    }

    class Jail
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Jail()
        {
            _criminals.Add(new Criminal("Иван Иванович Петров", "Антиправительственное"));
            _criminals.Add(new Criminal("Вова Викторович Колбасин", "Уголовное"));
            _criminals.Add(new Criminal("Вадим Петрович Хлебкин", "Антиправительственное"));
            _criminals.Add(new Criminal("Алам Алимович Абахин", "Уголовное"));
            _criminals.Add(new Criminal("Сергей Алексеевич Федоров", "Антиправительственное"));
            _criminals.Add(new Criminal("Виктор Сергеевич Соловьёв", "Административное"));
            _criminals.Add(new Criminal("Султан Никитович Носков", "Антиправительственное"));
            _criminals.Add(new Criminal("Кирилл Николаевич Юдин", "Уголовное"));
            _criminals.Add(new Criminal("Алексей Викторович Папонин", "Антиправительственное"));
            _criminals.Add(new Criminal("Алах Аламович Алахич", "Административное"));
            _criminals.Add(new Criminal("Армен Арменович Аринян", "Антиправительственное"));
            _criminals.Add(new Criminal("Александр Тимурович Гарбов", "Уголовное"));
            _criminals.Add(new Criminal("Пётр Александрович Головач", "Антиправительственное"));
        }

        public void Work()
        {
            string commandShowToAmnesty = "1";
            string commandShowCriminalToAmnesty = "2";
            string commandShowAfterAmnesty = "3";
            string commandExit = "4";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("В стране Арстоцка произошла Амнистия");
                Console.WriteLine($"\n{commandShowToAmnesty} - Тюрьма до Амнистии;\n{commandShowCriminalToAmnesty} - Тюрьма после Амнистии;\n" + $"{commandShowAfterAmnesty} - Показать Амнистии;\n{commandExit} - Выход");
                Console.Write("Ввыберете с меню: ");
                string userInput = Console.ReadLine();

                if(userInput == commandShowToAmnesty)
                {
                    ShowToAmnesty();
                }
                else if(userInput == commandShowCriminalToAmnesty)
                {
                    ShowCriminalAfterAmneste();
                }
                else if(userInput == commandShowAfterAmnesty)
                {
                    ShowAfterAmnesty();
                }
                else if(userInput == commandExit)
                {
                    Console.WriteLine("Выход из программы");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Вы вели что-то не то");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowToAmnesty()
        {
            foreach (Criminal criminal in _criminals)
            {
                criminal.ShowDetail();
            }
        }

        private void ShowCriminalAfterAmneste()   
        {
            string crime = "Антиправительственное";

            var criminalAfterAmnesty = _criminals.Where(criminal => criminal.Crime != crime);

            foreach (Criminal crim in criminalAfterAmnesty)
            {
                crim.ShowDetail();
            }
        }

        private void ShowAfterAmnesty()  
        {
            string crime = "Антиправительственное";

            var afterAmnesty = _criminals.Where(criminal => criminal.Crime == crime);

            foreach (Criminal crim in afterAmnesty)
            {
                crim.ShowDetail();
            }
        }
    }

    class Criminal
    {
        public Criminal(string iniciality, string crime)
        {
            Iniciality = iniciality;
            Crime = crime;
        }

        public string Iniciality { get;private set; }
        public string Crime { get; private set; }

        public void ShowDetail()
        {
            Console.WriteLine($"Заключенный - {Iniciality}, сидит за -- <{Crime}>");
        }
    }
}
