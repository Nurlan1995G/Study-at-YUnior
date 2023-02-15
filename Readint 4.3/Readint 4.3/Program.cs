namespace Readint
{
    class Read  
    {
        static void Main(string[] args)
        {
            int number;
            bool isWorking = true;

            while (isWorking)
            {
                RaedNumber();
            }
        }

        static int RaedNumber()
        {
            int number = 0;
            bool isWorking = true;
            string userInput;

            while (isWorking)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();

                bool isNumber = int.TryParse(userInput, out number);

                if (isNumber)
                {
                    Console.WriteLine($"Преобразование числа прошло верно - {number}");
                }
                else
                {
                    Console.WriteLine($"Преобразование прошло не верно. Введите еще раз!");
                }
            }

            return number;
        }
    }
}
