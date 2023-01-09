using System;

namespace ConverterCurrencyCycles
{
    class Converter
    {
        static void Main(string[] args)
        {
            float rubToUsd = 64, usdToRub = 66, rubToEur = 67, eurToRub = 70, eurToUsd = 1.2f, usdToEur = 0.9f;
            float rub, usd, eur;
            float currencyCount;
            string userInput;
            bool isCalculationsCurrency = true;

            Console.WriteLine("Добро пожаловать в ообменник валют!");
            Console.Write("Введите сколько у вас рублей: ");
            rub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сколько у вас долларов: ");
            usd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сколько у вас евро: ");
            eur = Convert.ToInt32(Console.ReadLine());

            while (isCalculationsCurrency) 
            {
                Console.WriteLine("Чтобы произвести операцию, введите число с нужной вам операцией!");
                Console.WriteLine("1 - обменять рубли в доллары");
                Console.WriteLine("2 - обменять доллары в рубли");
                Console.WriteLine("3 - обменять рубли в евро");
                Console.WriteLine("4 - обменять евро в рубли");
                Console.WriteLine("5 - обменять евро в доллары");
                Console.WriteLine("6 - обменять доллары в евро");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("обменять рубли в доллары");
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
                        break;
                    case "2":
                        Console.WriteLine("обменять доллары в рубли");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rub += currencyCount / usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств");
                        }
                        break;
                    case "3":
                        Console.WriteLine("обменять рубли в евро");
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
                        break;
                    case "4":
                        Console.WriteLine("обменять евро в рубли");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        if (eur >= currencyCount)
                        {
                            eur -= currencyCount;
                            rub += currencyCount / eurToRub;
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств");
                        }
                        break;
                    case "5":
                        Console.WriteLine("обменять евро в доллары");
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
                        break;
                    case "6":
                        Console.WriteLine("обменять доллары в евро");
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
                        break;
                } 
                Console.WriteLine($"У вас на счету {rub} рублей, {usd} долларов, {eur} евро.");
            }
        }
    }
}
