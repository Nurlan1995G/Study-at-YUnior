using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

namespace Task
{
    class Program  
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            string commandAddFish = "1";
            string commandRemoveFishFromAquarium = "2";
            string commandExit = "3";
            bool isWorking = true;

            while (isWorking)
            {
                aquarium.ShowFishes();
                Console.WriteLine($"\n---- Аквариум ----\n{commandAddFish} - Добавить рыбу;\n{commandRemoveFishFromAquarium} - Убрать рыбу из аквариума;" +
                    $"\n{commandExit} - Выход");
                string userInput = Console.ReadLine();

                if(userInput == commandAddFish)
                {
                    aquarium.AddFish();
                }
                else if(userInput == commandRemoveFishFromAquarium)
                {
                    aquarium.RemoveFish();
                }
                else if(userInput == commandExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Вы вели некоректную команду.");
                }

                aquarium.UpdateAgeFish();
                aquarium.RemoveDeadFish();
                Console.WriteLine("Нажмите на любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();
        private int _maxCountFish = 5;

        public Aquarium()
        {
            _fishes.Add(new Fish("Гордон", 2));
        }

        public void AddFish()
        {
            if (_maxCountFish <= _fishes.Count)
            {
                Console.Clear();
                Console.WriteLine("В аквариуме нет места");
                Console.ReadKey();
            }
            else
            {
                _fishes.Add(new Fish(GetName(), GetAge()));
            }
        }

        public void RemoveFish()
        {
            if(TryGetFish(out Fish fish))
            {
                Console.WriteLine("Рыбка успешно убрана!");
                _fishes.Remove(fish);
            }
        }

        public void ShowFishes()
        {
            int numberFish = 1;
            Console.WriteLine($"\nРыб в аквариуме - {_fishes.Count}");

            foreach (Fish fish in _fishes)
            {
                Console.WriteLine($"{numberFish++} - {fish.Name} | возраст - {fish.Age}");
            }
        }

        public void RemoveDeadFish()
        {
            bool isWoking = true;

            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsAlive == false)
                {
                    Console.WriteLine($"Рыбка {_fishes[i].Name} скончалась от возраста");
                    _fishes.RemoveAt(i);
                    break;
                }
            }
        }

        public void UpdateAgeFish() 
        {
            foreach (Fish fish in _fishes)
            {
                fish.Live();
            }
        }

        private bool TryGetFish(out Fish fish)
        {
            fish = null;

            Console.Write("Введите номер рыбки: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int numberToFish);

            if(isNumber == false)
            {
                Console.WriteLine("Вы вели некоректные данные");
            }
            else if(numberToFish > 0 && numberToFish - 1 < _fishes.Count && fish.IsAlive == true)
            {
                fish = _fishes[numberToFish - 1];
                return true;
            }
            else
            {
                Console.WriteLine("Рыбы с таким номер нет");
            }

            return false;
        }

        private string GetName()
        {
            string nameFish = null;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write("Введите имя рыбки: ");
                nameFish = Console.ReadLine();

                if (nameFish == null)
                {
                    Console.WriteLine("Вы не вели имя рыбки. Попробуйте еще раз");
                }
                else
                {
                    return nameFish;
                    isWorking = false;
                }
            }

            return nameFish;
        }

        private int GetAge()
        {
            int numberAgeFish = 0;
            bool isWorking = true;
            Fish fish = null;

            while (isWorking)
            {
                Console.Write("Введите возраст рыбки: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out numberAgeFish);

                if (isNumber == false)
                {
                    Console.WriteLine("Вы вели некоректно");
                }
                else if (numberAgeFish < 0 && numberAgeFish > fish.LeathalAge)
                {
                    Console.WriteLine("Такой возраст недопустим");
                }
                else
                {
                    return numberAgeFish;
                    isWorking = false;
                }
            }

            return numberAgeFish;
        }
    }

    class Fish
    {
        private int _leathalAge = 10; 

        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int LeathalAge { get { return _leathalAge; } }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsAlive => Age < _leathalAge;

        public void Live() => Age++;
    }
}
