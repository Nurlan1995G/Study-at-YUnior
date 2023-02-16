using System;
using System.Xml.Linq;

namespace PersonnalAccounting
{
    class Personnal  
    {
        static void Main(string[] args)
        {
            string userInputName = "name";
            string userInputPost = "post";
            bool isWorking = true;
            string userInputExit = "exit";
            string userInput;
            string addDossier = "1";
            string outputAllDossiers = "2";
            string deleteDossier = "3";
            string searchName = "4";
            string exit = "5";
            string[] post = new string[0];
            string[] name = new string[0];

            Console.WriteLine("Добро пожаловать на сайт HH.RU!");

            while (isWorking)
            {
                Console.WriteLine($"\nГлавное меню \nВведите номер интересующего вам пункта: \n{addDossier} - Добавить досье;\n{outputAllDossiers} - Вывести все досье;" +
                    $"\n{deleteDossier} - Удалить досье;\n{searchName} - Поиск по фамилии;\n{exit} - Выход");
                userInput = Console.ReadLine();

                if(userInput == addDossier)
                {
                    CompletionDossier(out name, out post);
                }
                else if(userInput == outputAllDossiers)
                {
                    FormattedOutput(ref name, ref post);
                }
                else if(userInput == deleteDossier)
                {
                    DeleteDossier(ref name);
                }
                else if(userInput == searchName)
                {
                    SearchName(ref name,ref post);
                }
                else if (userInput == exit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorking = false;
                }
            }
        }

        static string[] CompletionDossier(out string[] name,out string[] post )
        {
            bool isWorking = true;
            name = new string[0];
            post = new string[0];
            string userInputName = "";
            string userInputPost = "";
            string userInputMain = "main";
            string userInput;

            while (isWorking)
            {
                Console.Write("Введите ваше имя: ");
                userInputName = Console.ReadLine();
                Console.Write("Введите вашу должность: ");
                userInputPost = Console.ReadLine();
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

                numFIO[numFIO.Length - 1] = userInputName;
                name = numFIO;


                for (int i = 0; i < post.Length; i++)
                {
                    numPost[i] = post[i];
                }

                numPost[numPost.Length - 1] = userInputPost;
                post = numPost;
            }

            return name;
            return post;
        }

        static string[] FormattedOutput(ref string[] name, ref string[] post)
        {
            int number = 1;

            for(int i = 0; i < name.Length; i++)
            {
                Console.WriteLine($"{number} - ФИО - {name[i]}; должность - {post[i]}");
                number++;
            }

            return name;
            return post;
        }

        static string[] DeleteDossier(ref string[] name)
        {
            string[] tempName = new string[name.Length - 1];

            tempName = name;

            return tempName;
        }

        static string[] SearchName(ref string[] name,ref string[] post)
        {
            bool findIsName = false;
            string userInput;
            Console.Write("Введите имя автора резюме, которого вы ищете: ");
            userInput = Console.ReadLine();

            for(int i = 0; i < name.Length; i++)
            {
                if(userInput.ToLower() == name[i].ToLower())
                {
                    Console.WriteLine($"Автор резюме {name[i]}, должность: {post[i]}");
                    findIsName = true;
                }
            }

            if(findIsName == false)
            {
                Console.WriteLine("Такого пользователя нет!");
            }

            return name;
        }
    }
}