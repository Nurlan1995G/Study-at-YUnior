using System;

namespace RandonCycles
{
    class Cycles        
    {
        static void Main(string[] args)
        {
            int numbersSum = 0;
            Random random = new Random();
            int randomNumber;
            int endingNumber = 100;
            int divisibleNumber3 = 3;
            int divisibleNumber5 = 5;
            int userInputNumber;

            randomNumber = random.Next(0, 100);
            Console.WriteLine($"Выпало рандомное число - {randomNumber}");
            Console.Write($"Ведите кратное число {divisibleNumber3} или {divisibleNumber5}: ");
            userInputNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= endingNumber; i++)
            {
                if (userInputNumber == divisibleNumber5 && randomNumber >= numbersSum)
                {
                    numbersSum += divisibleNumber5;
                    Console.WriteLine(numbersSum);
                }

                if(userInputNumber == divisibleNumber3 && randomNumber >= numbersSum)
                {
                    numbersSum += divisibleNumber3;
                    Console.WriteLine(numbersSum);
                }
            }
        }
    }
}
