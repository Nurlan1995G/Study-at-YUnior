using System;

namespace CyclesSymbol
{
    class CyclesSym
    {
        static void Main(string[] args)
        {
            string userInputName;
            string userInputSymbol;
            int beforyName = 1;
            int afterName = 3;
            int averageValue = 2;

            Console.Write("Введите имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            userInputSymbol = Console.ReadLine();

            for (int i = beforyName; i < afterName; i++)
            {
                if (i == averageValue)
                {
                    Console.WriteLine($"{userInputSymbol} {userInputName}  {userInputSymbol}");
                }

                for (int j = 0; j < userInputName.Length; j++)
                {
                    Console.Write($"{userInputSymbol} ");
                }

                Console.WriteLine();
            }
        }
    }
}
