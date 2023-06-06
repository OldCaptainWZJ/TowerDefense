using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TowerDefense
{
    internal abstract partial class Enemy
    {
        protected Image texture = Resource1.enemy;
        protected const int HPBarHeight = 5;
        protected const int HPBarDist2Enemy = 1;

        protected System.Timers.Timer hurtTimer = new System.Timers.Timer(300);
        protected bool hurt; //if display hurt animation
        
        public void initHurtTimer()
        {
            hurtTimer.Elapsed += stopDisplayHurt;
        }

        public void displayHurt()
        {
            hurt = true;
            hurtTimer.Start();
        }

        public void stopDisplayHurt(Object sender, ElapsedEventArgs e)
        {
            hurt = false;
            if (!hurt) hurtTimer.Stop();
        }

        public void paint(Graphics g)
        {
            g.DrawImage(texture, (float)pos_x, (float)pos_y, GridParams.TileSize, GridParams.TileSize);

            if (hurt) //draw hurt effect
            {
                float x = (float)(pos_x + 0.25 * GridParams.TileSize);
                float y = (float)(pos_y + 0.25 * GridParams.TileSize);
                float r = (float)(0.5) * GridParams.TileSize;
                g.DrawEllipse(new Pen(Color.Red, 2), x, y, r, r);
            }

            if (status[(int)StatusEffect.Frozen] > 0.0) //draw frozen effect
            {
                float x = (float)(pos_x + 0.15 * GridParams.TileSize);
                float y = (float)(pos_y + 0.15 * GridParams.TileSize);
                float r = (float)(0.7) * GridParams.TileSize;
                g.DrawEllipse(new Pen(Color.LightBlue, 2), x, y, r, r);
            }

            Pen hpPen = new Pen(Color.Red, 2);
            Brush hpBrush = new SolidBrush(Color.Red);

            float hpWidth = (float)HP * GridParams.TileSize / (float)maxHP;
            g.DrawRectangle(hpPen, (float)pos_x, (float)pos_y - HPBarDist2Enemy - HPBarHeight, GridParams.TileSize, HPBarHeight);
            g.FillRectangle(hpBrush, (float)pos_x, (float)pos_y - HPBarDist2Enemy - HPBarHeight, hpWidth, HPBarHeight);
        }
    }
}
