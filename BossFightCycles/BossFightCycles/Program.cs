using Microsoft.VisualBasic;
using System;

namespace BossFight
{
    class Boss   
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string shadowMagician = "Теневой маг";
            string bossDaran = "Босс Даран";
            int healthShadowMagician = random.Next(450, 700);
            int healthBoss = random.Next(1500, 2000);
            int damageShadowMagician;
            int damageBoss = random.Next(90, 140);
            int userInpurAttack;
            int rashamonSpell = 1;
            int huganzakuraSpell = 2;
            int interdimensionalRift = 3;
            int damageRashamonSpellMagician = 100;  
            int damageHuganzakuraSpellMagician = 150;   
            int interdimensionalRiftMagician = 250;  
            bool isLastBattle = true;
            bool isActivHuganzakura = false;

            Console.WriteLine($"Добро пожаловать на последнию локацию {shadowMagician}, тут вы сразитесь со своим последним противником и после отправитесь на покой. И ваш последний противник - {bossDaran}");
            Console.WriteLine("Характеристики перед боем.");
            Console.WriteLine($"Теневой маг - {healthShadowMagician} хп");
            Console.WriteLine($"Босс - {healthBoss} хп, {damageBoss} урона от босса");

            Console.WriteLine($"{shadowMagician} - заклинания: ");
            Console.WriteLine($"При нажатии на клавишу - {rashamonSpell}, доступно заклинание Рашамон (призывает теневого духа для нанесения атаки), наносит {damageRashamonSpellMagician} урона противнику.");
            Console.WriteLine($"При нажатии на клавишу - {huganzakuraSpell}, доступно заклинание Хуганзукура, наносит {damageHuganzakuraSpellMagician} урона, доступен только после применения Рашамон");
            Console.WriteLine($"При нажатии на клавишу - {interdimensionalRift}, доступно заклинание Межпространственный разлом, только когда у вас осталось меньше 100 хп");

            while (isLastBattle)
            {
                Console.WriteLine("Вы бьете, нажмите на клавишу");
                userInpurAttack = Convert.ToInt32(Console.ReadLine());

                if (userInpurAttack == rashamonSpell)
                {
                    healthBoss -= damageRashamonSpellMagician;
                    healthShadowMagician -= damageBoss;
                    isActivHuganzakura = true;
                }
                else if (userInpurAttack == huganzakuraSpell && isActivHuganzakura == true)
                {
                   healthBoss -= damageHuganzakuraSpellMagician;
                   healthShadowMagician -= damageBoss;
                } 
                else if (userInpurAttack == interdimensionalRift && healthShadowMagician < 100)
                {
                    healthShadowMagician += interdimensionalRiftMagician;
                    Console.WriteLine($"Заклинание - Межпространственный разлом активирован, у вас прибавилось {interdimensionalRiftMagician} хп. Сейчас у вас {healthShadowMagician} хп.");
                }
                else
                {
                    Console.WriteLine($"Вы не можете активировать {huganzakuraSpell}, пока не активировали {rashamonSpell}");
                }
                
                if (healthShadowMagician < 0 && healthBoss > healthShadowMagician)
                {
                    Console.WriteLine($"{bossDaran} выиграл. Попробуйте еще раз!");
                    isLastBattle = false;
                }
                else if (healthBoss < 0 && healthShadowMagician > healthBoss)
                {
                    Console.WriteLine($"{shadowMagician} выиграл. {bossDaran} повержен.");
                    isLastBattle = false;
                }
                else if (healthShadowMagician < 0 && healthBoss < 0)
                {
                    Console.WriteLine("Оба проиграли. Попробуйте еще раз!");
                    isLastBattle = false;
                }

                Console.WriteLine($"{shadowMagician} нанес удар боссу - остаток жизни: {healthBoss} хп");
                Console.WriteLine($"{bossDaran} нанес удар {shadowMagician} - остаток жизни: {healthShadowMagician} хп");
            }
        }
    }
}
