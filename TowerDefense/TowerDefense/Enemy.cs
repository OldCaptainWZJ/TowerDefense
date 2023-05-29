using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    enum StatusEffect
    {
        Frozen = 0,
        Poisoned = 1
    }
    internal abstract class Enemy
    {
        private int maxHP;
        private int HP;
        private int attack; //attack power
        private double speed; //movement speed
        private List<int> status; //status effects counters

        public bool dead() { return (HP <= 0); }

        public abstract void move(); //calculate movement
        public abstract void statusEffect(); //calculate status effects

        public abstract void dealtDamage(int val); //tower deal damage to enemy
        public abstract void dealtStatusEffect(StatusEffect type, int val); //tower deal status effect to enemy
    }
}
