using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class SelectMethod
    {
        public abstract List<Enemy> select(List<Enemy> enemies);
        //select enemies in a certain way and return the selected enemies
    }

    internal class SniperSelect : SelectMethod
    {
        private Tile position;
        private double range; //unit: tiles
        public SniperSelect(double range, Tile position)
        {
            this.position = position;
            this.range = range;
        }
        public override List<Enemy> select(List<Enemy> enemies)
        {
            List<Enemy> selectedList = new List<Enemy>();

            Enemy selected = null;
            double nowDistance = -1.0;

            //locate the enemy that's furthest away from the start and within attack range
            foreach(var e in enemies)
            {
                if (InRange(e.Pos_x, e.Pos_y, range, position) && e.Distance > nowDistance)
                {
                    selected = e;
                    nowDistance = e.Distance;
                }
            }

            if (selected != null) selectedList.Add(selected);

            return selectedList;
        }

        private bool InRange(double x, double y, double r, Tile pos)
        {
            double cx = x;
            double cy = y;
            double tilecx = (double)pos.x * GridParams.TileSize;
            double tilecy = (double)pos.y * GridParams.TileSize;
            double R = r * GridParams.TileSize;

            if ((cx - tilecx) * (cx - tilecx) + (cy - tilecy) * (cy - tilecy) <= R * R)
                return true;
            return false;
        }
    } 
}
