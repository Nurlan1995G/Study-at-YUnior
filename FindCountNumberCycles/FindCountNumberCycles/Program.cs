﻿using System;

namespace FindCycles
{
    class Cycles   
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int receivedNumber;
            int number = 0;
            int smallNumber = 1;
            int bigNumber = 28;
            int startNumber = 100;
            int endingNumber = 999;

            receivedNumber = random.Next(smallNumber, bigNumber);
            Console.WriteLine($"Число N = {receivedNumber}");

            for(int i = 0; i < endingNumber; i += receivedNumber)
            {
                if(i <= startNumber)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Число - {i}");
                    Console.WriteLine("Не трехзначное число");
                }

                if(i >= startNumber)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Число - {i}");
                    Console.WriteLine("Кратное число");
                    number++;
                }

                Console.WriteLine($"Кол-во трехзначных натуральных чисел равна: {receivedNumber}");
            }
        }
    }
}
