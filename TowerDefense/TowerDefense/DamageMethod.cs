using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class DamageMethod
    {
        public abstract void deal(List<Enemy> enemies);
        //deal damage and/or status effects to enemies
    }
}
