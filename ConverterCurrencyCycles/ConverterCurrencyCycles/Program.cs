using System;

namespace ConverterCurrencyCycles
{
    class Converter
    {
        static void Main(string[] args)
        {
            float rubToUsd = 64;
            float usdToRub = 66;
            float rubToEur = 67;
            float eurToRub = 70;
            float eurToUsd = 1.2f;
            float usdToEur = 0.9f;
            float rub, usd, eur;
            float currencyCount;
            string userInputExit;
            string keyWorkExit = "exit";
            int userInput;
            bool isProgramWorks = true;
            int conditionsExchanger1 = 1;
            int conditionsExchanger2 = 2;
            int conditionsExchanger3 = 3;
            int conditionsExchanger4 = 4;
            int conditionsExchanger5 = 5;
            int conditionsExchanger6 = 6;

            Console.WriteLine("Добро пожаловать в ообменник валют!");
            Console.Write("Введите сколько у вас рублей: ");
            rub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сколько у вас долларов: ");
            usd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сколько у вас евро: ");
            eur = Convert.ToInt32(Console.ReadLine());

            while (isProgramWorks)
            {
                Console.WriteLine("Чтобы произвести операцию, введите число с нужной вам операцией!");
                Console.WriteLine($"{conditionsExchanger1} - обменять рубли в доллары");
                Console.WriteLine($"{conditionsExchanger2} - обменять доллары в рубли");
                Console.WriteLine($"{conditionsExchanger3} - обменять рубли в евро");
                Console.WriteLine($"{conditionsExchanger4} - обменять евро в рубли");
                Console.WriteLine($"{conditionsExchanger5} - обменять евро в доллары");
                Console.WriteLine($"{conditionsExchanger6} - обменять доллары в евро");
                Console.Write($"Для завершении программы, введите слово - {keyWorkExit}: ");
                userInputExit = Console.ReadLine();
                Console.Write("Введите номер операции: ");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInputExit == keyWorkExit)
                {
                    Console.WriteLine("Вы завершили работу программы!");
                    isProgramWorks = false;
                }
                else if (userInput == conditionsExchanger1)
                {
                    Console.WriteLine($"{conditionsExchanger1} - обменять рубли в доллары");
                    Console.Write("Сколько вы хотите обменять: ");
                    currencyCount = Convert.ToInt32(Console.ReadLine());

                    if (rub >= currencyCount)
                    {
                        rub -= currencyCount;
                        usd += currencyCount / rubToUsd;
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }
                else if (userInput == conditionsExchanger2)
                {
                    Console.WriteLine($"{conditionsExchanger2} - обменять доллары в рубли");
                    Console.Write("Сколько вы хотите обменять: ");
                    currencyCount = Convert.ToInt32(Console.ReadLine());

                    if (usd >= currencyCount)
                    {
                        usd -= currencyCount;
                        rub += currencyCount * usdToRub;
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }
                else if (userInput == conditionsExchanger3)
                {
                    Console.WriteLine($"{conditionsExchanger3} - обменять рубли в евро");
                    Console.Write("Сколько вы хотите обменять: ");
                    currencyCount = Convert.ToInt32(Console.ReadLine());

                    if (rub >= currencyCount)
                    {
                        rub -= currencyCount;
                        eur += currencyCount / rubToEur;
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }
                else if (userInput == conditionsExchanger4)
                {
                    Console.WriteLine($"{conditionsExchanger4} - обменять евро в рубли");
                    Console.Write("Сколько вы хотите обменять: ");
                    currencyCount = Convert.ToInt32(Console.ReadLine());

                    if (eur >= currencyCount)
                    {
                        eur -= currencyCount;
                        rub += currencyCount * eurToRub;
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }
                else if (userInput == conditionsExchanger5)
                {
                    Console.WriteLine($"{conditionsExchanger5} - обменять евро в доллары");
                    Console.Write("Сколько вы хотите обменять: ");
                    currencyCount = Convert.ToInt32(Console.ReadLine());

                    if (eur >= currencyCount)
                    {
                        eur -= currencyCount;
                        usd += currencyCount / eurToUsd;
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }
                else if (userInput == conditionsExchanger6)
                {
                    Console.WriteLine($"{conditionsExchanger6} - обменять доллары в евро");
                    Console.Write("Сколько вы хотите обменять: ");
                    currencyCount = Convert.ToInt32(Console.ReadLine());

                    if (usd >= currencyCount)
                    {
                        usd -= currencyCount;
                        eur += currencyCount / usdToEur;
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }

                Console.WriteLine($"У вас на счету {rub} рублей, {usd} долларов, {eur} евро.");
            }
        }
    }
}
