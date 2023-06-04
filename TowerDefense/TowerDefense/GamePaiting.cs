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
            foreach (var t in towers)
            {
                t.paint(g);
            }

            foreach (var e in enemies)
            {
                e.paint(g);
            }
        }
    }
}
