using System;

namespace RandonCycles
{
    class Cycles    
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numbersSum = 0;
            int randomNumber;
            int endingNumber = 101;
            int fifthDivider = 5;
            int thirdDivider = 3;

            randomNumber = random.Next(0, endingNumber);
            Console.WriteLine($"Выпало рандомное число - {randomNumber}");

            for (int i = 0; i <= randomNumber; i++)
            {
                if(i % thirdDivider == 0 || i % fifthDivider == 0)
                {
                    numbersSum += i;
                }
            }

            Console.WriteLine($"Сумма положительных чисел, которые кратны {thirdDivider} или {fifthDivider} - равна {numbersSum}");
        }
    }
}
