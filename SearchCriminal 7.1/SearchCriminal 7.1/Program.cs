using System;

namespace SearchCriminal
{
    class Program  
    {
        static void Main(string[] args)
        {
            DatabaseDetective databaseDetective = new DatabaseDetective();
            databaseDetective.Work();
        }
    }

    class DatabaseDetective
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public DatabaseDetective()
        {
            _criminals.Add(new Criminal("Петров Иван Игоревич", "Да", 174, 91, "Русский"));
            _criminals.Add(new Criminal("Шпиц Ляйдер Шанцберг", "Нет", 181, 82, "Немец"));
            _criminals.Add(new Criminal("Русаков Дмитрий Никитович", "Нет", 187, 103, "Русский"));
            _criminals.Add(new Criminal("Алмазов Ильгиз Ибрагимович", "Да", 171, 80, "Казах"));
            _criminals.Add(new Criminal("Аль Пе Ши", "Да", 176, 74, "Француз"));
            _criminals.Add(new Criminal("Хасельков Крис Хемсворт", "Нет", 191, 95, "Американец"));
            _criminals.Add(new Criminal("Ибрагимов Мурат Затулович", "Да", 179, 84, "Кавказец"));
            _criminals.Add(new Criminal("Ашот Хафис Хандирович", "Нет", 181, 82, "Чеченец"));
            _criminals.Add(new Criminal("Борисов Денис Петрович", "Да", 180, 80, "Русский"));
            _criminals.Add(new Criminal("Антонян Давид Арутенянович", "Нет", 187, 103, "Армянин"));
            _criminals.Add(new Criminal("Мухамбетов Канат Мусеевич", "Нет", 191, 95, "Казах"));
        }

        public void Work()
        {
            string commandShowCriminals = "1";
            string commandFindCriminal = "2";
            string commandExit = "3";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("База данных детективов!");
                Console.WriteLine($"\n{commandShowCriminals} - Показать все заключенных\n;{commandFindCriminal} - Найти заключенного;\n" +
                    $"{commandExit} - Выход");
                string userInput = Console.ReadLine();

                if (userInput == commandShowCriminals)
                {
                    ShowCriminals();
                }
                else if (userInput == commandFindCriminal)
                {
                    FindCriminal();
                }
                else if (userInput == commandExit)
                {
                    Console.WriteLine("Вы вышли");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Что то не то вели");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowCriminals()
        {
            Console.WriteLine("\nСписок преступников\n");

            foreach (Criminal criminal in _criminals)
            {
                criminal.ShowDetails();
            }
        }

        private void FindCriminal()   
        {
            string remandedInCustody = "нет";  
            bool isNumber;

            Console.Write("Введите рост преступника: ");
            isNumber = int.TryParse(Console.ReadLine(), out int height);
            Console.Write("Введите вес преступника: ");
            isNumber = int.TryParse(Console.ReadLine(), out int weight);
            Console.WriteLine("Введите национальность: ");
            string nationaliry = Console.ReadLine();

            var foundCriminal = from Criminal criminal in _criminals   
                                where criminal.Height == height && criminal.Weight == weight && criminal.Nationaliry == nationaliry && criminal.RemandedInCustody == remandedInCustody
                                select criminal;
            
            Console.WriteLine("Найден:");

            foreach (Criminal criminal in foundCriminal)
            {
                criminal.ShowDetails();
            }
        }
    }

    class Criminal
    {
        public Criminal(string initials, string remandedInCustody, int height, int weight, string nationaliry)
        {
            Initials = initials;
            RemandedInCustody = remandedInCustody;
            Height = height;
            Weight = weight;
            Nationaliry = nationaliry;
        }

        public string Initials { get; private set; }    
        public string RemandedInCustody { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationaliry { get; private set; }

        public void ShowDetails()
        {
            Console.WriteLine($"ФИО - {Initials} | Заключенный - {RemandedInCustody} | рост - {Height} | вес - {Weight} | " +
                $"национальность - {Nationaliry}");
        }
    }
}
