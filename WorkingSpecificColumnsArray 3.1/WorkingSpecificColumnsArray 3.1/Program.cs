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

            while (isOpen)
            {
                for (int i = 1; i < fridge.GetLength(0); i++)
                {
                    if (i == 1)
                    {
                        Console.WriteLine("Закончился цикл по i");
                    }

                    if(i == 2)
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
