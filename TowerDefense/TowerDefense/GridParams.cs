using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal static class GridParams
    {
        public const int GridSizeX = 16; //how many tiles per row
        public const int GridSizeY = 12; //how many tiles per column
        public const int TileSize = 50; //how many pixels is one tile long
        public const int StartX = 400;
        public const int StartY = 300; //starting position (top-left) for painting grid
    }
}
