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
        protected double maxHP;
        protected double HP;
        protected int attack; //attack power (HP lost if reached base)
        protected double speed; //movement speed
        protected int reward; //money given when killed
        protected List<double> status; //status effect timers

        protected double pos_x;
        protected double pos_y;

        public int Attack { get { return attack; } }
        public int Reward { get { return reward; } }
        public double Pos_x { get { return pos_x; } }
        public double Pos_y { get { return pos_y; } }

        public bool dead() { return (HP <= 0.0); }
        public bool reachedBase(Tile baseTile)
        {
            return true;
            //TODO
        }

        public void initPosition(Tile startTile)
        {
            //TODO
        }
        public abstract void move(double delta_t); //calculate movement
        public abstract void statusEffect(double delta_t); //calculate status effects

        public abstract void dealtDamage(double val); //tower deal damage to enemy
        public abstract void dealtStatusEffect(StatusEffect type, double val); //tower deal status effect to enemy
    }
}
