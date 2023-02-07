using System;

namespace RepetitionsNumber
{
    class ArrayNumber  
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];
            Random random = new Random();
            int number = 1;
            int receivedNumber = 0;
            int maxValue = int.MinValue;
            int startIteration = 1;
            int originalNumber = 1;

            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1,9);
                Console.Write(numbers[i] + " ");

                if (i > startIteration)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        number++;
                    }
                    else
                    {
                        number = originalNumber;
                    }

                    if (maxValue < number)
                    {
                        maxValue = number;
                        receivedNumber = numbers[i];
                    }
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine($"Число - {receivedNumber} повторяется {maxValue} раз");
            Console.WriteLine();
        }
    }
}
