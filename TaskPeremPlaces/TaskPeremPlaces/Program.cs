using System;

namespace TaskPer    
{
    class Task
    {
        static void Main(string[] args)
        {
            string name = "Галиев";
            string surname = "Нурлан";
            Console.WriteLine($"Мое имя {name}, фамилия {surname}! ");
            (name, surname) = (surname, name);
            Console.WriteLine($"Мое имя {name}, фамилия {surname}! ");
        }
    }
}
