using System;

namespace LargestElement
{
    class Array   
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int columnNumber = 10;
            int rowNumber = 10;
            int[,] numbers = new int[rowNumber,columnNumber];
            int maxElement = int.MinValue;
            int minRandomValue = 0;
            int maxRandomValue = 9;
            int reducedNumberToMatrix = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(minRandomValue, maxRandomValue);
                    Console.Write(numbers[i, j] + " ");

                    if(maxElement < numbers[i, j])
                    {
                        maxElement = numbers[i, j];
                    }
                }

                Console.Write($"Наибольшее число в матрице - {maxElement}");
                Console.WriteLine();
            }

            Console.WriteLine("\n");

            for(int i = 0; i < numbers.GetLength(0); i++)
            {
                for(int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i,j] == maxElement)
                    {
                        numbers[i, j] = reducedNumberToMatrix;
                    }

                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
