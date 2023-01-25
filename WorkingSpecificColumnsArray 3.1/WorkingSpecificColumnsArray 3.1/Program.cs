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

            for (int i = 0; i < fridge.GetLength(0); i++) 
            {
                numberProduct = fridge[i, 0];
                productSum *= numberProduct;

                for (int j = 0; j < fridge.GetLength(1); j++)
                {
                    Console.Write(fridge[i, j] + " ");

                    if (i == 2)
                    {
                        additionNumber = fridge[1, j];
                        additionSum += additionNumber;
                    }
                }

                Console.WriteLine();
            }
              
            Console.Write($"\nСумма второй строки равна - {additionSum},произведение первого столбца равна - {productSum}\n");
        }
    }
}
