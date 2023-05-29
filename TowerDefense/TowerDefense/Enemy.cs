using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private double maxHP;
        private double HP;
        private int attack; //attack power (HP lost if reached base)
        private double speed; //movement speed
        private int reward; //money given when killed
        private List<double> status; //status effects timers

        private double pos_x;
        private double pos_y;

        public int Attack
        { 
            get { return attack; } 
        }

        public bool dead() { return (HP <= 0); }
        public bool reachedBase(Tile baseTile)
        {
            return true;
            //TODO
        }

        public abstract void move(); //calculate movement
        public abstract void statusEffect(); //calculate status effects

        public abstract void dealtDamage(double val); //tower deal damage to enemy
        public abstract void dealtStatusEffect(StatusEffect type, double val); //tower deal status effect to enemy
    }
}
