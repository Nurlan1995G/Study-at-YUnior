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
            int maxRandomNumber = 9;
            int minRandomNumber = 0;
            int iterationValue = 1;
            int followingValue = 2;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            for(int i = 0; i < numbers.Length; i++)
            {
                if (i == iterationValue)
                {
                    if (numbers[i] > numbers[i - iterationValue])
                    {
                        Console.Write($"{numbers[i]} ");
                    }

                    stepNumber++;
                }
                else if (i == stepNumber)
                {
                    if (numbers[i - iterationValue] > numbers[i - followingValue] && numbers[i - iterationValue] > numbers[i])
                    {
                        Console.Write($"{numbers[i - iterationValue]} ");
                    }

                    stepNumber++;
                }
            }
        }
    }
}
