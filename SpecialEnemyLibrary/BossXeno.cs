using AlienAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialEnemyLibrary
{
    public class BossXeno : Enemy
    {
        public bool IsQueen { get; set; }

        public BossXeno(int life, int maxLife, int block, int hitChance, int speed, int minDamage, int maxDamage, string description, string name, bool isQueen) : base(life, maxLife, block, hitChance, speed, minDamage,maxDamage,description,name)
        {
            IsQueen = isQueen;
            if (IsQueen)
            {
                MaxDamage += 3;
                MinDamage += 3;
                Block += 10;
            }
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}{(IsQueen ? "\nThis is a queen. Proceed with extra caution!" : "")}");
        }
    }
}
