using System;

namespace TaskC     
{
    class Task
    {
        static void Main(string[] args)
        {
            int totalTimeQueue;
            int minutesInHour = 60;
            int patientsCount;  
            int inspectionTime = 10;
            int waitingHours;
            int waitingMinutes; 
            Console.Write("Введите количество пациентов: ");
            patientsCount = Convert.ToInt32(Console.ReadLine());
            totalTimeQueue = patientsCount * inspectionTime;
            waitingHours = totalTimeQueue / minutesInHour;
            waitingMinutes = totalTimeQueue % minutesInHour;
            Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа {waitingMinutes} минут");
        }
    }
}

