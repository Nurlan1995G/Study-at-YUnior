using System;


namespace TaskCart             //Легенда: Вы приходите в магазин и хотите купить за своё золото кристаллы.
                               //В вашем кошельке есть какое-то количество золота, продавец спрашивает у вас,
                               //сколько кристаллов вы хотите купить? После сделки у вас остаётся какое-то количество золота и появляется какое-то количество кристаллов.
{

    class Task
    {
        static void Main(string[] args)
        {
            int gold;
            int crystalPrice = 5;
            int crystalsCount;

            Console.WriteLine("Доброго времени суток, стоимость одного кристалла равна " + crystalPrice +
                " золота");
            Console.Write("Введите, сколько у вас золота: ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов вы хотите приобрести? ");
            crystalsCount = Convert.ToInt32(Console.ReadLine());

            gold -= crystalsCount * crystalPrice;

            Console.WriteLine("У вас в ящике находится " + crystalsCount + " кристалла и " + gold + " золота");
        }
    }
}
