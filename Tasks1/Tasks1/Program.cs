using System;
using System.Collections.Generic;


namespace Tasks    
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold;           
            int crystalPrice = 5;  
            int crystalCount;

           Console.WriteLine("Доброго времени суток, стоимость одного кристалла равна " + crystalPrice + 
               " золота");
            Console.Write("Введите, сколько у вас золота: ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов вы хотите приобрести? ");
            crystalCount = Convert.ToInt32(Console.ReadLine());

            gold -= crystalCount * crystalPrice;

            Console.WriteLine("У вас в ящике находится " + crystalCount + " кристалла и " + gold + " золота");
        }
    }
}

