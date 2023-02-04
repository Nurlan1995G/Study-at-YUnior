using System;

namespace DynamicArray
{
    class Dynamic  
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];
            int number = 0;
            int index = 0;
            int receivedSum = 0;
            string userInputSum = "sum";
            string userInputExit = "exit";
            string userInput = "";
            bool isWorkProgress = true;

            Console.WriteLine($"Вы можете тут водить числа и после того как введете команду - {userInputSum}, выведется сумма ваших чисел. Либо вести команду - {userInputExit}, выполнится выход из программы!");

            while (isWorkProgress)
            {
                Console.Write("Введите любую команду: ");
                userInput = Console.ReadLine();

                if(userInput != userInputExit && userInput != userInputSum) 
                {
                    number = int.Parse(userInput);

                    int[] tempNumbers = new int[numbers.Length + 1];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    tempNumbers[tempNumbers.Length - 1] = number;
                    numbers = tempNumbers;
                    receivedSum += numbers[0 + index];

                    index++;
                }
                else if (userInput == userInputSum)
                {
                    Console.WriteLine($"Сумма числен равна - {receivedSum}");
                }
                else
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorkProgress = false;
                }
            }
        }
    }
}
