using System;

namespace CSLight    
{
    class Program   
    {
        static void Main(string[] args)
        {
            string userInputName;
            char userInputSymbol;
            int beforyName = 1;
            int averageValue = 2;
            string connectingWords;
            char userSmbol;

            Console.Write("Введите имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            userInputSymbol = Convert.ToChar(Console.ReadLine());
            connectingWords = $"{userInputSymbol} {userInputName}  {userInputSymbol}";
            userSmbol = userInputSymbol;

            for (int i = 0; i < userInputName.Length; i++)
            {
                Console.Write($"{userInputSymbol} ");
                userSmbol = userInputSymbol;
            }

            Console.WriteLine(userSmbol);
            Console.WriteLine(connectingWords);
            Console.WriteLine(userSmbol);
        }
    }
}
