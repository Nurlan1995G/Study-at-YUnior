using System;

namespace CyclesSymbol
{
    class CyclesSym     
    {
        static void Main(string[] args)
        {
            string userInputName;
            string userInputSymbol;
            string connectingWords;
            string receivedSymbol = "";

            Console.Write("Введите имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            userInputSymbol = Console.ReadLine();
            connectingWords = userInputSymbol + userInputName + userInputSymbol;

            for (int i = 0; i < userInputName.Length; i++)
            {
                receivedSymbol += userInputSymbol;
            }

            Console.WriteLine(receivedSymbol);
            Console.WriteLine(connectingWords);
            Console.WriteLine(receivedSymbol);
        }
    }
}
