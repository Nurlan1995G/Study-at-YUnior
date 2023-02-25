using System;

namespace PerenthesisCycles
{
    class Cycles  
    {
        static void Main(string[] args)
        {
            string userInput;
            var symbolLeftParenthesis = '(';
            var symbolRightParenthesis = ')';
            int countLeftParenthesis = 0;
            int countRightParenthesis = 0; 
            int countSymbol = 0;

            Console.Write("Введите скобочные выражение и узнаете, верныли ли они, а также их глубину : ");
            userInput = Console.ReadLine();

            for(int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == symbolLeftParenthesis)
                {
                    countLeftParenthesis++;
                    countSymbol++;
                }
                else if(userInput[i] == symbolRightParenthesis)
                {
                    countRightParenthesis++;   
                }
            }

            if(countLeftParenthesis == countRightParenthesis && userInput[0] != ')' && userInput.Length - 1 != '(')
            {
                Console.WriteLine($"\nВы вели коректное скобочное выражение и глубина ее составляет - {countSymbol}");
            }
            else
            {
                Console.WriteLine("Скобочное выражение не верное!");
            }
        }
    }
}