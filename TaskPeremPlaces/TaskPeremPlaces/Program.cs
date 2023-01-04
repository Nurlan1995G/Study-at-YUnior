using System;

namespace TaskPer    //Даны две переменные. Поменять местами значения двух переменных.
                     //Вывести на экран значения переменных до перестановки и после. К примеру, есть две переменные
                     //имя и фамилия, они сразу инициализированные, но данные не верные, перепутанные.Вот эти
                     //данные и надо поменять местами через код.
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
