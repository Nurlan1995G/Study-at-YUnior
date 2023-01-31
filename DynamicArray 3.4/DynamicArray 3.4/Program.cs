using System;

namespace DynamicArray
{
    class Dynamic  
    {
        static void Main(string[] args)
        {
            int number;
            int sumNumbers = 0;
            string userInputSum = "sum";
            string userInputExit = "exit";
            string userInputString;
            bool isWorkProgress = true;

            Console.WriteLine($"Вы можете тут водить числа и после того как введете команду - {userInputSum}, выведется сумма ваших чисел. Либо вести команду - {userInputExit}, выполнится выход из программы!");

            while (isWorkProgress)
            {
                Console.Write("Введите число: ");
                number = Convert.ToInt32(Console.ReadLine());

                int[] userInputNumbers = { number };

                Console.Write($"Введите комманду - {userInputSum} или {userInputExit}: ");
                userInputString = Console.ReadLine();

                for(int i = 0; i < userInputNumbers.Length; i++)
                {
                    sumNumbers += userInputNumbers[i];

                    if(userInputString == userInputSum)
                    {
                        Console.WriteLine($"Сумма числен равна - {sumNumbers}");
                    }
                }

                if(userInputString == userInputExit)
                {
                    Console.WriteLine("Вы вели команду завершения программы!");
                    isWorkProgress = false;
                }
            }
        }
    }
}
