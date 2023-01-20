using System;

namespace CyclesSymbol
{
    class CyclesSym     
    {
        static void Main(string[] args)
        {
            string userInputName;
            char userInputSymbol;
            int beforyName = 1;
            int averageValue = 2;
            string connectingWords;

            Console.Write("Введите имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            userInputSymbol = Convert.ToChar(Console.ReadLine());
            connectingWords = $"{userInputSymbol} {userInputName}  {userInputSymbol}";

            for(int i = 0; i < averageValue; i++)
            {
                if(i == beforyName)
                {
                    Console.WriteLine($"{connectingWords}");
                }

                for(int j = 0; j < userInputName.Length; j++)
                {
                    Console.Write($"{userInputSymbol} ");
                }

                Console.WriteLine();
            }
        }
    }
}
