using System;
using System.Xml.Linq;

namespace PersonnalAccounting
{
    class Personnal  //Будет 2 массива: 1) фио 2) должность. Описать функцию заполнения массивов досье, функцию форматированного вывода, функцию поиска по фамилии и функцию удаления досье.  Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
                     //Программа должна быть с меню, которое содержит пункты:  1) добавить досье
                     //2) вывести все досье(в одну строку через “-” фио и должность с порядковым номером в начале)
                     //3) удалить досье(Массивы уменьшаются на один элемент.Нужны дополнительные проверки, чтобы не возникало ошибок)
                     //4) поиск по фамилии     5) выход
    {
        static void Main(string[] args)
        {
            string userInputName = "name";
            string userInputPost = "post";
            string userInput;
            bool isWorking = true;
            string userInputExit = "exit";
            int gettingStarted = 1;
            int continuationWork = 2;
            string userInputInt;
            string user1 = "1";
            string user2 = "2";
            string user3 = "3";
            string user4 = "4";
            string user5 = "5";
            string[] post = new string[0];
            string[] name = new string[0];

            Console.WriteLine("Добро пожаловать на сайт HH.RU!");

            while (isWorking)
            {
                Console.WriteLine($"Длина Name {name.Length}");
                Console.WriteLine($"\nГлавное меню \nВведите номер интересующего вам пункта: \n{user1} - Добавить досье;\n{user2} - Вывести все досье;" +
                    $"\n{user3} - Удалить досье;\n{user4} - Поиск по фамилии;\n{user5} - Выход");
                userInputInt = Console.ReadLine();

                if(userInputInt == user1)
                {
                    CompletionDossierFIO(out name, out post);
                }
                else if(userInputInt == user2)
                {
                    
                }
                else if(userInputInt == user3)
                {
                    DeleteDossier(name);
                }
                else if(userInputInt == user4)
                {
                    SearchName(name, post);
                }
                else if (userInputInt == user5)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorking = false;
                }
            }
        }

        static string[] CompletionDossierFIO(out string[] name,out string[] post )
        {
            bool isWorking = true;
            name = new string[0];
            post = new string[0];
            string nameFIO = "";
            string namePost = "";
            string userInputMain = "main";
            string userInput;

            while (isWorking)
            {
                Console.Write("Введите ваше имя: ");
                nameFIO = Console.ReadLine();
                Console.Write("Введите вашу должность: ");
                namePost = Console.ReadLine();
                Console.Write($"Введите команду <{userInputMain}> для выхода в главное меню: ");
                userInput = Console.ReadLine();

                if (userInput == userInputMain)
                {
                    isWorking = false;
                }

                string[] numFIO = new string[name.Length + 1];
                string[] numPost = new string[post.Length + 1];

                for (int i = 0; i < name.Length; i++)
                {
                    numFIO[i] = name[i];
                }

                numFIO[numFIO.Length - 1] = nameFIO;
                name = numFIO;

                for (int i = 0; i < post.Length; i++)
                {
                    numPost[i] = post[i];
                }

                numPost[numPost.Length - 1] = namePost;
                post = numPost;
            }

            return name;
        }

        static void FormattedOutput()
        {

        }

        static string[] DeleteDossier(string[] name)
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(name.Length);
                string[] nameFIO = new string[name.Length - 1];

                name = nameFIO;

                Console.WriteLine($"Зарегистрированных резюме на сайте - {name.Length}");
                isWorking = false;
            }

            return name;
        }

        static string[] SearchName(string[] name,string[] post)
        {
            bool FIOIsFind = false;
            string searchFIO;
            Console.Write("Введите имя автора резюме, которого вы ищете: ");
            searchFIO = Console.ReadLine();

            for(int i = 0; i < name.Length; i++)
            {
                if(searchFIO == name[i])
                {
                    Console.WriteLine($"Автор резюме {name[i]}, должность: {post[i]}");
                    FIOIsFind = true;
                }
            }

            if(FIOIsFind == false)
            {
                Console.WriteLine("Такого пользователя нет!");
            }

            return name;
        }
    }
}