using System;


namespace TaskC     
{
    class Task
    {
        static void Main(string[] args)
        {
            int patientsCount;  
            int inspectionTime = 10; 
            int expectationTime;
            Console.Write("Введите количество пациентов: ");
            patientsCount = Convert.ToInt32(Console.ReadLine());
            expectationTime = patientsCount * inspectionTime;
            int chas = expectationTime / 60;
            int min = expectationTime % 60;
            Console.WriteLine($"Вы должны отстоять в очереди {chas} часа {min} минут");
        }
    }
}

