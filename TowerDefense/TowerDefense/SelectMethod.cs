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
}
