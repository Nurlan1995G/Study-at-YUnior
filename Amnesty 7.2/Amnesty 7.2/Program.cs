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
            string antiGovernmentCrime = "Антиправительственное";

            Console.WriteLine("\nСписок заключенных до Амнистии: \n");
            ShowToAmnesty();

            FreeCriminalsAfterAmnesty(antiGovernmentCrime);

            Console.WriteLine("\nСписок заключенных после амнистии: \n");
            ShowToAmnesty();
        }

        private void ShowToAmnesty()
        {
            foreach (Criminal criminal in _criminals)
            {
                criminal.ShowDetail();
            }
        }

        private void FreeCriminalsAfterAmnesty(string antiGovernmetnCrime)   
        {
            _criminals = _criminals.Where(criminal => criminal.Crime != antiGovernmetnCrime).ToList();
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
