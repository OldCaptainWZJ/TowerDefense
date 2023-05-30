using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        protected double defaultSpeed; //movement speed (default, tile)
        protected double speed; //current movement speed (after status effect, tile)
        protected int reward; //money given when killed
        protected List<double> status; //status effect timers

        //for movement calculation
        protected List<Tile> path;
        protected int movingStage; //if enemy position between Tile i and i+1 of path, this should be i

        protected double pos_x;
        protected double pos_y; //position (pixel, top-left)

        public int Attack { get { return attack; } }
        public int Reward { get { return reward; } }
        public double Pos_x { get { return pos_x; } }
        public double Pos_y { get { return pos_y; } }

        public bool dead()
        {
            if (HP <= 0.0) return true;
            return false;
        }
        public bool reachedBase()
        {
            if (movingStage == path.Count-1) return true;
            return false;
        }

        public void initPath(List<Tile> path)
        {
            this.path = path;
        }
        public void initPosition(Tile startTile)
        {
            pos_x = GridParams.StartX + ((double)startTile.x) * GridParams.TileSize;
            pos_y = GridParams.StartY + ((double)startTile.y) * GridParams.TileSize;
        }
        public abstract void move(double delta_t); //calculate movement
        public abstract void statusEffect(double delta_t); //calculate status effects

        public abstract void dealtDamage(double val); //tower deal damage to enemy
        public abstract void dealtStatusEffect(StatusEffect type, double val); //tower deal status effect to enemy
    
        protected void defaultMove(double delta_t)
        {
            if (movingStage == path.Count - 1) return;

            double dirX = ((double)(path[movingStage + 1].x - path[movingStage].x)) * GridParams.TileSize;
            double dirY = ((double)(path[movingStage + 1].y - path[movingStage].y)) * GridParams.TileSize;

            pos_x += speed * dirX;
            pos_y += speed * dirY;

            if (!InSegment(pos_x, pos_y, path[movingStage], path[movingStage + 1]))
            {
                movingStage++;
                
                if (movingStage == path.Count - 1) return;

                double exceededX = Math.Abs(pos_x - ((double)path[movingStage].x) * GridParams.TileSize);
                double exceededY = Math.Abs(pos_y - ((double)path[movingStage].y) * GridParams.TileSize);
                dirX = (double)(path[movingStage + 1].x - path[movingStage].x);
                dirY = (double)(path[movingStage + 1].y - path[movingStage].y);
                initPosition(path[movingStage]);
                pos_x += dirX * exceededX;
                pos_y += dirY * exceededY;
            }
        }

        private bool InSegment(double x, double y, Tile a, Tile b)
        {
            double ax = ((double)a.x) * GridParams.TileSize;
            double ay = ((double)a.y) * GridParams.TileSize;
            double bx = ((double)b.x) * GridParams.TileSize;
            double by = ((double)b.y) * GridParams.TileSize;
            double eps = 1e-5;
            if (ax - bx > eps)
            {
                if (x < Math.Min(ax, bx)) return false;
                if (x > Math.Max(ax, bx)) return false;
                return true;
            }
            else
            {
                if (y < Math.Min(ay, by)) return false;
                if (y > Math.Max(ay, by)) return false;
                return true;
            }
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
