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
        public const double TileSize = 50.0; //how many pixels is one tile long
        public const double StartX = 0.0;
        public const double StartY = 0.0; //starting position (top-left) for painting grid
    }
}
