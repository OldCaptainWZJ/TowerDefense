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
        private double range;
        public SniperSelect(double range, Tile position)
        {
            this.range = range;
        }
        public override List<Enemy> select(List<Enemy> enemies)
        {
            List<Enemy> selected = new List<Enemy>();
            foreach(var e in enemies)
            {
                if (InRange(e.Pos_x, e.Pos_y, range, position))
                {
                    selected.Add(e);
                    break;
                }
            }
            return selected;
        }

        private bool InRange(double x, double y, double r, Tile pos)
        {
            double cx = x + 0.5 * GridParams.TileSize;
            double cy = y + 0.5 * GridParams.TileSize;
            double tilecx = (((double)pos.x) + 0.5) * GridParams.TileSize;
            double tilecy = (((double)pos.y) + 0.5) * GridParams.TileSize;

            if ((cx - tilecx) * (cx - tilecx) + (cy - tilecy) * (cy - tilecy) <= r * r)
                return true;
            return false;
        }
    } 
}
