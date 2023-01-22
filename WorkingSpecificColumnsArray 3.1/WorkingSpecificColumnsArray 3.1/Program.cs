using System;

namespace WorkingArray
{
    class Working   
    {
        static void Main(string[] args)
        {
            int[,] fridge = { {2,5,1 }, {3,6,2 }, {4,1,7 } };

            for(int i = 0; i < fridge.GetLength(0); i++)
            {
                for(int j = 0; j < fridge.GetLength(1); j++)
                {
                    Console.Write(fridge[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write($"\nСумма второй строки,первого столбца равна - {fridge[1, 0]}\n");
        }
    }
}
