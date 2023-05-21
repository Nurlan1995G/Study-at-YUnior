using System;
using System.Threading;

namespace WarTask
{
    class Program   
    {
        static void Main(string[] args)
        {
            Fight fight = new Fight();

            fight.Battle();
        }
    }

    class Fight
    {
        private Army _redArmy = new Army("Красная");
        private Army _blueArmy = new Army("Синяя");
        private Soldier _redSoldier;
        private Soldier _blueSoldier;

        public void Battle()
        {
            while (_redArmy.GetSoldierCount() > 0 && _blueArmy.GetSoldierCount() > 0)
            {
                _redSoldier = _redArmy.GetSoldierFromPlatoon();
                _blueSoldier = _blueArmy.GetSoldierFromPlatoon();

                _redArmy.ShowPlatoon(_redArmy);
                _blueArmy.ShowPlatoon(_blueArmy);

                Console.WriteLine($"\n{_redArmy.Country} - страна нападает");
                _redSoldier.Attack(_redSoldier);
                _redSoldier.UseSpecialAttack();

                Console.WriteLine($"\n{_blueArmy.Country} - страна нападает");
                _blueSoldier.Attack(_blueSoldier);
                _blueSoldier.UseSpecialAttack();

                RemoveSoldier();

                Console.WriteLine("Нажмите на любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            if (_redArmy.GetSoldierCount() <= 0 && _blueArmy.GetSoldierCount() <= 0)
            {
                Console.WriteLine("Оба погибли. Ничья");
            }
            else if (_redArmy.GetSoldierCount() <= 0)
            {
                Console.WriteLine($"{_blueArmy.Country} - выиграли битву");
            }
            else if (_blueArmy.GetSoldierCount() <= 0)
            {
                Console.WriteLine($"{_redArmy.Country} - выигали битву");
            }
        }

        private void RemoveSoldier()
        {
            if (_redSoldier.Health <= 0)
            {
                _redArmy.RemoveSoldierFromPlatoon(_redSoldier);
            }
            if (_blueSoldier.Health <= 0)
            {
                _blueArmy.RemoveSoldierFromPlatoon(_blueSoldier);
            }
        }
    }

    class Army
    {
        private Random _random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();

        public Army(string country)
        {
            Country = country;
            CreatePlatoon();
        }

        public string Country { get; private set; }

        public Soldier GetSoldierFromPlatoon()
        {
            return _soldiers[_random.Next(0, _soldiers.Count)];
        }

        public int GetSoldierCount()
        {
            return _soldiers.Count;
        }

        public void RemoveSoldierFromPlatoon(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public void ShowPlatoon(Army army)
        {
            int indexSoldier = 1;

            Console.WriteLine($"\nЧисленность войска - {army.Country}");

            foreach (Soldier soldier in _soldiers)
            {
                Console.WriteLine($"{indexSoldier++}) {soldier.Name} | Здоровье - {soldier.Health} | Урон - {soldier.Damage}");
            }
        }

        private List<Soldier> CreatePlatoon()
        {
            int maxShooterAmount = 5;
            int maxSniperAmount = 3;
            int maxHealth = 100;
            int minHealth = 75;
            int maxDamage = 50;
            int minDamage = 30;
            string shooterName = "Стрелок";
            string sniperName = "Снайпер";

            for (int i = 0; i < maxShooterAmount; i++)
            {
                _soldiers.Add(new Shooter(_random.Next(minHealth, maxHealth), _random.Next(minDamage, maxDamage), shooterName));
            }

            for (int i = 0; i < maxSniperAmount; i++)
            {
                _soldiers.Add(new Sniper(_random.Next(minHealth, maxHealth), _random.Next(minDamage, maxDamage), sniperName));
            }

            return _soldiers;
        }
    }

    abstract class Soldier
    {
        public Soldier(int health, int damage, string name)
        {
            Health = health;
            Damage = damage;
            Name = name;
        }

        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public string Name { get; protected set; }

        public void Attack(Soldier soldier)
        {
            TakeDamage(soldier.Damage);
        }

        public void UseSpecialAttack()
        {
            Random random = new Random();
            int chanceUseSkill = 4;
            int rangeMaximNumbers = 5;
            int randomNumber = random.Next(rangeMaximNumbers);

            if (randomNumber == chanceUseSkill)
            {
                UsePower();
            }
        }

        protected virtual void UsePower() { }

        private void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }

    class Sniper : Soldier
    {
        public Sniper(int health, int damage, string name) : base(health, damage, name) { }

        protected override void UsePower()
        {
            int damageBuff = 20;

            Console.WriteLine($"{Name} попадает в голову и наносит +{damageBuff}");

            Damage += damageBuff;
        }
    }

    class Shooter : Soldier
    {
        public Shooter(int health, int damage, string name) : base(health, damage, name) { }

        protected override void UsePower()
        {
            int damageBuff = 10;

            Console.WriteLine($"{Name} выпускает очеред во врага и наносит +{damageBuff} урона");

            Damage += damageBuff;
        }
    }
}
