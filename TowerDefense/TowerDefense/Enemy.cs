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
        protected double defaultSpeed; //movement speed (default)
        protected double speed; //current movement speed (after status effect)
        protected int reward; //money given when killed
        protected List<double> status; //status effect timers

        //for movement calculation
        protected List<Tile> path;
        protected int movingStage; //if enemy position between Tile i and i+1 of path, this should be i

        protected double pos_x;
        protected double pos_y;

        public int Attack { get { return attack; } }
        public int Reward { get { return reward; } }
        public double Pos_x { get { return pos_x; } }
        public double Pos_y { get { return pos_y; } }

        public bool dead() { return (HP <= 0.0); }
        public bool reachedBase(Tile baseTile)
        {
            throw new NotImplementedException();
            return true;
            //TODO
        }

        public void initPosition(Tile startTile)
        {
            throw new NotImplementedException();
            //TODO
        }
        public abstract void move(double delta_t); //calculate movement
        public abstract void statusEffect(double delta_t); //calculate status effects

        public abstract void dealtDamage(double val); //tower deal damage to enemy
        public abstract void dealtStatusEffect(StatusEffect type, double val); //tower deal status effect to enemy
    
        protected void defaultMove(double delta_t)
        {
            throw new NotImplementedException();
            //TODO
        }

        protected void defaultStatusEffect(double delta_t)
        {
            speed = defaultSpeed;

            for(int i=0; i<status.Count; i++)
            {
                if (status[i] > 0.0) status[i] -= delta_t;
            }
            
            if (status[(int)StatusEffect.Frozen] > 0.0)
            {
                speed = 0.5 * defaultSpeed; //values subject to change
            }
            if (status[(int)StatusEffect.Poisoned] > 0.0)
            {
                dealtDamage(10.0 * delta_t); //values subject to change
            }
        }

        protected void defaultDealtDamage(double val)
        {
            HP -= val;
        }

        protected void defaultDealtStatusEffect(StatusEffect type, double val)
        {
            status[(int)type] = val;
        }
    }
}
