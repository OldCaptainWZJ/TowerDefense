using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    internal abstract partial class Tower
    {
        private Image texture = Resource1.tower;
        public void paint(Graphics g)
        {
            g.DrawImage(texture, this.position.x * GridParams.TileSize, this.position.y * GridParams.TileSize, GridParams.TileSize, GridParams.TileSize);
        }
    }
}
