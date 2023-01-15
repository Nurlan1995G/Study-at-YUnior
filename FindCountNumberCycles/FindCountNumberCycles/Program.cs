using System;

namespace FindCycles
{
    class Cycles    
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int receivedNumber;  
            int smallNumber = 1;
            int bigNumber = 27;
            bool isCalculationNumbers = true;
            string userInputExit;
            string wordExit = "exit";

            receivedNumber = random.Next(smallNumber, bigNumber);
            int bigNumberValue = bigNumber + 1;

            while (isCalculationNumbers)
            {
                receivedNumber = random.Next(smallNumber, bigNumberValue);
                Console.WriteLine(receivedNumber);
                Console.ReadKey();

                if (smallNumber < receivedNumber && receivedNumber < bigNumber)
                {
                    Console.WriteLine($"{smallNumber} < {receivedNumber} < {bigNumber}");
                }
                else if(smallNumber == receivedNumber && receivedNumber < bigNumber)
                {
                    Console.WriteLine($"{smallNumber} = {receivedNumber} < {bigNumber}");
                }
                else if(smallNumber < receivedNumber && receivedNumber == bigNumber)
                {
                    Console.WriteLine($"{smallNumber} < {receivedNumber} = {bigNumber}");
                }

                Console.Write($"Для выхода из программы, введите команду - {wordExit}: ");
                userInputExit = Console.ReadLine();

                if (userInputExit == wordExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isCalculationNumbers = false;
                }
            }
        }
    }
}
