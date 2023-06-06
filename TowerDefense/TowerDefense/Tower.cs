using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    enum TowerType
    {
        Default = 0,
        Pig = 1,
        Snowball = 2,
        Napoleon = 3,
        Boxer = 4,
        Hedgehog = 5
    }
    internal abstract partial class Tower
    {
        protected SelectMethod selectMethod;
        protected DamageMethod damageMethod;
        protected List<Enemy> selectedEnemies = new List<Enemy>();
        public int cost;
        protected Tile position;
        protected double maxCooldown;
        protected double cooldown;

        protected double range;

        public int Cost { get { return cost; } }

        public void initCooldown()
        {
            cooldown = 0.0;
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
            if (cooldown <= 0.0)
            {
                selectedEnemies = selectMethod.select(enemies);
                if (selectedEnemies.Count != 0) cooldown += maxCooldown;
            }
            else
            {
                selectedEnemies.Clear();
                cooldown -= delta_t;
            }
        }

        protected void continuousSelect(List<Enemy> enemies)
        {
            selectedEnemies = selectMethod.select(enemies);
        }

        public static Tower produceTower(int type, Tile tile)
        {
            if (type == (int)TowerType.Default) return new DefaultTower(tile);
            if (type == (int)TowerType.Pig) return new Pig(tile);
            if (type == (int)TowerType.Snowball) return new Snowball(tile);
            if (type == (int)TowerType.Napoleon) return new Napoleon(tile);
            if (type == (int)TowerType.Boxer) return new Boxer(tile);
            if (type == (int)TowerType.Hedgehog) return new Hedgehog(tile);
            return new DefaultTower(tile); // should not reach this line
        }
    }

    internal class DefaultTower : Tower
    {
        public DefaultTower(Tile position)
        {
            this.position = position;
            cost = 100;
            maxCooldown = 1.0;

            range = 2.0;
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
