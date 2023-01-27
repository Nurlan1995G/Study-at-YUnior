using System;

namespace LargestElement
{
    class Array   
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] elementMatrix = new int[10,10];
            int maxElement = int.MinValue;
            int startNumberMatrix = 0;

            for(int i = 0; i < elementMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < elementMatrix.GetLength(1); j++)
                {
                    elementMatrix[i, j] = random.Next(0, 9);
                    Console.Write(elementMatrix[i, j] + " ");

                    if(maxElement <= elementMatrix[i, j])
                    {
                        maxElement = elementMatrix[i, j];
                    }
                }

                Console.Write(" " + maxElement);
                Console.WriteLine();
                maxElement = startNumberMatrix;
            }
        }
    }
}
