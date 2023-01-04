using System;


namespace TaskC     
{
    class Task
    {
        static void Main(string[] args)
        {
            int hoursTimeCount = 60;
            int patientsCount;  
            int inspectionTime = 10; 
            int expectationTime;
            Console.Write("Введите количество пациентов: ");
            patientsCount = Convert.ToInt32(Console.ReadLine());
            expectationTime = patientsCount * inspectionTime;
            int waitingHours = expectationTime / hoursTimeCount;
            int waitingMinutes = expectationTime % hoursTimeCount;
            Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа {waitingMinutes} минут");
        }
    }
}

