using System;

namespace DynamicArray
{
    class Dynamic  
    {
        static void Main(string[] args)
        {
            int[] userInputNumbers = new int[0];
            int number;
            int increaseLenght = 1;
            int index = 0;
            int decreaseIndex = 1;
            int receivedSum = 0;
            string userInputSum = "sum";
            string userInputExit = "exit";
            string userInputString;
            bool isWorkProgress = true;

            Console.WriteLine($"Вы можете тут водить числа и после того как введете команду - {userInputSum}, выведется сумма ваших чисел. Либо вести команду - {userInputExit}, выполнится выход из программы!");

            while (isWorkProgress)
            {
                Console.Write("Введите число: ");
                number = Convert.ToInt32(Console.ReadLine());

                int[] sum = new int[userInputNumbers.Length + increaseLenght];

                Console.Write($"Введите комманду - {userInputSum} или {userInputExit}: ");
                userInputString = Console.ReadLine();

                for(int i = 0; i < userInputNumbers.Length; i++)
                {
                    sum[i] = userInputNumbers[i];
                }

                sum[sum.Length - decreaseIndex] = number;
                userInputNumbers = sum;
                receivedSum += userInputNumbers[0 + index];

                if (userInputString == userInputSum)
                {
                    Console.WriteLine($"Сумма числен равна - {receivedSum}");
                }

                if (userInputString == userInputExit)
                {
                    Console.WriteLine("Вы вели команду завершения программы!");
                    isWorkProgress = false;
                }

                index++;
            }
        }
    }
}
