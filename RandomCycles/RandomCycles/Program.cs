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
            int divisibleNumber3 = 3;
            int divisibleNumber5 = 5;

            randomNumber = random.Next(0, endingNumber);
            Console.WriteLine($"Выпало рандомное число - {randomNumber}");

            for (int i = 0; i <= randomNumber; i++)
            {
                if(i % divisibleNumber5 == 0 || i % divisibleNumber3 == 0)
                {
                    numbersSum += i;
                }
            }
            Console.WriteLine($"Сумма положительных чисел, которые кратны {divisibleNumber3} или {divisibleNumber5} - равна {numbersSum}");
        }
    }
}
