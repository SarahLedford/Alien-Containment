using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public class EnemyGenerator
    {
        public static Enemy GetEnemy()
        {
            Enemy android = new Enemy(75, 75, 15, 10, 10, 10, 20, "Its mechanical eyes stare straight through you, a faint glow behind them. It stands tall and sure.", "android");
            Enemy crewMember = new Enemy(50, 50, 10, 5, 5, 5, 10, "One of your crewmembers is standing in front of you, staring off into the distance. You say something, but it's as if they don't even hear you. Suddenly, their eyes snap up and lock with yours. There's no recognition, no familiarity. You know they aren't going to go down without a fight.", "crew mate");
            Enemy xenomorph = new Enemy(110, 110, 30, 30, 20, 15, 25, "It towers over you as you fight the urge to scream. It's smooth black body slithers and twitches.\nHere it comes.", "xenomorph");

            Enemy[] enemies =
            {
            crewMember, crewMember, android, android, android, xenomorph
            };
            bool isAnEnemy = new Random().Next(1, 11) <= 5 ? true : false;
            if (isAnEnemy == true)
            {
                Random rand = new Random();
                int index = rand.Next(enemies.Length);
                Enemy enemy = enemies[index];
                return enemy;
            }
            else
            {
                return null;
            }








        }
    }
}
