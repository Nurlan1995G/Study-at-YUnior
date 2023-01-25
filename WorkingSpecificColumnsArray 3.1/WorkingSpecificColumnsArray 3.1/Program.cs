using System;

namespace WorkingArray
{
    class Working   
    {
        static void Main(string[] args)
        {
            int[,] fridge = { {2,5,1 }, {3,6,2 }, {4,1,7 } };
            int additionSum = 0;
            int productSum = 1;
            int column = 1;
            int valueZero = 0;
            int row = 1;

            for (int i = 0; i < fridge.GetLength(valueZero); i++) 
            {
                for (int j = 0; j < fridge.GetLength(1); j++)
                {
                    Console.Write(fridge[i, j] + " ");
                }

                Console.WriteLine();
            }

            for(int i = 0; i < fridge.GetLength(valueZero); i++)
            {
                productSum *= fridge[i,valueZero];
            }

            for(int j = 0; j < fridge.GetLength(column); j++)
            {
                additionSum += fridge[row,j];
            }
              
            Console.Write($"\nСумма второй строки равна - {additionSum},произведение первого столбца равна - {productSum}\n");
        }
    }
}
