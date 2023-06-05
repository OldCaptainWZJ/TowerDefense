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
        Form form;

        Game game;
        Image gameSceneImage;
        Image gamePropertiesImage;

        Button nextWaveButton;
        Button exitButton;

        Panel towerListPanel;
        List<Label> towerListLabels;
        List<PictureBox> towerListPictureBoxes;

        const int towerItemPadding = 10;
        const int towerItemWidth = 160;
        const int towerItemHeight = 50 + 2 * towerItemPadding;

        int selected = -1;
        int mouseX;
        int mouseY;

        bool waveInProcess = false;

        public GameScenePanel()
        {
            initPanel();       
            initDrawImages();
            initButtons();
            initTowerList();
        }

        private void initPanel()
        {
            BackColor = System.Drawing.Color.IndianRed;
            Location = new System.Drawing.Point(3, 3);
            Name = "game_scene_panel";
            Size = new System.Drawing.Size(1181, 854);
            TabIndex = 6;
            Visible = false;
            VisibleChanged += new EventHandler(onVisible);
            Paint += new System.Windows.Forms.PaintEventHandler(onPaint);
            DoubleBuffered = true;

        }

        private void initDrawImages()
        {
            gameSceneImage = new Bitmap(GridParams.GridSizeX * GridParams.TileSize, GridParams.GridSizeY * GridParams.TileSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            gamePropertiesImage = new Bitmap(GridParams.GridSizeX * GridParams.TileSize, GridParams.StartY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        private void initButtons()
        {
            nextWaveButton = new Button();
            nextWaveButton.Text = "下一波敌人";
            nextWaveButton.AutoSize = false;
            nextWaveButton.Width = 160;
            nextWaveButton.Height = 50;
            nextWaveButton.Location = new Point(0, 10);
            nextWaveButton.BackColor = Color.AliceBlue;
            nextWaveButton.Click += nextWaveButtonClick;
            Controls.Add(nextWaveButton);

            exitButton = new Button();
            exitButton.Text = "退出";
            exitButton.AutoSize = false;
            exitButton.Width = 160;
            exitButton.Height = 50;
            exitButton.Location = new Point(0, 70);
            exitButton.BackColor = Color.AliceBlue;
            exitButton.Click += exitButtonClick;
            Controls.Add(exitButton);
        }

        private void initTowerList()
        {
            towerListPanel = new Panel();
            towerListPanel.Size = new Size(towerItemWidth, this.Height - 120); // 假设你的窗体高度足够大
            towerListPanel.Location = new Point(0, 120);
            towerListPanel.AutoScroll = true; // 如果内容超出Panel的大小，则自动显示滚动条
            Controls.Add(towerListPanel);

            MouseMove += getMousePosition;
            Click += placeTower; //Add Place Tower Event

            towerListLabels=new List<Label>();
            towerListPictureBoxes=new List<PictureBox>();
        }

        public void onVisible(object sender, EventArgs e)
        {
            if(Visible)
            {
                int startX = 0;
                int startY = 0;

                foreach (var towerIdx in game.Level.towerSelection)
                {
                    var tower = Tower.produceTower(towerIdx, new Tile(0, 0));

                    Label lbl = new Label();
                    lbl.Text = tower.getName();
                    lbl.AutoSize = false; // 不自动调整大小，将其设定为指定宽度
                    lbl.Width = towerItemWidth - 50 - 3 * towerItemPadding; // 预留出图片和额外的padding的空间
                    lbl.Location = new Point(startX + towerItemPadding, startY + towerItemPadding + (50 - lbl.Height) / 2); // 使得label和图片在同一行中居中
                    lbl.Click += Item_Click; // 添加点击事件处理器
                    towerListPanel.Controls.Add(lbl);
                    towerListLabels.Add(lbl);
                    
                     // 创建并设置PictureBox
                    PictureBox pb = new PictureBox();
                    pb.Name = tower.getName();
                    pb.Image = tower.getTexture();
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Height = 50;
                    pb.Width = 50;
                    pb.Location = new Point(lbl.Width + 2 * towerItemPadding, startY + towerItemPadding); // 绘制图片
                    pb.Click += Item_Click; // 添加点击事件处理器
                    towerListPanel.Controls.Add(pb);
                    towerListPictureBoxes.Add(pb);

                    startY += towerItemHeight;
                }
            }
            else
            {
                foreach (var label in towerListLabels)
                {
                    Controls.Remove(label);
                }

                foreach (var pb in towerListPictureBoxes)
                {
                    Controls.Remove(pb);
                }

                towerListLabels.Clear();
                towerListPictureBoxes.Clear();
            }
        }

        public void SetGame(Game game)
        {
            this.game = game;
        }

        public void nextWaveButtonClick(object sender, EventArgs e)
        {
            if (waveInProcess) return;

            waveInProcess = true;

            Thread thread = new Thread(() => { game.waveRun(this); });
            thread.Start();
        }

        public void waveCallback(int val)
        {
            //callback: 0:failed, 1:wave success, 2:level complete

            waveInProcess = false;
            //TODO: process failure and level completion
        }

        public void exitButtonClick(object sender, EventArgs e)
        {
        }

        public void onPaint(object sender, PaintEventArgs e)
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

            // 监控按钮状态
            if (waveInProcess) nextWaveButton.Enabled = false;
            else nextWaveButton.Enabled = true;

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
            g.DrawString(String.Format("已完成波数: " + game.CurrentWave.ToString() + "/" + game.Level.waves.Count()), propFont, propBrush, 240, 20);
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
                if (name.Equals("Pig")) selected = 1;
                if (name.Equals("Snowball")) selected = 2;
                if (name.Equals("Napoleon")) selected = 3;
                if (name.Equals("Boxer")) selected = 4;
                if (name.Equals("Hedgehog")) selected = 5;
            }
        }

        private void getMousePosition(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void placeTower(object sender, EventArgs e)
        {
            if (selected == -1) return;

            int gridX = (mouseX - GridParams.StartX) / GridParams.TileSize;
            int gridY = (mouseY - GridParams.StartY) / GridParams.TileSize;

            if (gridX < 0 || gridY < 0 || gridX >= GridParams.GridSizeX || gridY >= GridParams.GridSizeY)
                return;

            bool result = game.placeTower(gridX, gridY, selected);
            if (!result) MessageBox.Show("Fail to place tower!");

            selected = -1;
        }
    }
}
