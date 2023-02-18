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
                    int receivedSum = 0;

                    for(int i = 0; i < numbers.Count; i++)
                    {
                        receivedSum += numbers[i];
                    }

                    Console.WriteLine($"Сумма чисел равна - {receivedSum}");
                }
                else
                {
                    number = int.Parse(userInput);
                    numbers.Add(number);
                }
            }
        }
    }
}
