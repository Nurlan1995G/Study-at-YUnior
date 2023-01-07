using System;

namespace SequenceCycles
{
    class Cycles         
    {
        static void Main(string[] args)
        {
            int wateringCactusWater = 96;   
            int wateringPeriod = 7;   
            int wateringBegining = 5;

            for(int i = wateringBegining; i <= wateringCactusWater; i+= wateringPeriod)
                Console.WriteLine($"Поливать кактус водой в указанные дни {i}");
        }
    }
}
