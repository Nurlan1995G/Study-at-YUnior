using System;


namespace TaskC      //Вы заходите в поликлинику и видите огромную очередь из старушек, вам нужно рассчитать
                     //время ожидания в очереди.     Формально: Пользователь вводит кол-во людей в очереди.
                     //Фиксированное время приема одного человека всегда равно 10 минутам.Пример ввода:
                     //Введите кол-во старушек: 14   Пример вывода: "Вы должны отстоять в очереди 2 часа и 20 минут."
{
    class Task
    {
        static void Main(string[] args)
        {
            int patientsCount = 1;  
            int expectationTime = 10;  
            Console.Write("Введите количество пациентов: ");
            patientsCount = Convert.ToInt32(Console.ReadLine());
            patientsCount *= expectationTime;
            int chas = patientsCount / 60;
            int min = patientsCount % 60;
            Console.WriteLine($"Вы должны отстоять в очереди минут {chas} часа {min} минут");
        }
    }
}

