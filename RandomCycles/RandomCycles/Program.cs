using System;

namespace RandonCycles
{
    class Cycles        
    { 
        static void Main(string[] args)
        {
            int numbersSum = 0;
            Random random = new Random();
            int numberRand;
            int numberMultiple;

            numberRand = random.Next(0, 100);
           
            Console.Write($"Введите кратное число 3 или 5: ");
            numberMultiple = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < numberRand; i++)
            {
                if(i % numberMultiple == 0)
                {
                    numbersSum += i;
                }
            }
            Console.WriteLine($"Рандомное число выпало {numberRand}");
            Console.WriteLine($"Сумма чисел кратной {numberMultiple} = {numbersSum}");

        }
    }
}
