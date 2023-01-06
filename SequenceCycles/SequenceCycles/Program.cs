using System;

namespace SequenceCycles
{
    class Cycles        
    {
        static void Main(string[] args)
        {
            int weightProducts = 100;
            int enumProducts = 7;

            for(int i = 5; i < weightProducts; i+= enumProducts)
                Console.WriteLine(i);
        }
    }
}
