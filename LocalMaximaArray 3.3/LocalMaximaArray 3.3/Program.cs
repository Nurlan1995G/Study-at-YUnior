using System;

namespace LocalMaxima
{
    class Local   //Дан одномерный массив целых чисел из 30 элементов. Найдите все локальные максимумы и вывести их. (Элемент является локальным максимумом, если он не имеет соседей, больших, чем он сам)
                  //Крайние элементы являются локальными максимумами если не имеют соседа большего, чем они сами.  Программа должна работать с массивом любого размера.  Массив всех локальных максимумов не нужен.
    {
        static void Main(string[] args)
        {
            int[] fullNumbers = new int[30];
            Random random = new Random();
            int maxElement = int.MinValue;
            int number = 0;

            for(int i = 0; i < fullNumbers.Length; i++)
            {
                fullNumbers[i] = random.Next(0,9);
                Console.Write(fullNumbers[i] + " ");
                maxElement = fullNumbers[i];

                if (fullNumbers[i] < maxElement && maxElement > fullNumbers[i])
                {
                    Console.Write($"Локальнам максимум является элемент - {fullNumbers[i]}");
                }
            }
        }
    }
}
