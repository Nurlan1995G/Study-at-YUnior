using System;

namespace TaskShuffle
{
    class Program  
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ShuffleArray(array);
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();
            int randomIndex;
            int shuffledElement;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                randomIndex = random.Next(i);
                shuffledElement = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = shuffledElement;
                Console.Write(shuffledElement + " ");
            }

            Console.WriteLine();
        }
    }
}