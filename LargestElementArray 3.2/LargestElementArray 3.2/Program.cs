using System;

namespace LargestElement
{
    class Array   //Найти наибольший элемент матрицы A(10,10) и записать ноль в те ячейки, где он находятся. Вывести наибольший элемент, исходную и полученную матрицу. Массив под измененную версию не нужен.
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] elementMatrix = new int[10,10];
            int numbers = 0;
            int maxElement = int.MinValue;

            Console.SetCursorPosition(0, 15);

            for(int i = 0; i < elementMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < elementMatrix.GetLength(1); j++)
                {
                    elementMatrix[i, j] = random.Next(0, 10);
                    Console.Write(elementMatrix[i, j] + " ");

                    if(maxElement < elementMatrix[i, j])
                    {
                        maxElement = elementMatrix[i, j];
                    }
                }

                Console.WriteLine();
                Console.WriteLine(maxElement);
            }
        }
    }
}
