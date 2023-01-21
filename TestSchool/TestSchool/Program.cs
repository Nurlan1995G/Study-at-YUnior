using System;

namespace CSLight    
{
    class Program   
    {
        static void Main(string[] args)
        {
            string userInputName;
            string userInputSymbol;
            int beforyName = 1;
            int averageValue = 2;
            string connectingWords;
            string userSmbol = "";

            Console.Write("Введите имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            userInputSymbol = Console.ReadLine();
            connectingWords = $"{userInputSymbol} {userInputName}  {userInputSymbol}";

            for (int i = 0; i < userInputName.Length; i++)
            {
                userSmbol += $"{userInputSymbol} ";
            }

            Console.WriteLine(userSmbol);
            Console.WriteLine(connectingWords);
            Console.WriteLine(userSmbol);
        }
    }
}
