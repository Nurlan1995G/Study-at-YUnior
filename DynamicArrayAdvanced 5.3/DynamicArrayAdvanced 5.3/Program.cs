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
            bool isWorkProgress = true;
            int receivedSum;

            Console.WriteLine($"Вы можете тут водить числа и после того как введете команду - {userInputSum}, выведется сумма ваших чисел. Либо вести команду - {userInputExit}, выполнится выход из программы!");

            while (isWorkProgress)
            {
                Console.Write("Введите любую команду: ");
                userInput = Console.ReadLine();

                if(userInput == userInputExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorkProgress = false;
                }
                else if(userInput == userInputSum)
                {
                    SummatetNumbers(numbers, out receivedSum);
                }
                else
                {
                    AddNumber(ref numbers, userInput);
                }
            }
        }

        static void SummatetNumbers(List<int> numbers, out int receivedSum)
        {
            receivedSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                receivedSum += numbers[i];
            }

            Console.WriteLine($"Сумма чисел равна - {receivedSum}");
        }

        static void AddNumber(ref List<int> numbers, string userInput)
        {
            int number;
            bool isWork = true;

            while (isWork)
            {
                bool isNumbers = int.TryParse(userInput, out number);

                if (isNumbers)
                {
                    numbers.Add(number);
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                    isWork = false;
                }
            }
        }
    }
}
