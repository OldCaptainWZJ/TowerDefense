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

        public void select(List<Enemy> enemies)
        {
            selectedEnemies = selectMethod.select(enemies);
        }
        //select enemies within range of attack
        public void deal()
        {
            damageMethod.deal(selectedEnemies);
        }
        //deal damage and status effects to selected enemies
    }
}
