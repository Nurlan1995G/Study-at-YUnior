using System;

namespace ExitCycles 
{
    class Exit      
    {
        static void Main(string[] args)  
        {
            int orderKitchensProducts;   
            string keyWord = "exit";
            string companyOrderOnline = "Amar";
            bool isKeyWord = false;

            Console.WriteLine($"Добро пожаловать в интернет магазин {companyOrderOnline} - все для кухни!");
            Console.WriteLine($"Для предотвращения покупок, введите ключевое слово - {keyWord}");
            Console.Write("Введите, сколько вы хотите приобрести товара: ");
            orderKitchensProducts = Convert.ToInt32(Console.ReadLine());
            keyWord = Console.ReadLine();

            while (true)
            {
                Console.WriteLine($"Вы приобрели {orderKitchensProducts++} товара");
                Console.ReadKey();
                if(keyWord != null)
                {
                    Console.WriteLine("Завершаем программу");
                    break;
                }
                else
                {
                    Console.Write("Продолжаем!");
                }

            }
        }
    }
}

