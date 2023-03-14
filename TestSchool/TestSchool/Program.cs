using System;
using System.Globalization;

namespace CSLight    
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters = { new Fighter("Ra", 500, 20, 0), new Fighter("Bill", 200, 60, 10), new Fighter("Bob", 250, 15, 30), new Fighter("Crash", 300, 15, 10) };
            int indexFighter;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write($"{i} ");
                fighters[i].ShowStats();
            }

            Console.WriteLine("Выберете бойца правых ворот: ");
            indexFighter = Convert.ToInt32(Console.ReadLine());
            Fighter rightFighter = fighters[indexFighter];
            Console.WriteLine("Выберете бойца левых ворот: ");
            indexFighter = Convert.ToInt32(Console.ReadLine());
            Fighter leftFighter = fighters[indexFighter];

            while(rightFighter.Health > 0 && leftFighter.Health > 0)
            {
                Console.WriteLine();
                rightFighter.TakeDamage(leftFighter.Damage);
                leftFighter.TakeDamage(rightFighter.Damage);
                rightFighter.ShowStats();
                leftFighter.ShowStats();
            }
        }
    }

    class Fighter
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public int Health { get { return _health; } }

        public int Damage { get { return _damage; } }   

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name}, HP - {_health}, Dg - {_damage}, Armor - {_armor}");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
        }
    }

}
