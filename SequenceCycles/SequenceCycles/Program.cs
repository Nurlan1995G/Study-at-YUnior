using System;

namespace SequenceCycles
{
    class Cycles        
    {
        static void Main(string[] args)
        {
            int weightproducts = 100;
            int enumeration = 7;

            for(int i = 5; i < weightproducts; i+= enumeration)
                Console.WriteLine(i);
        }
    }
}
