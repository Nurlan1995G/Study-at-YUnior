using System;

namespace DegreeTwo
{
    class Cysles   
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber;
            int degreeNumber = 0;
            int mainNumber = 2;
            int resultingValue = 1;  
            int minValueRandomNumbers = 1;
            int maxValueRandomNumbers = 101;

            randomNumber = random.Next(minValueRandomNumbers,maxValueRandomNumbers);
            Console.WriteLine($"Выпало число - {randomNumber}");

            for(int i = 0; i < randomNumber; i++)
            {
                if(randomNumber >= resultingValue)
                {
                    resultingValue *= mainNumber;
                    degreeNumber++;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine($"Число - {randomNumber}. Минимальная степень двойки превосходящая заданое число, будет {mainNumber} в степень {degreeNumber} равна - {resultingValue}.\n {randomNumber} < {resultingValue}");
        }
    }
}
