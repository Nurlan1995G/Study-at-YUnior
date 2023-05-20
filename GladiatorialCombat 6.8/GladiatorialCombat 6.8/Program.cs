using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TaskCombat
{
    class Program  
    {
        static void Main(string[] args)
        {
            Fighter fighter = new Fighter();

            fighter.Fight();
        }
    }

    class Fighter
    {
        private Warrior _firstPlayer;
        private Warrior _secondPlayer;
        private List<Warrior> _warriors = new List<Warrior>();

        public Fighter()
        {
            AddWarrior();
        }

        public void Fight()
        {
            ConsoleKey desiredKey = ConsoleKey.Spacebar;

            _firstPlayer = SelectWarrior();
            Console.Clear();
            _secondPlayer = SelectWarrior();

            PressEnter(desiredKey);

            while (_firstPlayer.Health > 0 && _secondPlayer.Health > 0)
            {
                Console.Clear();

                _firstPlayer.Attack(_secondPlayer);
                _secondPlayer.Attack(_firstPlayer);
                Console.WriteLine();

                Console.WriteLine("---------Характеристики боя------");
                _firstPlayer.ShowStats();
                _secondPlayer.ShowStats();

                PressEnter(desiredKey);
            }

            ResultFight();
        }

        private void AddWarrior()
        {
            _warriors.Add(new Orc("Азог Завоеватель", 300, 50, 10));
            _warriors.Add(new Knight("Лонселот", 200, 50, 20));
            _warriors.Add(new Wizard("Кадгар", 180, 40, 5, 10, 15));
            _warriors.Add(new Dwarf("Гимли", 100, 70, 15, 50));
            _warriors.Add(new Elf("Леголас", 80, 65, 10, 10, 30));
        }

        private Warrior SelectWarrior()
        {
            Warrior warrior = null;

            string userInput;

            ShowFighters(_warriors);

            while (warrior == null)
            {
                if (_firstPlayer == null)
                {
                    Console.Write("Введите номер первого бойца: ");
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.Write("Введите номер второго бойца: ");
                    userInput = Console.ReadLine();
                }

                bool isNumber = int.TryParse(userInput, out int numberToFindWarrior);

                if (isNumber && numberToFindWarrior <= _warriors.Count && numberToFindWarrior > 0)
                {
                    warrior = _warriors[numberToFindWarrior - 1];
                    _warriors.Remove(warrior);
                }
                else
                {
                    Console.WriteLine("Вы вели неверную команду!");
                }
            }

            return warrior;
        }

        private void ShowFighters(List<Warrior> warriors)
        {
            for (int i = 0; i < warriors.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                warriors[i].ShowDescription();
                warriors[i].ShowStats();
                Console.WriteLine();
            }
        }

        private void ResultFight()
        {
            if (_firstPlayer.Health > _secondPlayer.Health)
            {
                Console.WriteLine($"Победил первый игрок: {_firstPlayer.Name}");
            }
            else if (_firstPlayer.Health < _secondPlayer.Health)
            {
                Console.WriteLine($"Победил второй игрок: {_secondPlayer.Name}");
            }
            else
            {
                Console.WriteLine("Ничья");
            }
        }

        private void PressEnter(ConsoleKey desiredKey)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != desiredKey)
            {
                Console.WriteLine($"Для продолжение нажмите: {desiredKey}");
                Console.ReadKey();
            }

            Console.WriteLine();
        }
    }

    class Warrior
    {
        public Warrior(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public virtual void Attack(Warrior warrior)
        {
            warrior.TakeDamage(Damage);
        }

        public virtual void ShowDescription() { }

        public void ShowStats()
        {
            Console.WriteLine($"Персонаж - {Name} | Здоровье  {Health} | Урон  {Damage} | Броня  {Armor}");
        }
    }

    class Orc : Warrior
    {
        private int _multiplicityOfChances = 3;
        private int _attackCount = 1;

        public Orc(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void Attack(Warrior warrior)
        {
            if (_attackCount % _multiplicityOfChances == 0)
            {
                warrior.TakeDamage(Damage);
                warrior.TakeDamage(Damage);

                Console.WriteLine($"{Name} - нанес двойной урон");
            }
            else
            {
                base.Attack(warrior);
            }

            _attackCount++;
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"Орк - {Name}: каждый {_multiplicityOfChances} удар наносит удвоенный урон");
        }
    }

    class Knight : Warrior
    {
        private int _multiplicityOfChances = 2;
        private int _takeDamageCount = 1;

        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void TakeDamage(int damage)
        {
            if (_takeDamageCount % _multiplicityOfChances == 0)
            {
                Console.WriteLine($"{Name} - выставил щит");
            }
            else
            {
                base.TakeDamage(damage);
            }

            _takeDamageCount++;
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"Рыцарь - {Name}: каждый {_multiplicityOfChances} удар ставит защиту и поглащает весь урон.");
        }
    }

    class Wizard : Warrior
    {
        private int _multiplicityOfChances = 3;
        private int _takeDamageCount = 1;

        public Wizard(string name, int health, int damage, int armor, int damageAsorption, int attackMagicBall) : base(name, health, damage, armor)
        {
            DamageAbsorption = damageAsorption;
            AttackMagicBall = attackMagicBall;
        }

        public int DamageAbsorption { get; private set; }
        public int AttackMagicBall { get; private set; }

        public override void TakeDamage(int damage)
        {
            damage -= DamageAbsorption;

            Console.WriteLine($"{Name} - поглатил удар противника в -{DamageAbsorption} единиц.");

            base.TakeDamage(damage);
        }

        public override void Attack(Warrior warrior)
        {
            if (_takeDamageCount % _multiplicityOfChances == 0)
            {
                warrior.TakeDamage(Damage + AttackMagicBall);

                Console.WriteLine($"{Name} - нанес удар магическим шаром в +{AttackMagicBall} единиц.");
            }
            else
            {
                base.Attack(warrior);
            }

            _takeDamageCount++;
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"Маг - {Name}: поглащает {DamageAbsorption} единиц урона. Каждый {_multiplicityOfChances} удар наносит магическим шаром {AttackMagicBall} единиц урона.");
        }
    }

    class Dwarf : Warrior
    {
        private int _multiplicityOfChances = 3;
        private int _attackCount = 1;

        public Dwarf(string name, int health, int damage, int armor, int hammerBlow) : base(name, health, damage, armor)
        {
            HammerBlow = hammerBlow;
        }

        public int HammerBlow { get; private set; }

        public override void Attack(Warrior warrior)
        {
            if (_attackCount % _multiplicityOfChances == 0)
            {
                warrior.TakeDamage(Damage + HammerBlow);

                Console.WriteLine($"{Name} - наносит удар молотом в +{HammerBlow} единиц.");
            }
            else
            {
                base.Attack(warrior);
            }

            _attackCount++;
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"Гном - {Name}: каждый {_multiplicityOfChances} удар бьет своим молотом и наносит {HammerBlow} единиц урона.");
        }
    }

    class Elf : Warrior
    {
        private int _multiplicityOfChances = 3;
        private int _attackCount = 1;

        public Elf(string name, int health, int damage, int armor, int replenishHealth, int arrowDamage) : base(name, health, damage, armor)
        {
            ReplenishHealth = replenishHealth;
            ArrowDamage = arrowDamage;
        }

        public int ReplenishHealth { get; private set; }
        public int ArrowDamage { get; private set; }

        public void HealthRepl()
        {
            Health += ReplenishHealth;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            HealthRepl();
        }

        public override void Attack(Warrior warrior)
        {
            if (_attackCount % _multiplicityOfChances == 0)
            {
                warrior.TakeDamage(Damage + ArrowDamage);

                Console.WriteLine($"{Name} - нанес урон стрелами в {ArrowDamage} единиц.");
            }
            else
            {
                base.Attack(warrior);
            }

            _attackCount++;
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"Эльф - {Name}: воспалняет {ReplenishHealth} единиц здоровья. Каждый {_multiplicityOfChances} удар, он наносит {ArrowDamage} единиц урона стрелами.");
        }
    }
}
