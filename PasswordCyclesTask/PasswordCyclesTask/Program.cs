using System;

namespace CyclesTask
{
    class Cycles   
    {
        static void Main(string[] args)
        {
            string passwordForAccess = "Hero777";   
            int attemptsCount = 3;  
            string userInput;
            int minusOne = 1;

            for(int i = 0; i < attemptsCount; i++)
            {
                Console.Write("Введите пароль для входа в секретное окно: ");
                userInput = Console.ReadLine();
                if(passwordForAccess == userInput)
                {
                    Console.WriteLine("Секретное окно открылось!");
                    Console.WriteLine("Скоро мы идем на Аватар 2: Путь воды, ждали этого 13 лет!!!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Введите пароль еще раз. У вас осталось {attemptsCount - i - minusOne} попыток.");
                }
            }
        }
    }
}
