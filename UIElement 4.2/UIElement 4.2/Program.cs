using System;

namespace UIElement
{
    class Element  
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
            int lowerPosition = 1;

            Console.Write("Введите максимальное число здоровья: ");
            maxHealthBar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимальное число маны: ");
            maxManaBar = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            while (isProgramWorks)
            {
                Bar(healthBar, maxHealthBar, ConsoleColor.Red, 0, '_');
                Bar(manaBar, maxManaBar, ConsoleColor.Green, lowerPosition, '_');

                Console.Write("\nВведите кол-во жизней в процентнои соотношении: ");
                healthBar += Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите кол-во маны в процентнои соотношении: ");
                manaBar += Convert.ToInt32(Console.ReadLine());
                Console.Write($"Введите команду {userInputExit} для выхода из программы: ");
                userInput = Console.ReadLine();

                Console.Clear();

                if (userInput == userInputExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isProgramWorks = false;
                }

                Console.ReadKey();
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
