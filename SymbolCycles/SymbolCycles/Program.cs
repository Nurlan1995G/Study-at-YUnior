using System;

namespace CyclesSymbol
{
    class CyclesSym
    {
        static void Main(string[] args)
        {
            string userInputName;
            var userInputSymbol = "";
            int x;
            int y;
            int lenghtString;
            int userInputN;


            
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(x, y);
            Console.Write("Введите имя: ");
            userInputName = Console.ReadLine();
            Console.WriteLine( 1 + (userInputName.Length) + 1);
            userInputN = userInputName.Length;
            Console.Write("Введите символ для прикола: ");
            userInputSymbol = Console.ReadLine();

            
        }
    }
}
