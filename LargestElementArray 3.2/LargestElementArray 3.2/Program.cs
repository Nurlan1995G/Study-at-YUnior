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
            int[,] elementMatrix = new int[rowNumber,columnNumber];
            int maxElement = int.MinValue;
            int initialRandomNumber = 0;
            int upperRandomNumber = 9;
            int reducedNumberToMatrix = 0;

            for (int i = 0; i < elementMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < elementMatrix.GetLength(1); j++)
                {
                    elementMatrix[i, j] = random.Next(initialRandomNumber, upperRandomNumber);
                    Console.Write(elementMatrix[i, j] + " ");

                    if(maxElement <= elementMatrix[i, j])
                    {
                        maxElement = elementMatrix[i, j];
                    }
                }

                Console.Write($"Наибольшее число в матрице - {maxElement}");
                Console.WriteLine();
            }

            Console.WriteLine("\n");

            for(int i = 0; i < elementMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < elementMatrix.GetLength(1); j++)
                {
                    if (elementMatrix[i,j] == maxElement)
                    {
                        elementMatrix[i, j] = reducedNumberToMatrix;
                    }

                    Console.Write(elementMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
