using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public abstract class Character
    {
        private int _life;

        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int HitChance { get; set; }
        public int Speed { get; set; }
        public string Name { get; set; }

        public int Life
        {
            get { return _life; }
            set { _life = value <= MaxLife ? value : MaxLife; }
        }

        public Character(int life, int maxLife, int block, int hitChance, int speed, string name)
        {
            MaxLife = maxLife;
            Life = life;
            HitChance = hitChance;
            Speed = speed;
            Block = block;
            Name = name;
        }

        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public abstract int CalcDamage();
    }
}
