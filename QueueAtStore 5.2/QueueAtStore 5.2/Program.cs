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

            FillQueue(buys);

            while (isWorking)
            {
                if (buys.Count > 0)
                {
                    balanceBuys = SubstractBuy(buys, balanceBuys);
                    ShowQueue(buys);
                }
                else
                {
                    Console.WriteLine($"Очередь закончилась. Баланс составляется - {balanceBuys} долларов");
                    isWorking = false;
                }
            }
        }

        static void FillQueue (Queue<int> buys)
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

            foreach (int sumBuys in buys)
            {
                Console.WriteLine($"Сумма покупки - {sumBuys}$");
            }

            Console.Write("Нажмите на любую клавишу для продолжения: ");
            Console.ReadKey();
        }

        static int SubstractBuy(Queue<int> buys, int balanceBuys)
        {
            Console.Clear();
            balanceBuys += buys.Dequeue();
            Console.WriteLine($"Баланс - {balanceBuys}$");

            return balanceBuys;
        }

        static void ShowQueue(Queue<int> buys)
        {
            foreach (int sumBuys in buys)
            {
                Console.WriteLine($"Сумма покупки - {sumBuys}$");
            }

            Console.Write("Нажмите на любую клавишу для продолжения: ");
            Console.ReadKey();
        }
    }
}
