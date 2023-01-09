using System;

namespace ExitCycles 
{
    class Exit      
    {
        static void Main(string[] args)  
        {
            int orderKitchensProducts = 1;   
            string keyWordExit = "exit";
            string companyOrderOnline = "Amar";
            int userInput;
            bool isKeyWordExit = true;

            Console.WriteLine($"Добро пожаловать в интернет магазин {companyOrderOnline} - все для кухни!");
            Console.WriteLine("Для предотвращения покупок, введите ключевое слово - exit");
            Console.Write("Введите, сколько вы хотите приобрести товара: ");
            userInput = Convert.ToInt32(Console.ReadLine());

            while (isKeyWordExit)
            {
                userInput += orderKitchensProducts;
                Console.Write("Введите слово exit, если хотите выйти: ");
                keyWordExit = Console.ReadLine();
                Console.WriteLine($"Вы приобрели {userInput} товара");

               if (keyWordExit == "exit")
               { 
                   Console.Write("Вы вышли из программы!");
                   break;
               }
            }
        }
    }
}

