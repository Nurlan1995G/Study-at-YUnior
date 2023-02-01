using System;

namespace LocalMaxima
{
    class Local   
    {
        static void Main(string[] args)
        {
            int rowNumber = 30;
            int[] numbers = new int[rowNumber];
            Random random = new Random();
            int stepNumber = 1;
            int index = 1;
            int minDecreaseNumber = 1;
            int maxDecreaseNumber = 2;
            int startVerification = 2;
            int maxRandomNumber = 9;
            int minRandomNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            if (numbers[0] > numbers[index])
            {
                Console.Write(numbers[0] + " ");
            }

            for(int i = startVerification; i < numbers.Length; i++)
            {
                stepNumber++;

                if (i == stepNumber)
                {
                    if (numbers[i - minDecreaseNumber] > numbers[i - maxDecreaseNumber] && numbers[i - minDecreaseNumber] > numbers[i])
                    {
                        Console.Write(numbers[i - minDecreaseNumber] + " ");
                    }
                }
            }

            if (numbers[numbers.Length - minDecreaseNumber] > numbers[numbers.Length - maxDecreaseNumber])
            {
                Console.Write(numbers[numbers.Length - minDecreaseNumber]);
            }
        }
    }
}
