using System;
using System.Xml.Linq;

namespace PersonnalAccounting
{
    class Personnal  
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
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
                    CompletionDossier(ref name, ref post);
                }
                else if(userInput == outputAllDossiers)
                {
                    ShowDossiers(name, post);
                }
                else if(userInput == deleteDossier)
                {
                    DeleteDossier(ref name, ref post);
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

        static void CompletionDossier(ref string[] name,ref string[] post )
        {
            bool isWorking = true;
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

                CompletionInformation(ref name, userInputName);
                CompletionInformation(ref post, userInputPost);
            }
        }

        static void CompletionInformation(ref string[] name, string userInputName)
        {
            string[] tempName = new string[name.Length + 1];

            for (int i = 0; i < name.Length; i++)
            {
                tempName[i] = name[i];
            }

            tempName[tempName.Length - 1] = userInputName;
            name = tempName;
        }

        static void ShowDossiers(string[] name, string[] post)
        {
            int number = 1;

            if (name.Length != 0)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    Console.WriteLine($"{number} - ФИО - {name[i]}; должность - {post[i]}");
                    number++;
                }
            }
            else
            {
                Console.WriteLine("Резюме больше нет. Добавьте в разделе <1>");
            }
        }

        static void DeleteDossier(ref string[] name, ref string[] post)
        {
            if (name.Length != 0)
            {
                Console.Write("Введите номер досье, которое вы хотите удалить: ");
                int indexRemoveDossier = Convert.ToInt32(Console.ReadLine()) - 1;

                if(name.Length - 1 < indexRemoveDossier || indexRemoveDossier < 0)
                {
                    Console.WriteLine("Такого досье нет!");
                }
                else
                {
                    DeleteInformation(ref name, indexRemoveDossier);
                    DeleteInformation(ref post, indexRemoveDossier);
                    Console.WriteLine($"Вы успешно удалили {name.Length - 1} досье");
                }
            }
            else
            {
                Console.WriteLine("У вас нет больше досье. Состовьте новые.");
            }
        }

        static void DeleteInformation(ref string[] name, int indexRemoveDossier)
        {
            string[] tempName = new string[name.Length - 1];

            for(int i = 0; i < indexRemoveDossier; i++)
            {
                tempName[i] = name[i];
            }

            for (int i = indexRemoveDossier; i < tempName.Length; i++ )
            {
                tempName[i] = name[i + 1];
            }

            name = tempName;
        }

        static string[] SearchName(ref string[] name,ref string[] post)
        {
            bool findIsName = false;
            int number = 0;
            string userInputName;
            string[] tempName;
            
            Console.Write("Введите фамилию автора резюме, которого вы ищете: ");
            userInputName = Console.ReadLine();

            for(int i = 0; i < name.Length; i++)
            {
                number++;
                tempName = name[i].Split(' ');

                if(userInputName == tempName[0])
                {
                    Console.WriteLine($"Автор резюме - {number}) {name[i]}, должность: {post[i]}");
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