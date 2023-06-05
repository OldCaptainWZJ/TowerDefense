using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    enum TowerType
    {
        Default = 0
    }
    internal abstract partial class Tower
    {
        protected SelectMethod selectMethod;
        protected DamageMethod damageMethod;
        protected List<Enemy> selectedEnemies;
        protected int cost;
        protected Tile position;
        protected double maxCooldown;
        protected double cooldown;

        public int Cost { get { return cost; } }

        public void initCooldown()
        {
            cooldown = maxCooldown;
        }

        public abstract void select(List<Enemy> enemies, double delta_t);
        //select enemies within range of attack
        public void deal(double delta_t)
        {
            damageMethod.deal(selectedEnemies, delta_t);
        }
        //deal damage and status effects to selected enemies
        
        protected void cooldownSelect(List<Enemy> enemies, double delta_t)
        {
            cooldown -= delta_t;
            if (cooldown <= 0.0)
            {
                cooldown += maxCooldown;
                selectedEnemies = selectMethod.select(enemies);
            }
            else selectedEnemies.Clear();
        }

        protected void continuousSelect(List<Enemy> enemies)
        {
            selectedEnemies = selectMethod.select(enemies);
        }
    }

    internal class DefaultTower : Tower
    {
        public DefaultTower(Tile position)
        {
            this.position = position;
            cost = 100;
            maxCooldown = 1.0;

            selectMethod = new SniperSelect(2.0, position);
            damageMethod = new NormalDamage(5.0);

            //values subject to change
        }

        public override void select(List<Enemy> enemies, double delta_t)
        {
            cooldownSelect(enemies, delta_t);
        }
    }
}
