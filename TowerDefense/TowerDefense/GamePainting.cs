using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal partial class Game
    {
        public void paint(Graphics g)
        {
            for (int i = 0; i < towers.Count; i++)
            {
                Tower t = towers[i];
                t.paint(g);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies[i];
                e.paint(g);
            }
        }
    }
}
