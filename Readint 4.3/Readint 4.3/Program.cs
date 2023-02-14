namespace Readint
{
    class Read  //Написать функцию, которая запрашивает число у пользователя (с помощью метода Console.ReadLine() ) и пытается сконвертировать его в тип int (с помощью int.TryParse()
                //Если конвертация не удалась у пользователя запрашивается число повторно до тех пор, пока не будет введено верно.После ввода, который удалось преобразовать в число, число возвращается.   P.S Задача решается с помощью циклов
                //P.S Также в TryParse используется модфикатор параметра out
    {
        static void Main(string[] args)
        {
            int number;
            bool isWorking = true;

            while (isWorking)
            {
                MakingNumber(out number);

                Console.WriteLine($"Преобразование числа прошло верно - {number}");
            }
        }

        static int MakingNumber(out int number)
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
                    return number;
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
