using System;

namespace QueueAtStore
{
    class AtStore  
    {
        static void Main(string[] args)
        {
            int balanceBuys = 0;
            Queue<int> buys = new Queue<int>();
            bool isWorking = true;

            CreateQueue(buys);

            while (isWorking)
            {
                if (buys.Count > 0)
                {
                    SubstractBuy(buys, ref balanceBuys);
                    ShowQueue(buys);
                }
                else
                {
                    Console.WriteLine($"Очередь закончилась. Баланс составляется - {balanceBuys} долларов");
                    isWorking = false;
                }
            }
        }

        static void CreateQueue (Queue<int> buys)
        {
            Random random = new Random();
            int randomNumberBuys = 0;
            int beginningQueue = 5;
            int endingQueue = 11;
            int beginningNumberBuys = 1;
            int endingNumberBuys = 31;
            int randomQueue = random.Next(beginningQueue, endingQueue);

            for (int i = 0; i < randomQueue; i++)
            {
                randomNumberBuys = random.Next(beginningNumberBuys, endingNumberBuys);
                buys.Enqueue(randomNumberBuys);
            }

            Console.WriteLine($"Длина очереди - {buys.Count} покупателей");

            foreach (int buy in buys)
            {
                Console.WriteLine($"Сумма покупки - {buy}$");
            }

            Console.Write("Нажмите на любую клавишу для продолжения: ");
            Console.ReadKey();
        }

        static void SubstractBuy(Queue<int> buys, ref int balanceBuys)
        {
            Console.Clear();
            balanceBuys += buys.Dequeue();
            Console.WriteLine($"Баланс - {balanceBuys}$");
        }

        static void ShowQueue(Queue<int> buys)
        {
            foreach (int buyNum in buys)
            {
                Console.WriteLine($"Сумма покупки - {buyNum}$");
            }

            Console.Write("Нажмите на любую клавишу для продолжения: ");
            Console.ReadKey();
        }
    }
}
