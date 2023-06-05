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
            g.DrawImage(texture, (float)pos_x, (float)pos_y, GridParams.TileSize, GridParams.TileSize);

            Pen hpPen = new Pen(Color.Red, 2);
            Brush hpBrush = new SolidBrush(Color.Red);

            float hpWidth = (float)HP * GridParams.TileSize / (float)maxHP;
            g.DrawRectangle(hpPen, (float)pos_x, (float)pos_y - GridParams.HPBarDist2Enemy - GridParams.HPBarHeight, GridParams.TileSize, GridParams.HPBarHeight);
            g.FillRectangle(hpBrush, (float)pos_x, (float)pos_y - GridParams.HPBarDist2Enemy - GridParams.HPBarHeight, hpWidth, GridParams.HPBarHeight);
        }
    }
}
