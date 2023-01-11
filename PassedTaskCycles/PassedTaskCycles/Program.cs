namespace PassedTask
{
    class Passed
    {
        static void Main(string[] args)
        {
            string userInputName;   
            int userInputAge;      
            string setupPassword;    
            string userInputPassword = "";
            string keyWorkExit = "ecs";  
            string userInputExit;     
            string foodCompanyWebsite = "Макфьюри";
            bool isProgramWorks = true;
            int orderPurchasePizzas = 1;
            int orderPurchaseSnacks = 2;
            int orderPurchaseDrinks = 3;
            int orderPurchaseAlcohol = 4;
            string changeColorFontWebsite = "font";
            int userInputOrder;
            string userInputChange;
            int ComingOfAge = 18;

            Console.WriteLine($"Добро пожаловать на сайт {foodCompanyWebsite}, пройдите регистрацию, если вы новый пользователь!");
            Console.Write("Введите ваше имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            userInputAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите новый пароль: ");
            setupPassword = Console.ReadLine();
            Console.WriteLine("Вы успешно зарегистрировались! Ввойдите в ваш личный кабинет.");
            Console.WriteLine($"Для выхода из сайта, введите команду - {keyWorkExit}");
            
            while (isProgramWorks)
            {
                Console.Write("Введите пароль для входа: ");
                userInputPassword = Console.ReadLine();

                if (userInputPassword == setupPassword)
                {
                    Console.WriteLine("Вы вели верный пароль!");
                    Console.WriteLine($"Здравствуйте {userInputName}, вы выполнили вход в ваш личный кабинет.");

                    Console.WriteLine($"Заказ: ");
                    Console.Write($"{orderPurchasePizzas} - пиццы: ");
                    Console.Write($"{orderPurchaseSnacks} - закуски: ");
                    Console.Write($"{orderPurchaseDrinks} - напитки: ");
                    Console.Write($"{orderPurchaseAlcohol} - алкоголь: ");
                    userInputOrder = Convert.ToInt32(Console.ReadLine());

                    if (userInputOrder == orderPurchasePizzas)
                    {
                        Console.WriteLine("Раздел - пиццы: ");
                    }
                    else if (userInputOrder == orderPurchaseSnacks)
                    {
                        Console.WriteLine("Раздел - закуски: ");
                    }
                    else if (userInputOrder == orderPurchaseDrinks)
                    {
                        Console.WriteLine("Раздел - напитки: ");
                    }
                    else if (userInputOrder == orderPurchaseAlcohol && userInputAge >= ComingOfAge)
                    {
                        Console.WriteLine("Вы вошли в раздел - алкоголь: ");
                    }
                    else
                    {
                        Console.WriteLine("Допуск только для 18+");
                    }

                    Console.WriteLine("Дополнительная фишка.");
                    Console.Write($"{changeColorFontWebsite} - изменение в сайте цвета шрифта: ");
                    userInputChange = Console.ReadLine();

                    if (userInputChange == changeColorFontWebsite)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
                else
                {
                    Console.WriteLine("Вы вели не верный пароль. Попробуйте еще раз!");
                }

                Console.Write($"Напоминаем, при введении команды - {keyWorkExit}, будет выполнен выход из сайта: ");
                userInputExit = Console.ReadLine();

                if (userInputExit == keyWorkExit)
                {
                    Console.WriteLine("Вы вели команды выхода из сайта!");
                    isProgramWorks = false;
                }
            }
        }
    }
}
