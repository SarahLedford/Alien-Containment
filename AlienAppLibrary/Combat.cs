using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public class Combat
    {
        public static void Attack(Character attacker, Character defender)
        {
            Random random = new Random();
            int result = random.Next(1, 101);
            System.Threading.Thread.Sleep(35);
            if (result <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();
                defender.Life -= damageDealt;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ForegroundColor = ConsoleColor.Green;
            }//end if
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else
        }//end Attack()

        public static void Battle(Player player, Enemy enemy)
        {
            Random random = new Random();
            int playerSpeed = random.Next(1, 11) + player.Speed;
            System.Threading.Thread.Sleep(25);
            int monsterSpeed = random.Next(1, 11) + enemy.Speed;
            Console.WriteLine($"{(playerSpeed >= monsterSpeed ? $"{player.Name} attack first!" : $"The { enemy.Name} attacks first!")}");
            if (playerSpeed >= monsterSpeed)
            {
                Attack(player, enemy);
                if (enemy.Life > 0)
                {
                    Attack(enemy, player);
                }//end 
            }//end if player attacks first
            else
            {
                Attack(enemy, player);
                if (player.Life > 0)
                {
                    Attack(player, enemy);
                }
            }//end else enemy attacks first

        }
    }
}
