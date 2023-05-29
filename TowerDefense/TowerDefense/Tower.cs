using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class Tower
    {
        private SelectMethod selectMethod;
        private DamageMethod damageMethod;
        private List<Enemy> selectedEnemies;
        private int cost;
        private Tile position;
        private double maxCooldown;
        private double cooldown;

        public void select(List<Enemy> enemies, double delta_t)
        {
            cooldown -= delta_t;
            if (cooldown <= 0.0)
            {
                cooldown += maxCooldown;
                selectedEnemies = selectMethod.select(enemies);
            }
            else selectedEnemies.Clear();
        }
        //select enemies within range of attack
        public void deal()
        {
            damageMethod.deal(selectedEnemies);
        }
        //deal damage and status effects to selected enemies
    }
}
