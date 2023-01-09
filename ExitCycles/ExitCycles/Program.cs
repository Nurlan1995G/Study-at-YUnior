using System;

namespace ExitCycles 
{
    class Exit      
    {
        static void Main(string[] args)  
        {
            int orderKitchensProducts;   
            string keyWord;
            string companyOrderOnline = "Amar";
            bool isKeyWord = false;

            Console.WriteLine($"Добро пожаловать в интернет магазин {companyOrderOnline} - все для кухни!");
            Console.WriteLine("Для предотвращения покупок, введите ключевое слово - exit");
            Console.Write("Введите, сколько вы хотите приобрести товара: ");
             orderKitchensProducts = Convert.ToInt32(Console.ReadLine());
          

            while (true)
            {
                Console.Write("Введите слово exit, если хотите выйти: ");
                keyWord = Console.ReadLine();
                Console.WriteLine($"Вы приобрели {orderKitchensProducts++} товара");
                Console.ReadKey();
                
                if (keyWord == "exit")
                {
                    Console.Write("Вы вышли из программы!");
                    break;
                }
            }
        }
    }
}

