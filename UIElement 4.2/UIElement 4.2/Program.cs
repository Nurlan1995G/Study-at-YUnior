using System;

namespace UIElement
{
    class Element  //Разработайте функцию, которая рисует некий бар (Healthbar, Manabar) в определённой позиции. Она также принимает некий закрашенный процент. При 40% бар выглядит так:  [####______]
    {
        static void Main(string[] args)
        {
            int healthBar = 0;
            int maxHealthBar;
            int manaBar = 0; 
            int maxManaBar;
            bool isProgramWorks = true;
            string userInputExit = "exit";
            string userInput;
            int positionUpBar = 3;
            int positionLowerBar = 4;
            int positionTablesNumbers = 20;

            Console.Write("Введите максимальное число здоровья: ");
            maxHealthBar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимальное число маны: ");
            maxManaBar = Convert.ToInt32(Console.ReadLine());

            while (isProgramWorks)
            {
                Console.SetCursorPosition(0, positionTablesNumbers);
                Console.WriteLine($"Максимальное число здоровья: {maxHealthBar}");
                Console.WriteLine($"Максимальное число маны: {maxManaBar}");

                Bar(healthBar, maxHealthBar, ConsoleColor.Red, positionUpBar, '_');
                Bar(manaBar, maxManaBar, ConsoleColor.Green, positionLowerBar, '_');

                Console.Write("\nВведите кол-во жизней в процентнои соотношении: ");
                healthBar += Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите кол-во маны в процентнои соотношении: ");
                manaBar += Convert.ToInt32(Console.ReadLine());
                Console.Write($"Введите команду {userInputExit} для выхода из программы: ");
                userInput = Console.ReadLine();

                if(healthBar > maxHealthBar || manaBar > maxManaBar)
                {
                    Console.WriteLine("Вы вели выше максимального значения. Введите пожалуйста еще раз!");
                    healthBar = 0;
                    manaBar = 0;
                    Console.ReadKey();
                }

                Console.Clear();

                if (userInput == userInputExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isProgramWorks = false;
                }
            }
        }

        static void Bar(int value, int maxValue, ConsoleColor color,int position, char symbol = ' ')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";

            for(int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for(int i = value; i < maxValue; i++)
            {
                bar += symbol;
            }

            Console.Write(bar + ']');
        }
    }
}
