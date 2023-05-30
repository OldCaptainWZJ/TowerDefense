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
        private int currentWave = 0;
        private int currentEnemy = 0;
        private double last_t; //last recorded time (s)

        public int BaseHP { get { return baseHP; } }
        public int Money { get { return money; } }
        public int CurrentWave { get { return currentWave; } }

        private System.DateTime currentTime = new System.DateTime();

        Game(string levelPath)
        {
            level = new Level(levelPath);
        }

        public int waveRun() //return 0:failed, 1:wave success, 2:level complete
        {
            bool flag = true;

            foreach(var t in towers)
            {
                t.initCooldown();
            }

            currentEnemy = 0;

            enemies.Add(level.waves[currentWave].enemies[0]);
            enemies[0].initPosition(level.path[0]);

            last_t = ((double)currentTime.Millisecond) / 1000.0;

            while (flag)
            {
                double now_t = ((double)currentTime.Millisecond) / 1000.0;
                double delta_t = now_t - last_t;
                last_t = now_t;

                flag = waveProcess(delta_t);

                level.waves[currentWave].intervals[currentEnemy] -= delta_t;
                if (level.waves[currentWave].intervals[currentEnemy] <= 0.0)
                {
                    //generate enemy
                    currentEnemy++;
                    if (currentEnemy != level.waves[currentWave].enemies.Count)
                    {
                        enemies.Add(level.waves[currentWave].enemies[++currentEnemy]);
                        enemies[enemies.Count - 1].initPosition(level.path[0]);
                    }
                }

                if (currentEnemy == level.waves[currentWave].enemies.Count && enemies.Count == 0)
                    break; //wave complete
            }

            currentWave++;

            if (!flag) return 0;
            if (currentWave == level.waves.Count) return 2;
            return 1;
        }

        public bool waveProcess(double delta_t) //return false if failed level
        {
            //tower attack
            foreach(var t in towers)
            {
                t.select(enemies, delta_t);
                t.deal(delta_t);
            }

            deleteList.Clear();

            //change enemy status
            foreach (var e in enemies)
            {
                e.move(delta_t);
                e.statusEffect(delta_t);

                if (e.dead())
                {
                    //enemy is dead
                    deleteList.Add(e);
                    money += e.Reward;
                }
                if (!e.dead() && e.reachedBase())
                {
                    //enemy reached base, base take damage
                    baseHP -= e.Attack;
                    deleteList.Add(e);
                }
                
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
