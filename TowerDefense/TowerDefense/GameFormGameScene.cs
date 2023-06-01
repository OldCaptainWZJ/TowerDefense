using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public partial class GameForm
    {
        private Image gameSceneImage;

        private Image tileImage;
        private Image roadImage;
        private Image entranceImage;
        private Image exitImage;

        private Image[] towerImages;
        private Image[] enemyImages;

        private void gameScenePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            gameSceneBackgroundLoad(sender, e);
            gameSceneTowerPaint(sender, e);
            gameSceneEnemyPaint(sender, e);

            g.DrawImage(gameSceneImage, GridParams.StartX, GridParams.StartY);
        }

        private void gameSceneBackgroundPaint(object sender, PaintEventArgs e)
        {
            Graphics sceneG = Graphics.FromImage(gameSceneImage);

            bool[,] roadMark = new bool[GridParams.GridSizeX, GridParams.GridSizeY];

            roadMark[level.path.First().x, level.path.First().y] = true;
            sceneG.DrawImage(entranceImage, GridParams.TileSize * level.path.First().x, GridParams.TileSize * level.path.First().y);

            roadMark[level.path.Last().x, level.path.Last().y] = true;
            sceneG.DrawImage(exitImage, GridParams.TileSize * level.path.Last().x, GridParams.TileSize * level.path.Last().y);

            for (int i= 1;i < level.path.Count() - 1;++i)
            {
                var tile = level.path[i];
                roadMark[tile.x, tile.y] = true;
                sceneG.DrawImage(roadImage, GridParams.TileSize * tile.x, GridParams.TileSize * tile.y);
            }

            for (int i = 0; i < GridParams.GridSizeX; ++i)
            {
                for (int j = 0; j < GridParams.GridSizeY; ++j)
                {
                    if (!roadMark[i, j])
                    {
                        sceneG.DrawImage(tileImage, GridParams.GridSizeX * i, GridParams.GridSizeY * j);
                    }
                }
            }

        }

        private void gameSceneTowerPaint(object sender, PaintEventArgs e)
        {

        }

        private void gameSceneEnemyPaint(object sender, PaintEventArgs e)
        {

        }

        private void gameSceneLoad(object sender, EventArgs e)
        {
            gameSceneImage = new Bitmap(GridParams.GridSizeX * GridParams.TileSize, GridParams.GridSizeY * GridParams.TileSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            gameSceneBackgroundLoad(sender, e);
        }

        private void gameSceneBackgroundLoad(object sender, EventArgs e)
        {
            tileImage = Resource1.tile;
            roadImage = Resource1.road;
            entranceImage = Resource1.entrance;
            exitImage = Resource1.exit;
        }

        private void gameSceneTowerLoad(object sender, EventArgs e)
        {

        }

        private void gameSceneEnemyLoad(object sender, EventArgs e)
        {

        }
    }
}
