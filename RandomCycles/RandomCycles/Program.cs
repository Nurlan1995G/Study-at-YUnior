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
            bool isRightDecision = false;  

            randomNumber = random.Next(0, 100);
            Console.WriteLine($"Выпало рандомное число - {randomNumber}");
            Console.Write($"Ведите кратное число {divisibleNumber3} или {divisibleNumber5}: ");
            userInputNumber = Convert.ToInt32(Console.ReadLine());

            while (isRightDecision == false)
            {
                if (userInputNumber == divisibleNumber5)
                {
                    for (int i = 0; i < randomNumber; i += divisibleNumber5)
                    {
                        if (randomNumber >= numbersSum)
                        {
                            numbersSum += divisibleNumber5;
                            Console.WriteLine(numbersSum);
                            isRightDecision = true;
                        }
                    }
                }

                if (userInputNumber == divisibleNumber3)
                {
                    for (int j = 0; j < randomNumber; j += divisibleNumber3)
                    {
                        if (randomNumber >= numbersSum)
                        {
                            numbersSum += divisibleNumber3;
                            Console.WriteLine(numbersSum);
                            isRightDecision = true; 
                        }
                    }
                }
            }
        }
    }
}
