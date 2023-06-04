using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    internal abstract partial class Enemy
    {
        private Image texture = Resource1.enemy;
        public void paint(Graphics g)
        {
            g.DrawImage(texture, (float)this.pos_x, (float)this.pos_y, GridParams.TileSize, GridParams.TileSize);
        }
    }
}
