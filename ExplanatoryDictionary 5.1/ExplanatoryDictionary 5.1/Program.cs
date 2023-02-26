using System;

namespace ExplanatoryDictionary
{
    class Explanatory
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cities = new Dictionary<string, string>();
            string userInput;
            bool isWorking = true;

            FillCities(cities);

            while (isWorking)
            {
                Console.WriteLine("Вы вошли на сайт <История городов России>.");
                Console.Write("Введите город, о котором вы хотите узнать: ");
                userInput = Console.ReadLine();

                ShowValue(cities, userInput);
            }
        }

        static void ShowValue(Dictionary<string,string> cities, string userInput)
        {
            if (cities.ContainsKey(userInput))
            {
                Console.WriteLine("\n" + cities[userInput] + "\n");
            }
            else
            {
                Console.WriteLine("\nТакого города нет в списке! Введите другой!\n");
            }
        }

        static void FillCities(Dictionary<string,string> cities)
        {
            cities.Add("Москва", "Столица России и город с численностью 13 млн.человек. Первое письменное упоминание о Москве относится к 1147 году.");
            cities.Add("Санкт-Петербург", "Второй город по размерам и численностью России. Численность более 5 млн.человек. История Санкт-Петербурга начинается с 1703 года со строительства Петропавловской крепости.");
            cities.Add("Нижний Новгород", "Один из многих городов миллионников России,численность 1,2 млн.человек. Нижний Новгород был основан князем Юрием Всеволодовичем в 1221 году.");
            cities.Add("Якутск", "Один из самых холодных городов России. Численность населения 303 т.человек. Температура зимой опускается до ниже 60 градусов по цельсию.");
            cities.Add("Сочи", "Самый теплый город России и к тому же самый длинный. Среднегодовая температура +14,2 градуса");
        }
    }
}
