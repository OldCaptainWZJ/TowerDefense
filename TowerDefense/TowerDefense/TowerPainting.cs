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
        protected String name = "1";
        protected Image texture = Resource1.tower;

        public void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void setTexture(Image texture)
        {
            this.texture = texture;
        }

        public Image getTexture()
        {
            return texture;
        }
        public void paint(Graphics g)
        {
            g.DrawImage(texture, this.position.x * GridParams.TileSize, this.position.y * GridParams.TileSize, GridParams.TileSize, GridParams.TileSize);

            float x = (float)(this.position.x - this.range + 0.5) * GridParams.TileSize;
            float y = (float)(this.position.y - this.range + 0.5) * GridParams.TileSize;
            Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, x, y, (float)this.range * 2 * GridParams.TileSize, (float)this.range * 2 * GridParams.TileSize);
        }
    }
}
