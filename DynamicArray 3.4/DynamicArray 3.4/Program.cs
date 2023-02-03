using System;

namespace DynamicArray
{
    class Dynamic  
    {
        static void Main(string[] args)
        {
            int[] userInputNumbers = new int[0];
            int number = 0;
            int increaseLenght = 1;
            int index = 0;
            int decreaseIndex = 1;
            int receivedSum = 0;
            var userInputSum = "sumUserInputNumbers";
            var userInputExit = "exit";
            var userInputString = "";
            bool isWorkProgress = true;

            Console.WriteLine($"Вы можете тут водить числа и после того как введете команду - {userInputSum}, выведется сумма ваших чисел. Либо вести команду - {userInputExit}, выполнится выход из программы!");

            while (isWorkProgress)
            {
                Console.Write("Введите любую команду: ");
                userInputString = Console.ReadLine();

                if(userInputString == userInputExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorkProgress = false;
                }

                if(userInputString != userInputExit && userInputString != userInputSum) 
                {
                    number = int.Parse(userInputString);

                    int[] sumUserInputNumbers = new int[userInputNumbers.Length + increaseLenght];

                    for (int i = 0; i < userInputNumbers.Length; i++)
                    {
                        sumUserInputNumbers[i] = userInputNumbers[i];
                    }

                    sumUserInputNumbers[sumUserInputNumbers.Length - decreaseIndex] = number;
                    userInputNumbers = sumUserInputNumbers;
                    receivedSum += userInputNumbers[0 + index];

                    index++;
                }

                if (userInputString == userInputSum)
                {
                    Console.WriteLine($"Сумма числен равна - {receivedSum}");
                }
            }
        }
    }
}
