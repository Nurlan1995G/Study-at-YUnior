using System;

namespace ExitCycles 
{
    class Exit      
    {
        static void Main(string[] args)  
        {
            int orderKitchensProducts = 1;  
            int numberOrder;
            string keyWordExit = "exit";
            string companyOrderOnline = "Amar";
            string userInputExit;
            bool isProgramWorks = true;

            Console.WriteLine($"Добро пожаловать в интернет магазин {companyOrderOnline} - все для кухни!");
            Console.WriteLine("Для предотвращения покупок, введите ключевое слово - exit");
            Console.Write("Введите, сколько вы хотите приобрести товара: ");
            numberOrder = Convert.ToInt32(Console.ReadLine());

            while (isProgramWorks)
            {
                numberOrder += orderKitchensProducts;
                Console.Write("Введите слово exit, если хотите выйти: ");
                userInputExit = Console.ReadLine();
                Console.WriteLine($"Вы приобрели {numberOrder} товара");

               if (userInputExit == keyWordExit)
               {
                    Console.Write("Вы вышли из программы!");
                    isProgramWorks = false;
               }
            }
        }
    }
}

