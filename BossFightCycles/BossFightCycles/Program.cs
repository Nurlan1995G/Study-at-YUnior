using Microsoft.VisualBasic;
using System;

namespace BossFight
{
    class Boss   //Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний, которые
                 //вы можете использовать против Босса. Вы должны уничтожить босса и только после этого будет вам покой.
                 //Формально: перед вами босс, у которого есть определенное кол-во жизней и определенный ответный урон.У вас есть 4 заклинания для нанесения урона боссу.Программа завершается только после смерти босса или смерти пользователя.
                 //Пример заклинаний ::      Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)
                 //Хуганзакура(Может быть выполнен только после призыва теневого духа), наносит 100 ед.урона
                 //Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп.Урон босса по вам не проходит
                 //Заклинания должны иметь схожий характер и быть достаточно сложными, они должны иметь какие-то условия выполнения(пример - Хуганзакура). Босс должен иметь возможность убить пользователя.
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string shadowMagician = "Теневой маг";
            string bossDaran = "Босс Даран";
            int healthShadowMagician = random.Next(450, 700);
            int healthBoss = random.Next(1900, 2000);
            int damageShadowMagician;
            int damageBoss = random.Next(120, 140);
            int userInpurAttack;
            int rashamonSpell = 1;
            int huganzakuraSpell = 2;
            int interdimensionalRift = 3;
            int damageRashamonSpellMagician = 100;  // урон заклинания рашамон мага
            int damageHuganzakuraSpellMagician = 150;   //заклинание хуганзакура
            int interdimensionalRiftMagician = 250;  //межпространственный разлом
            bool isActivInterdimensionalRift = false;
            bool isLastBattle = true;

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
                }
                else if (userInpurAttack == huganzakuraSpell)
                {
                    healthBoss -= damageHuganzakuraSpellMagician;
                    healthShadowMagician -= damageBoss;
                }
                else if (userInpurAttack == interdimensionalRift && healthShadowMagician < 100)
                {
                    healthShadowMagician += interdimensionalRiftMagician;
                    Console.WriteLine($"Заклинание - Межпространственный разлом активирован, у вас прибавилось {interdimensionalRiftMagician} хп. Сейчас у вас {healthShadowMagician} хп.");
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
