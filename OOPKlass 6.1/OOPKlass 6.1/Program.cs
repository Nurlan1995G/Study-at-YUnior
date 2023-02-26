using System;

namespace OOP
{
    class Program 
    {
        static void Main(string[] args)
        {
            Player player = new Player("Nurlan", 27, 'M');

            player.ShowInfo();
        }
    }

    class Player
    {
        private string _name;
        private int _age;
        private char _gender;

        public Player(string name, int age, char gender)
        {
            _name = name;    
            _age = age;  
            _gender = gender;    
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Игрок: \nИмя - {_name}, \nВозраст - {_age}, \nПол - {_gender}");
        }
    }
}
