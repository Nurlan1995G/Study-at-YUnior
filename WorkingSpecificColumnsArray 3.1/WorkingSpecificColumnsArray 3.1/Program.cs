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
            int columnNumber = 1;
            int rowNumber = 1;

            for (int i = 0; i < fridge.GetLength(0); i++) 
            {
                for (int j = 0; j < fridge.GetLength(columnNumber); j++)
                {
                    Console.Write(fridge[i, j] + " ");
                }

                Console.WriteLine();
            }

            for(int i = 0; i < fridge.GetLength(0); i++)
            {
                productSum *= fridge[i,0];
            }

            for(int j = 0; j < fridge.GetLength(columnNumber); j++)
            {
                additionSum += fridge[rowNumber,j];
            }
              
            Console.Write($"\nСумма второй строки равна - {additionSum},произведение первого столбца равна - {productSum}\n");
        }
    }
}
