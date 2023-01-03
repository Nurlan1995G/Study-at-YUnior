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
            int crystalsCount;

            Console.WriteLine("Добро пожаловать! В нашем магазине стоимость одного кристалла равна "
                + crystalPrice + " золота");
            Console.Write("Ваша корзина пуста. Введите, сколько у вас золота: ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов вы хотите купить? ");
            crystalsCount = Convert.ToInt32(Console.ReadLine());
            gold -= crystalsCount * crystalPrice;
            Console.WriteLine("У вас в корзине находится " + crystalsCount + " кристалла и осталось " + gold + " золота");
        }
    }
}