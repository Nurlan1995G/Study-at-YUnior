using Microsoft.VisualBasic;
using System;

namespace BossFight
{
    class Boss   
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string magicianShadow = "Теневой маг";
            string bossDaran = "Босс Даран";
            int magicianValueHealthFrom = 450;
            int magicianValueHealthBefory = 700;
            int bossValueHealthFrom = 1500;
            int bossValueHealthBefory = 2000;
            int bossValueDamageFrom = 90;
            int bossValueDamageBefory = 140;
            int magicianShadowHealth = random.Next(magicianValueHealthFrom, magicianValueHealthBefory);
            int bossHealth = random.Next(bossValueHealthFrom, bossValueHealthBefory);
            int magicianShadowDamage;
            int bossDamage = random.Next(bossValueDamageFrom, bossValueDamageBefory);
            int userInputAttack;
            int rashamonSpell = 1;
            int huganzakuraSpell = 2;
            int interdimensionalRift = 3;
            int magicianRashamonSpellDamage = 100;  
            int magicianHuganzakuraSpellDamage = 150;   
            int magicianInterdimensionalRift = 250;
            int replenishmentHealth = 100;
            bool isLastBattle = true;
            bool isActivHuganzakura = false;

            Console.WriteLine($"Добро пожаловать на последнию локацию {magicianShadow}, тут вы сразитесь со своим последним противником и после отправитесь на покой. И ваш последний противник - {bossDaran}");
            Console.WriteLine("Характеристики перед боем.");
            Console.WriteLine($"Теневой маг - {magicianShadowHealth} хп");
            Console.WriteLine($"Босс - {bossHealth} хп, {bossDamage} урона от босса");

            Console.WriteLine($"{magicianShadow} - заклинания: ");
            Console.WriteLine($"При нажатии на клавишу - {rashamonSpell}, доступно заклинание Рашамон (призывает теневого духа для нанесения атаки), наносит {magicianRashamonSpellDamage} урона противнику.");
            Console.WriteLine($"При нажатии на клавишу - {huganzakuraSpell}, доступно заклинание Хуганзукура, наносит {magicianHuganzakuraSpellDamage} урона, доступен только после применения Рашамон");
            Console.WriteLine($"При нажатии на клавишу - {interdimensionalRift}, доступно заклинание Межпространственный разлом, только когда у вас осталось меньше {replenishmentHealth} хп");

            while (magicianShadowHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine("Вы бьете, нажмите на клавишу");
                userInputAttack = Convert.ToInt32(Console.ReadLine());
                
                if (userInputAttack == rashamonSpell)
                {
                    bossHealth -= magicianRashamonSpellDamage;
                    magicianShadowHealth -= bossDamage;
                    isActivHuganzakura = true;
                }
                else if (userInputAttack == huganzakuraSpell && isActivHuganzakura == true)
                {
                    bossHealth -= magicianHuganzakuraSpellDamage;
                    magicianShadowHealth -= bossDamage;
                }
                else if (userInputAttack == interdimensionalRift && magicianShadowHealth < replenishmentHealth)
                {
                    magicianShadowHealth += magicianInterdimensionalRift;
                    Console.WriteLine($"Заклинание - Межпространственный разлом активирован, у вас прибавилось {magicianInterdimensionalRift} хп. Сейчас у вас {magicianShadowHealth} хп.");
                }
                else
                {
                    Console.WriteLine($"Вы не можете активировать {huganzakuraSpell}, пока не активировали {rashamonSpell}");
                }
                
                Console.WriteLine($"{magicianShadow} нанес удар боссу - остаток жизни: {bossHealth} хп");
                Console.WriteLine($"{bossDaran} нанес удар {magicianShadow} - остаток жизни: {magicianShadowHealth} хп");
            }

            if (magicianShadowHealth < 0 && bossHealth > magicianShadowHealth)
            {
                Console.WriteLine($"{bossDaran} выиграл. Попробуйте еще раз!");
            }
            else if (bossHealth < 0 && magicianShadowHealth > bossHealth)
            {
                Console.WriteLine($"{magicianShadow} выиграл. {bossDaran} повержен.");
            }
            else if (magicianShadowHealth < 0 && bossHealth < 0)
            {
                Console.WriteLine("Оба проиграли. Попробуйте еще раз!");
            }
        }
    }
}
