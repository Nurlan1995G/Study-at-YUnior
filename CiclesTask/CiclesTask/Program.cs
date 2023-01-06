using System;

namespace CiclesTask
{
    class Task           
    {
        static void Main(string[] args)
        {
            string nameWebsite = "Azura";
            string textToPrint;
            int repeatData;

            Console.WriteLine($"Добро пожаловать на наш сайт {nameWebsite}, здесь вы можете написать текст в неограниченом кол-ве" +
                $" раз и отправить на печать");
            Console.Write("Введите текст: ");
            textToPrint = Console.ReadLine();
            Console.Write("Введите сколько раз нужно вывести текст: ");
            repeatData = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < repeatData; i++)
                Console.WriteLine(textToPrint);
        }
    }
}
