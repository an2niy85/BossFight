using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameProcess = true;
            bool isRashamonEffect = false;
            bool isInterdimensionalRift = false;
            int playerHP = 500;
            int bossHP = 1000;

            int damageFromEnemy = 0;
            int dividerDamageEnemy = 2;
            int rashamon = 100;
            int huganzakura = 200;
            int interdimensionalRift = 250;
            int fireBalls = 65;

            string spellNumber;
            var random = new Random();
            int bossMagicDamage;
            int maxBossMagicDamage = 100;
            int minBossMagicDamage = 50;

            while (isGameProcess)
            {
                Console.WriteLine("Ваш HP: " + playerHP);
                Console.WriteLine("HP босса: " + bossHP);
                Console.WriteLine("\n Ты можешь выбрать из 4 заклинаний:");
                Console.WriteLine($"[1] Рашамон - призывает духа тени для начала атаки (стоимость {rashamon} HP)");
                Console.WriteLine($"[2] Хуганзакура - удар алмазными шипами (урон {huganzakura}, можно использовать только после Рашамона).");
                Console.WriteLine($"[3] Межпространственный разлом - скрывает вас и восстанавливает {interdimensionalRift} HP.");
                Console.WriteLine($"[4] Огненный шар - наносит Боссу урон {fireBalls} и восстанавливает 50% урона от врага. \n");
                Console.WriteLine("Введите номер заклинания: ");

                spellNumber = Console.ReadLine();

                switch (spellNumber)
                {
                    case "1":
                        playerHP -= rashamon;
                        isRashamonEffect = true;
                        Console.WriteLine($"Вы использовали заклинание Рашамон и потратили {rashamon} HP");
                        break;
                    case "2":
                        if (isRashamonEffect == true)
                        {
                            bossHP -= huganzakura;
                            isRashamonEffect = false;
                            Console.WriteLine("Ты использовал ранее заклинание Рашамон и смог произвести атаку Алмазными шипами.");
                        }
                        else
                        {
                            Console.WriteLine("Ты не использовал ранее заклинание Рашамон и не смог произвести атаку Алмазными шипами.");
                        }
                        break;
                    case "3":
                        isInterdimensionalRift = true;
                        playerHP += interdimensionalRift;
                        Console.WriteLine($"Вы использовали Межпространственный разлом. Вы скрылись от босса и восстановили {interdimensionalRift} HP.");
                        break;
                    case "4":
                        bossHP -= fireBalls;
                        damageFromEnemy /= dividerDamageEnemy;
                        playerHP += damageFromEnemy;
                        Console.WriteLine($"Вы нанесли урон Боссу {fireBalls} и восстановили {damageFromEnemy } HP.");
                        break;
                    default:
                        break;
                }

                bossMagicDamage = random.Next(minBossMagicDamage, maxBossMagicDamage);
                if (isInterdimensionalRift == true)
                {
                    isInterdimensionalRift = false;
                    Console.WriteLine("Ты скрылся от Босса и он не причинил тебе вреда.");
                }
                else
                {
                    playerHP -= bossMagicDamage;
                    damageFromEnemy += bossMagicDamage;
                    Console.WriteLine($"Босс атакует и наносит урон {bossMagicDamage}.");
                }

                if (playerHP <= 0)
                {
                    Console.WriteLine("Вы умерли!");
                    isGameProcess = false;
                }
                if (bossHP <= 0)
                {
                    Console.WriteLine("Победа! Вы выиграли!");
                    isGameProcess = false;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
