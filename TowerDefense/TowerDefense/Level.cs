using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    internal class Level
    {
        public List<Tile> path;
        public List<Wave> waves;
        public int startMoney;

        public Level(string levelPath)
        {
            string filePath = Application.StartupPath + levelPath;
            loadLevel(filePath);
        }

        public void loadLevel(string filePath)
        {
            FileStream F = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(F);

            int waveCount = Convert.ToInt32(reader.ReadLine());

            while(waveCount > 0)
            {
                Wave wave = new Wave();
                wave.loadWave(reader);
                waves.Add(wave);

                waveCount--;
            }

            F.Close();
        }
    }

    internal class Tile
    {
        public int x;
        public int y;

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Wave
    {
        public int n; //number of enemies
        public List<Enemy> enemies = new List<Enemy>(); //order of enemies
        public List<double> produceTime = new List<double>(); //time interval between enemy appearance
        public bool[] produced; //true if enemy is already produced in the level

        public void loadWave(StreamReader reader)
        {
            int groups = Convert.ToInt32(reader.ReadLine());
            for(int i=0; i<groups; i++)
            {
                string str = reader.ReadLine();
                string[] strings = str.Split(' ');

                double startTime = Convert.ToDouble(strings[0]);
                int enemyType = Convert.ToInt32(strings[1]);
                int numbers = Convert.ToInt32(strings[2]);
                double interval = Convert.ToInt32(strings[3]);

                n += numbers;
                for(int j=0; j<numbers; j++)
                {
                    Enemy enemy = produceEnemy(enemyType);
                    enemies.Add(enemy);
                    produceTime.Add(startTime + interval * j);
                }
            }
        }

        private Enemy produceEnemy(int enemyType)
        {
            if (enemyType == (int)EnemyType.Basic) return new BasicEnemy();
            return new BasicEnemy(); //enemyType wrong
        }
    }
}
