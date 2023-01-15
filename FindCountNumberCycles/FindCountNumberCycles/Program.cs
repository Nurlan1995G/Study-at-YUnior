using System;

namespace FindCycles
{
    class Cycles    
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int receivedNumber;  
            int smallNumber = 1;
            int bigNumber = 27;

            receivedNumber = random.Next(smallNumber, bigNumber);

            while (receivedNumber > 0)
            {
                receivedNumber = random.Next(smallNumber, bigNumber + 1);
                Console.WriteLine(receivedNumber);
                Console.ReadKey();

                if (smallNumber < receivedNumber && receivedNumber < bigNumber)
                {
                    Console.WriteLine($"{smallNumber} < {receivedNumber} < {bigNumber}");
                }
                else if(smallNumber == receivedNumber && receivedNumber < bigNumber)
                {
                    Console.WriteLine($"{smallNumber} = {receivedNumber} < {bigNumber}");
                }
                else if(smallNumber < receivedNumber && receivedNumber == bigNumber)
                {
                    Console.WriteLine($"{smallNumber} < {receivedNumber} = {bigNumber}");
                }
            }
        }
    }
}
