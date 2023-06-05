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
        protected Image texture = Resource1.enemy;
        protected const int HPBarHeight = 5;
        protected const int HPBarDist2Enemy = 1;
        public void paint(Graphics g)
        {
            g.DrawImage(texture, (float)pos_x, (float)pos_y, GridParams.TileSize, GridParams.TileSize);

            Pen hpPen = new Pen(Color.Red, 2);
            Brush hpBrush = new SolidBrush(Color.Red);

            float hpWidth = (float)HP * GridParams.TileSize / (float)maxHP;
            g.DrawRectangle(hpPen, (float)pos_x, (float)pos_y - HPBarDist2Enemy - HPBarHeight, GridParams.TileSize, HPBarHeight);
            g.FillRectangle(hpBrush, (float)pos_x, (float)pos_y - HPBarDist2Enemy - HPBarHeight, hpWidth, HPBarHeight);
        }
    }
}
