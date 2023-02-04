using System;

namespace RepetitionsNumber
{
    class ArrayNumber  // В массиве чисел найдите самый длинный подмассив из одинаковых чисел. Дано 30 чисел.Вывести в консоль сам массив, число, которое само больше раз повторяется подряд и количество повторений. Дополнительный массив не надо создавать.
                       // Пример: {5, 5, 9, 9, 9, 5, 5} - число 9 повторяется большее число раз подряд.
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];
            Random random = new Random();
            int number = 1;
            int num = int.MinValue;

            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1,9);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine("\n");

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    number++;
                }
                else if(number == 1)
                {
                    continue;
                }
                else
                {
                    Console.Write($"Число - {numbers[i - 1]} повторяется {number} раза; ");
                    number = 1;
                }
            }

            if (numbers[numbers.Length - 1] == numbers[numbers.Length - 2])
            {
                Console.Write($"Число - {numbers[numbers.Length - 1]} повторяется {number} раза; ");
            }

            Console.WriteLine();
        }
    }
}
