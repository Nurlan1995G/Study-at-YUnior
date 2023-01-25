using System;

namespace WorkingArray
{
    class Working   
    {
        static void Main(string[] args)
        {
            int[,] fridge = { {2,5,1 }, {3,6,2 }, {4,1,7 } };
            int additionNumber = 0;
            int additionSum = 0;
            int numberProduct = 0;
            int productSum = 1;
            int column = 1;

            for (int i = 0; i < fridge.GetLength(0); i++) 
            {
                for (int j = 0; j < fridge.GetLength(1); j++)
                {
                    Console.Write(fridge[i, j] + " ");
                }

                Console.WriteLine();
            }

            for(int i = 0; i < fridge.GetLength(0); i++)
            {
                numberProduct = fridge[i, 0];
                productSum *= numberProduct;
            }

            for(int j = 0; j < fridge.GetLength(column); j++)
            {
                additionNumber = fridge[1, j];
                additionSum += additionNumber;
            }
              
            Console.Write($"\nСумма второй строки равна - {additionSum},произведение первого столбца равна - {productSum}\n");
        }
    }
}
