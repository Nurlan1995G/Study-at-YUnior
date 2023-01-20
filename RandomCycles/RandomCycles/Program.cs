using System;

namespace RandonCycles
{
    class Cycles    
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int sum = 0;
            int randomNumber;
            int minRandomValue = 0;
            int maxRandomValue = 101;
            int largerDivider = 5;
            int smallerDivider = 3;

            randomNumber = random.Next(minRandomValue, maxRandomValue);
            Console.WriteLine($"Выпало рандомное число - {randomNumber}");

            for (int i = 0; i <= randomNumber; i++)
            {
                if(i % smallerDivider == 0 || i % largerDivider == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма положительных чисел, которые кратны {smallerDivider} или {largerDivider} - равна {sum}");
        }
    }
}
