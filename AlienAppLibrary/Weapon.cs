using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public class Weapon
    {
        private int _minDamage;
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int BonusHitChance { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value <= MaxDamage ? value : MaxDamage; }
        }

        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance)
        {
            MaxDamage = maxDamage;
            Name = name;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
        }

        public override string ToString()
        {
            return string.Format(Name);
        }
    }
}
