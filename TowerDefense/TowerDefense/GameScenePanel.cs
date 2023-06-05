using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace TowerDefense
{
    internal class GameScenePanel : Panel
    {
        Game game;
        Image gameSceneImage;
        Image gamePropertiesImage;

        int selected;
        int mouseX;
        int mouseY;

        public GameScenePanel()
        {
            BackColor = System.Drawing.Color.IndianRed;
            Location = new System.Drawing.Point(3, 3);
            Name = "game_scene_panel";
            Size = new System.Drawing.Size(1181, 854);
            TabIndex = 6;
            Visible = false;
            Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            DoubleBuffered = true;
            gameSceneImage = new Bitmap(GridParams.GridSizeX * GridParams.TileSize, GridParams.GridSizeY * GridParams.TileSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            gamePropertiesImage = new Bitmap(GridParams.GridSizeX * GridParams.TileSize, GridParams.StartY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            List<GameCharacter> characters = new List<GameCharacter>(); // 获取你的角色列表
            GameCharacter character1 = new GameCharacter();
            GameCharacter character2 = new GameCharacter();
            GameCharacter character3 = new GameCharacter();
            character1.Icon = Resource1.pig;
            character2.Icon = Resource1.road;
            character3.Icon = Resource1.tower;
            character1.Name = "character 1";
            character2.Name = "character 2";
            character3.Name = "character 3";
            characters.Add(character1);
            characters.Add(character2);
            characters.Add(character3);

            int startY = 0;
            int startX = 0;
            int padding = 10; // 间隔大小
            int itemHeight = 50 + 2 * padding; // 图像高度 + 上下间隔
            int itemWidth = 160; // 宽度设定为160像素

            Panel panel = new Panel();
            panel.Size = new Size(itemWidth, this.Height - 120); // 假设你的窗体高度足够大
            panel.Location = new Point(0, 120);
            panel.AutoScroll = true; // 如果内容超出Panel的大小，则自动显示滚动条

            // 遍历每一个角色，创建PictureBox和Label，并将它们添加到窗体中
            foreach (var character in characters)
            {
                // 创建并设置Label
                Label lbl = new Label();
                lbl.Text = character.Name;
                lbl.AutoSize = false; // 不自动调整大小，将其设定为指定宽度
                lbl.Width = itemWidth - 50 - 3 * padding; // 预留出图片和额外的padding的空间
                lbl.Location = new Point(startX + padding, startY + padding + (50 - lbl.Height) / 2); // 使得label和图片在同一行中居中
                lbl.Click += Item_Click; // 添加点击事件处理器

                // 创建并设置PictureBox
                PictureBox pb = new PictureBox();
                pb.Name = character.Name;
                pb.Image = character.Icon;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Height = 50;
                pb.Width = 50;
                pb.Location = new Point(lbl.Width + 2 * padding, startY + padding); // 在label的右边绘制图片
                pb.Click += Item_Click; // 添加点击事件处理器

                // 将PictureBox和Label添加到Panel中
                panel.Controls.Add(lbl);
                panel.Controls.Add(pb);

                // 更新下一个item的开始Y坐标
                startY += itemHeight;
            }

            MouseMove += getMousePosition;
            Click += placeTower; //Add Place Tower Event

            // 将Panel添加到窗体中
            Controls.Add(panel);
        }

        public void SetGame(Game game)
        {
            this.game = game;
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            // 将游戏场景绘制到一张图片上
            Graphics sceneG = Graphics.FromImage(gameSceneImage);
            Graphics propertiesG = Graphics.FromImage(gamePropertiesImage);

            // 绘制网格
            paintGrid(sceneG);

            // 绘制塔与敌人
            game.paint(sceneG);

            // 绘制游戏属性 
            paintProperties(propertiesG);

            // 将场景图片绘制到屏幕上
            Graphics g = e.Graphics;
            g.DrawImage(gameSceneImage, GridParams.StartX, GridParams.StartY, GridParams.GridSizeX * GridParams.TileSize, GridParams.GridSizeY * GridParams.TileSize);
            g.DrawImage(gamePropertiesImage, GridParams.StartX, 0, GridParams.GridSizeX * GridParams.TileSize, GridParams.StartY);
        }

        private void paintGrid(Graphics g)
        {
             // 记录路径
            bool[,] roadMark = new bool[GridParams.GridSizeX, GridParams.GridSizeY];

            // 绘制起点终点
            if (game.Level.path.Count > 0)
            {
                roadMark[game.Level.path.First().x, game.Level.path.First().y] = true;
                g.DrawImage(Resource1.entrance, GridParams.TileSize * game.Level.path.First().x, GridParams.TileSize * game.Level.path.First().y, GridParams.TileSize, GridParams.TileSize);

                roadMark[game.Level.path.Last().x, game.Level.path.Last().y] = true;
                g.DrawImage(Resource1.exit, GridParams.TileSize * game.Level.path.Last().x, GridParams.TileSize * game.Level.path.Last().y, GridParams.TileSize, GridParams.TileSize);
            }

            // 绘制路径
            for (int i= 1;i < game.Level.path.Count() - 1;++i)
            {
                var tile = game.Level.path[i];
                roadMark[tile.x, tile.y] = true;
                g.DrawImage(Resource1.road, GridParams.TileSize * tile.x, GridParams.TileSize * tile.y, GridParams.TileSize, GridParams.TileSize);
            }

            // 绘制其他网格
            for (int i = 0; i < GridParams.GridSizeX; ++i)
            {
                for (int j = 0; j < GridParams.GridSizeY; ++j)
                {
                    if (!roadMark[i, j])
                    {
                        g.DrawImage(Resource1.tile, GridParams.TileSize * i, GridParams.TileSize * j, GridParams.TileSize, GridParams.TileSize);
                    }
                }
            }
        }

        private void paintProperties(Graphics g)
        {
            SolidBrush clearBrush = new SolidBrush(Color.IndianRed);
            SolidBrush propBrush = new SolidBrush(Color.Black);
            Font propFont = new Font("宋体", 24);
            g.FillRectangle(clearBrush, 0, 0, GridParams.GridSizeX * GridParams.TileSize, GridParams.StartY);
            g.DrawString("金钱: " + game.Money.ToString(), propFont, propBrush, 10, 20);
            g.DrawString(String.Format("波数: {0:d}/{0:d}", game.CurrentWave, game.Level.waves.Count()), propFont, propBrush, 240, 20);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            string name = null;

            if (sender is Label lbl)
            {
                // 如果点击的是Label，你可以通过lbl.Text获取角色名称
                //MessageBox.Show("You clicked on " + lbl.Text);
                name = lbl.Text;
            }
            else if (sender is PictureBox pb)
            {
                // 如果点击的是PictureBox，Name获取名称
                //MessageBox.Show("You clicked on " + pb.Name);
                name = pb.Name;
            }

            if (name != null)
            {
                if (name.Equals("character 1")) selected = 0;
                if (name.Equals("character 2")) selected = 1;
                if (name.Equals("character 3")) selected = 2;
            }
        }

        private void getMousePosition(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void placeTower(object sender, EventArgs e)
        {
            int gridX = (mouseX - GridParams.StartX) / GridParams.TileSize;
            int gridY = (mouseY - GridParams.StartY) / GridParams.TileSize;

            if (gridX < 0 || gridY < 0 || gridX >= GridParams.GridSizeX || gridY >= GridParams.GridSizeY)
                return;

            bool result = game.placeTower(gridX, gridY, selected);
            if (!result) MessageBox.Show("Fail to place tower!");
        }
    }
}
