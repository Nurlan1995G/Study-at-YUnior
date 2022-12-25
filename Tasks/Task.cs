using System;

namespace Tasks    // Задача   Вы задаете вопросы пользователю, по типу "как вас зовут",
                   // "какой ваш знак зодиака" и тд, после чего, по данным, которые он ввел,
                   // формируете небольшой текст о пользователе.

{
    class Task
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            string zadiak;
            string work;

            Console.Write("Как вас зовут:");
            name = Console.ReadLine();
            Console.Write("Сколько вам лет:");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Какой ваш знак задиака:");
            zadiak = Console.ReadLine();
            Console.Write("Кем вы работаете:");
            work = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age} лет, вы {zadiak} и работаю {work}");
        }
    }
}
