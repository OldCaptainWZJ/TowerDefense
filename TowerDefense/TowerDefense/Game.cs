using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal partial class Game
    {
        private List<Tower> towers = new List<Tower>();
        private List<Enemy> enemies = new List<Enemy>();
        private List<Enemy> deleteList = new List<Enemy>();

        private Level level;
        private int baseHP = 100;
        private int money;
        private bool[,] occupied;
        private int currentWaveIndex = 0;
        private Wave currentWave;

        public Level Level { get { return level; } }
        public int BaseHP { get { return baseHP; } }
        public int Money { get { return money; } }
        public int CurrentWave { get { return currentWaveIndex; } }

        private DateTime now_t;
        private DateTime last_t;

        public Game(string levelPath)
        {
            level = new Level(levelPath);
        }

        public void waveRun(GameForm form)
        {
            bool flag = true;

            foreach(var t in towers)
            {
                t.initCooldown();
            }

            currentWave = level.waves[currentWaveIndex];
            enemies.Add(currentWave.enemies[0]);
            enemies[0].initPosition(level.path[0]);

            now_t = DateTime.Now;
            DateTime start_t = now_t;
            last_t = start_t;

            while (flag)
            {
                now_t = System.DateTime.Now;
                double delta_t = (now_t - last_t).TotalSeconds;
                last_t = now_t;

                flag = waveProcess(delta_t);
                if (!flag) break;

                int producedCount = 0;
                for(int i=0; i < currentWave.enemies.Count; i++)
                {
                    if (currentWave.produced[i])
                    {
                        producedCount++;
                        continue;
                    }
                    if (currentWave.produceTime[i] <= (now_t - start_t).TotalSeconds)
                    {
                        enemies.Add(currentWave.enemies[i]);
                        currentWave.produced[i] = true;
                        producedCount++;
                    }
                }

                if (producedCount == currentWave.enemies.Count && enemies.Count == 0)
                    break; //wave complete
            }

            currentWaveIndex++;

            //callback: 0:failed, 1:wave success, 2:level complete
            if (!flag) form.waveCallback(0);
            if (currentWaveIndex == level.waves.Count) form.waveCallback(2);
            form.waveCallback(1);
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
