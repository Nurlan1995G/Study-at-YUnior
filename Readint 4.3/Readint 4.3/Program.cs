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
                RaedNumber(out number);

                Console.WriteLine($"Преобразование числа прошло верно - {number}");
            }
        }

        static int RaedNumber(out int number)
        {
            number = 0;
            bool isWorking = true;
            string userInput;

            while (isWorking)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();

                bool isCorrectExprenssion = int.TryParse(userInput, out number);

                if (isCorrectExprenssion)
                {
                    isWorking = false;
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
