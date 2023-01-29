using System;

namespace LocalMaxima
{
    class Local   //Дан одномерный массив целых чисел из 30 элементов. Найдите все локальные максимумы и вывести их. (Элемент является локальным максимумом, если он не имеет соседей, больших, чем он сам)
                  //Крайние элементы являются локальными максимумами если не имеют соседа большего, чем они сами.  Программа должна работать с массивом любого размера.  Массив всех локальных максимумов не нужен.
    {
        static void Main(string[] args)
        {
            int rowNumber = 30;
            int[] numbers = new int[rowNumber];
            Random random = new Random();
            int stepNumber = 1;
            int maxRandomNumber = 9;
            int minRandomNumber = 1;
            int intialValue = 1;
            int followingValue = 2;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(numbers[i] + " ");

                if (i == 1)
                {
                    if (numbers[i] > numbers[i - intialValue])
                    {
                        Console.Write($"({numbers[i]}) ");
                    }
                    stepNumber++;
                }
                else if (i == stepNumber)
                {
                    if (numbers[i-intialValue] > numbers[i-followingValue] && numbers[i-intialValue] > numbers[i])
                    {
                        Console.Write($"({numbers[i-1]}) ");
                    }
                    stepNumber++;
                }
            }
        }
    }
}
