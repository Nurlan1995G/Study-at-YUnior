using System;

namespace AdvancedPersonnel
{
    class AdvancedAccounting   
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            List<string> posts = new List<string>();
            bool isWorking = true;
            string userInput;
            string addDossier = "1";
            string outputAllDossiers = "2";
            string deleteDossier = "3";
            string exit = "4";

            while (isWorking)
            {
                Console.WriteLine($"\nГлавное меню \nВведите номер интересующего вам пункта: \n{addDossier} - Добавить досье;\n{outputAllDossiers} - Вывести все досье;\n{deleteDossier} - Удалить досье;\n{exit} - Выход");
                userInput = Console.ReadLine();

                if(userInput == addDossier)
                {
                    AddDossier(names, posts);
                }
                else if(userInput == outputAllDossiers)
                {
                    ShowDossiers(names, posts);
                }
                else if(userInput == deleteDossier)
                {
                    DeleteDossier(names, posts);
                }
                else if(userInput == exit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorking = false;
                }
            }
        }

        static void AddDossier(List<string> names, List<string> posts)
        {
            bool isWorking = true;
            string userInputName = "";
            string userInputPost = "";
            string main = "main";
            string userInput;

            while (isWorking)
            {
                Console.Write("Введите ваше ФИО: ");
                userInputName = Console.ReadLine();
                Console.Write("Введите вашу должность: ");
                userInputPost = Console.ReadLine();
                Console.Write($"Введите команду <{main}> для выхода в главное меню: ");
                userInput = Console.ReadLine();

                if(userInput == main)
                {
                    isWorking = false;
                }

                names.Add(userInputName);
                posts.Add(userInputPost);
            }
        }

        static void AddDossierInformation(List<string> name, string userInput)
        {
            name.Add(userInput);
        }

        static void ShowDossiers(List<string> names, List<string> posts)
        {
            int number = 1;

            if(names.Count != 0)
            {
                for (int i = 0; i < names.Count; i++) 
                {
                    Console.WriteLine($"{number}) ФИО - {names[i]}; должность - {posts[i]}");
                    number++;
                }
            }
            else
            {
                Console.WriteLine("Резюме больше нет. Добавьте!");
            }
        }

        static void DeleteDossier(List<string> names, List<string> posts)
        {
            int initialValue = 1;
            int number;

            if(names.Count != 0)
            {
                Console.Write("Введите индекс досье, которое вы хотите удалить: ");
                string indexRemoveDossier = Console.ReadLine();

                bool isNumbers = int.TryParse(indexRemoveDossier, out number);

                if (isNumbers)
                {

                    if (names.Count - initialValue < number || number < 0)
                    {
                        Console.WriteLine($"Такого досье с номером {number} не существует!");
                    }
                    else
                    {
                        names.RemoveAt(number - initialValue);
                        posts.RemoveAt(number - initialValue);
                        Console.WriteLine($"Вы успешно удалили {names.Count} досье");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введенна некоректная команда.");
                }
            }
            else
            {
                Console.WriteLine("Больше досье нет. Добавьте пожалуйста в разделе <1>");
            }
        }
    }
}
