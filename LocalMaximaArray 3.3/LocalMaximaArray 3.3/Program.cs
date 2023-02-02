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
            int index = 1;
            int startVerification = 1;
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

            for(int i = startVerification; i < numbers.Length - 1; i++)
            { 
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
            {
                Console.Write(numbers[numbers.Length - 1]);
            }
        }
    }
}
