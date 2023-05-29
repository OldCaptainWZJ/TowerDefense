using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class Game
    {
        private List<Tower> towers = new List<Tower>();
        private List<Enemy> enemies = new List<Enemy>();
        private List<Enemy> deleteList = new List<Enemy>();

        private Level level;
        private int baseHP = 100;
        private int money;
        private bool[][] occupied;
        private double last_t; //last recorded time (s)

        private System.DateTime currentTime = new System.DateTime();

        Game(string levelPath)
        {
            level = new Level(levelPath);
        }

        public bool defenseStage()
        {
            double now_t = ((double)currentTime.Millisecond) / 1000.0;
            double delta_t = now_t - last_t;
            last_t = now_t;

            //tower attack
            foreach(var t in towers)
            {
                t.select(enemies, delta_t);
                t.deal();
            }

            deleteList.Clear();

            //change enemy status
            foreach (var e in enemies)
            {
                e.move(delta_t);
                e.statusEffect(delta_t);
                
                if (e.dead()) deleteList.Add(e); //enemy is dead
                if (!e.dead() && e.reachedBase(level.path[level.path.Count-1]))
                {
                    baseHP -= e.Attack;
                    deleteList.Add(e);
                }
                //enemy reached base, base take damage
            }

            //fail
            if (baseHP <= 0) return false;

            //remove dead enemies
            foreach(var e in deleteList)
            {
                enemies.Remove(e);
            }

            return true;
        }
    }
}
