using System;

namespace DynamicArrayAdvanced
{
    class DynamicArray  
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string userInputSum = "sum";
            string userInputExit = "exit";
            string userInput;
            int number;
            bool isWorking = true;
            int receivedSum;

            Console.WriteLine($"Вы можете тут водить числа и после того как введете команду - {userInputSum}, выведется сумма ваших чисел. Либо вести команду - {userInputExit}, выполнится выход из программы!");

            while (isWorking)
            {
                Console.Write("Введите любую команду: ");
                userInput = Console.ReadLine();

                if(userInput == userInputExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorking = false;
                }
                else if(userInput == userInputSum)
                {
                    SummatetNumbers(numbers);
                }
                else
                {
                    AddNumber(numbers, userInput);
                }
            }
        }

        static int SummatetNumbers(List<int> numbers)
        {
            int receivedSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                receivedSum += numbers[i];
            }

            Console.WriteLine($"Сумма чисел равна - {receivedSum}");

            return receivedSum;
        }

        static void AddNumber(List<int> numbers, string userInput)
        {
            int number;

            bool isNumbers = int.TryParse(userInput, out number);

            if (isNumbers)
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}
