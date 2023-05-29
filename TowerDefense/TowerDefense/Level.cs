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
        public Level(string levelPath)
        {
            string filePath = Application.StartupPath + levelPath;
            loadLevel(filePath);
        }

        public void loadLevel(string filePath)
        {

        }
    }

    internal class Tile
    {
        public int x;
        public int y;
    }

    internal class Wave
    {
        public int n; //number of enemies
        public List<Enemy> enemies; //order of enemies
        public List<int> intervals; //time interval between enemy appearance
    }
}
