using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public class Enemy : Character
    {
        
        private int _minDamage;
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value <= MaxDamage ? value : MaxDamage; }
        }

        public Enemy(int life, int maxLife, int block, int hitChance, int speed, int minDamage, int maxDamage, string description, string name) : base(life, maxLife, block, hitChance, speed, name)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}\n{(Life == MaxLife && Name != "crew mate" ? "It is uninjured." : Life == MaxLife && Name == "crew mate" ? "They are uninjured." : Life >= MaxLife / 2 && Name != "crew mate" ? "It seems to be hurt, but now it's angrier." : Life >= MaxLife / 2 && Name == "crew mate" ? "They seem to be hurt, but now they're angrier." : Life < MaxLife / 2 && Name != "crew mate" ? "It's heavily injured. Now is the time to finish this." : "They are heavily injured. Now's your chance.")}");
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        } 
        
    }
}
