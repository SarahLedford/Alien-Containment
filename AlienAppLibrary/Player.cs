using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public class Player : Character
    {
        public Weapon EquippedWeapon { get; set; }

        public Player(int life, int maxLife, int block, int hitChance, int speed, Weapon equippedWeapon, string name) : base(life, maxLife, block, hitChance, speed, name)
        {
            EquippedWeapon = equippedWeapon;
        }

        public override string ToString()
        {
            return string.Format($"Stats:\nLife: {Life}/{MaxLife}\n" +
                $"Weapon: {EquippedWeapon}");
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }
    }
}
