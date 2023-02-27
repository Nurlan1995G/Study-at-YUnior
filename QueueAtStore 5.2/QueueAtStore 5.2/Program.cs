using System;

namespace QueueAtStore
{
    class AtStore  
    {
        static void Main(string[] args)
        {
            int balanceBuys = 0;
            Queue<int> buys = new Queue<int>();

            FillQueue(buys);
            Serve(buys, balanceBuys);
        }

        static void FillQueue (Queue<int> buys)
        {
            Random random = new Random();
            int randomSumBuys = 0;
            int minCountClients = 5;
            int maxCountClients = 11;
            int minValue = 1;
            int maxValue = 31;
            int randomCountClients = random.Next(minCountClients, maxCountClients);

            for (int i = 0; i < randomCountClients; i++)
            {
                randomSumBuys = random.Next(minValue, maxValue);
                buys.Enqueue(randomSumBuys);
            }

            Console.WriteLine($"Длина очереди - {buys.Count} покупателей");

            ShowQueue(buys);
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

        static void Serve(Queue<int> buys, int balanceBuys)
        {
            bool isWorking = true;

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
    }
}
