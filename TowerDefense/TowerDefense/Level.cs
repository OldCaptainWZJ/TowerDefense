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
        public List<Tile> path = new List<Tile>();
        public List<Wave> waves = new List<Wave>();
        public int startMoney = 0;
        public List<int> towerSelection = new List<int>();

        public Level(string levelPath)
        {
            string filePath = Application.StartupPath + "/resource/games_config/" + levelPath;
            loadLevel(filePath);
        }

        public void loadLevel(string filePath)
        {
            FileStream F = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(F);

            string[] strings = reader.ReadLine().Split(' ');
            int nowX = Convert.ToInt32(strings[0]);
            int nowY = Convert.ToInt32(strings[1]);

            path.Add(new Tile(nowX, nowY));
            string str = reader.ReadLine();

            for (int i=0; i<str.Length; i++)
            {
                if (str[i] == 'w') nowY--;
                if (str[i] == 'a') nowX--;
                if (str[i] == 's') nowY++;
                if (str[i] == 'd') nowX++;
                path.Add(new Tile(nowX, nowY));
            }

            int waveCount = Convert.ToInt32(reader.ReadLine());

            while(waveCount > 0)
            {
                Wave wave = new Wave();
                wave.loadWave(reader, path);
                waves.Add(wave);

                waveCount--;
            }

            startMoney = Convert.ToInt32(reader.ReadLine());

            strings = reader.ReadLine().Split(' ');
            for (int i=0; i<strings.Length; i++)
            {
                towerSelection.Add(Convert.ToInt32(strings[i]));
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
        public List<Enemy> enemies = new List<Enemy>(); //list of enemies
        public List<double> produceTime = new List<double>(); //produce time (starting from wave start time)
        public List<bool> produced = new List<bool>(); //true if enemy is already produced in the level

        public void loadWave(StreamReader reader, List<Tile> path)
        {
            int groups = Convert.ToInt32(reader.ReadLine());
            for(int i=0; i<groups; i++)
            {
                string str = reader.ReadLine();
                string[] strings = str.Split(' ');

                double startTime = Convert.ToDouble(strings[0]);
                int enemyType = Convert.ToInt32(strings[1]);
                int numbers = Convert.ToInt32(strings[2]);
                double interval = Convert.ToDouble(strings[3]);

                n += numbers;
                for(int j=0; j<numbers; j++)
                {
                    Enemy enemy = Enemy.produceEnemy(enemyType);
                    enemy.initPath(path);
                    enemy.initPosition(path.First());
                    enemies.Add(enemy);
                    produceTime.Add(startTime + interval * j);
                    produced.Add(false);
                }
            }
        }
    }
}
