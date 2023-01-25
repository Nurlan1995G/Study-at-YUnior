using System;

namespace WorkingArray
{
    class Working    //Дан двумерный массив. Вычислить сумму второй строки и произведение первого столбца.Вывести исходную матрицу и результаты вычислений.
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int[,] fridge = { {2,5,1 }, {3,6,2 }, {4,1,7 } };
            int number = 0;
            int additionSum = 0;
            int productSum = 1;
            int beginningOperation = 1;
            int midOperation = 2;

            while (isOpen)
            {
                for (int i = beginningOperation; i < fridge.GetLength(0); i++)
                {
                    if (i == beginningOperation)
                    {
                        Console.WriteLine("Закончился цикл по i");
                    }

                    if(i == midOperation)
                    {
                        isOpen = false;
                        break;
                    }

                    for (int j = 0; j < fridge.GetLength(1); j++)
                    {
                        number = fridge[i,j];
                        additionSum += number;
                        productSum *= number;
                    }
                    Console.WriteLine();
                }
            }

            Console.Write($"\nСумма второй строки равна - {additionSum},произведение первого столбца равна - {productSum}\n");
        }
    }
}
