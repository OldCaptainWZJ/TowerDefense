using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
            //TODO
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
        public List<Enemy> enemies; //order of enemies
        public List<double> intervals; //time interval between enemy appearance
    }
}
