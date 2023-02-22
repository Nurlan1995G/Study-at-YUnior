using System;

namespace AdvancedPersonnel
{
    class AdvancedAccounting   
    {
        static void Main(string[] args)
        {
            List<string> name = new List<string>();
            List<string> post = new List<string>();
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
                    CompletionDossier(name, post);
                }
                else if(userInput == outputAllDossiers)
                {
                    ShowDossiers(name, post);
                }
                else if(userInput == deleteDossier)
                {
                    DeleteDossier(name, post);
                }
                else if(userInput == exit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы!");
                    isWorking = false;
                }
            }
        }

        static void CompletionDossier(List<string> name, List<string> post)
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

                CompletionInformation(name, userInputName);
                CompletionInformation(post, userInputPost);
            }
        }

        static void CompletionInformation(List<string> name, string userInput)
        {
            name.Add(userInput);
        }

        static void ShowDossiers(List<string> name, List<string> post)
        {
            int number = 1;

            if(name.Count != 0)
            {
                for (int i = 0; i < name.Count; i++) 
                {
                    Console.WriteLine($"{number}) ФИО - {name[i]}; должность - {post[i]}");
                    number++;
                }
            }
            else
            {
                Console.WriteLine("Резюме больше нет. Добавьте!");
            }
        }

        static void DeleteDossier(List<string> name, List<string> post)
        {
            int initialValue = 1;

            if(name.Count != 0)
            {
                Console.Write("Введите индекс досье, которое вы хотите удалить: ");
                int indexRemoveDossier = Convert.ToInt32(Console.ReadLine()) - initialValue;

                if(name.Count - initialValue < indexRemoveDossier || indexRemoveDossier < 0)
                {
                    Console.WriteLine($"Такого досье с индексом {indexRemoveDossier} не существует!");
                }
                else
                {
                    DeleteInformation(name, indexRemoveDossier);
                    DeleteInformation(post, indexRemoveDossier);
                    Console.WriteLine($"Вы успешно удалили {name.Count} досье");
                }
            }
            else
            {
                Console.WriteLine("Больше досье нет. Добавьте пожалуйста в разделе <1>");
            }
        }

        static void DeleteInformation(List<string> name, int indexRemove)
        {
            name.RemoveAt(indexRemove);
        }
    }
}
