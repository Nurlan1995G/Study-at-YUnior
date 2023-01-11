using System;

namespace PassedTask
{
    class Passed
    {
        static void Main(string[] args)
        {
            string userInputName;   
            int userInputAge;      
            string setPassword;    
            string userInputPassword = "";
            string keyWorkEcs = "ecs";  
            string userInputEcs;     
            string foodCompanyWebsite = "Макфьюри";
            bool isEntranceCorrect = true;
            int orderPurchase1 = 1;
            int orderPurchase2 = 2;
            int orderPurchase3 = 3;
            int orderPurchase4 = 4;
            string changeColorFontWebsite = "font";
            int userInputOrder;
            string userInputChange;

            Console.WriteLine($"Добро пожаловать на сайт {foodCompanyWebsite}, пройдите регистрацию, если вы новый пользователь!");
            Console.Write("Введите ваше имя: ");
            userInputName = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            userInputAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите новый пароль: ");
            setPassword = Console.ReadLine();
            Console.WriteLine("Вы успешно зарегистрировались! Ввойдите в ваш личный кабинет.");
            Console.WriteLine($"Для выхода из сайта, введите команду - {keyWorkEcs}");
            
            while (isEntranceCorrect)
            {
                Console.Write("Введите пароль для входа: ");
                userInputPassword = Console.ReadLine();

                if (userInputPassword == setPassword)
                {
                    Console.WriteLine("Вы вели верный пароль!");
                    Console.WriteLine($"Здравствуйте {userInputName}, вы выполнили вход в ваш личный кабинет.");

                    Console.WriteLine($"Заказ: ");
                    Console.Write($"{orderPurchase1} - пиццы: ");
                    Console.Write($"{orderPurchase2} - закуски: ");
                    Console.Write($"{orderPurchase3} - напитки: ");
                    Console.Write($"{orderPurchase4} - алкоголь: ");
                    userInputOrder = Convert.ToInt32(Console.ReadLine());

                    if (userInputOrder == orderPurchase1)
                    {
                        Console.WriteLine("Раздел - пиццы: ");
                    }
                    else if (userInputOrder == orderPurchase2)
                    {
                        Console.WriteLine("Раздел - закуски: ");
                    }
                    else if (userInputOrder == orderPurchase3)
                    {
                        Console.WriteLine("Раздел - напитки: ");
                    }
                    else if (userInputOrder == orderPurchase4 && userInputAge >= 18)
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

                Console.Write($"Напоминаем, при введении команды - {keyWorkEcs}, будет выполнен выход из сайта: ");
                userInputEcs = Console.ReadLine();

                if (userInputEcs == keyWorkEcs)
                {
                    Console.WriteLine("Вы вели команды выхода из сайта!");
                    isEntranceCorrect = false;
                }
            }
        }
    }
}
