using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TowerDefense
{
    public partial class GameForm : Form
    {
        private Game game;
        private Level level;
        private Image gameSceneImage;

        public GameForm()
        {
            gameSceneImage = new Bitmap(GridParams.GridSizeX * GridParams.TileSize, GridParams.GridSizeY * GridParams.TileSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            InitializeComponent();

            //设置父组件为GameForm窗体
            help_panel.Parent = start_menu_panel.Parent;
            game_scene_panel.Parent = start_menu_panel.Parent;

            //添加子组件到start_menu_penel
            start_menu_panel.Controls.Add(cover_pictureBox);
            cover_pictureBox.Controls.Add(start_game_button);
            cover_pictureBox.Controls.Add(exit_button);
            cover_pictureBox.Controls.Add(select_level_button);
            cover_pictureBox.Controls.Add(help_button);

            //添加子组件到help_panel
            help_panel.Controls.Add(help_content_textBox);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game_scene_panel.Visible)
            {
                game_scene_panel.Invalidate();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("start game button!");
            //start_menu_panel.Parent.Controls.Remove(start_menu_panel);
            //start_menu_panel.Dispose();
            start_menu_panel.Visible = false;

            level = new Level("chapter1/1-1.txt");

            //加载游戏界面的panel
            game_scene_panel.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("select level button!");
            //start_menu_panel.Parent.Controls.Remove(start_menu_panel);
            //start_menu_panel.Dispose();
            start_menu_panel.Visible = false;
            //加载选关页面的panel
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("exit button!");
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void help_button_Click(object sender, EventArgs e)
        {
            start_menu_panel.Visible = false;
            help_panel.Visible = true;
            string configFile = @"resource/games_config/help.txt"; // 替换为你的配置文件路径

            using (StreamReader sr = new StreamReader(configFile))
            {
                string content = sr.ReadToEnd();
                help_content_textBox.Text = content;
                
            }
        }

        private void help_to_start_menu_button_Click(object sender, EventArgs e)
        {
            help_panel.Visible = false;
            start_menu_panel.Visible = true;
        }

        private void game_scene_panel_Paint(object sender, PaintEventArgs e)
        {
            // 将游戏场景绘制到一张图片上
            Graphics sceneG = Graphics.FromImage(gameSceneImage);

            // 记录路径
            bool[,] roadMark = new bool[GridParams.GridSizeX, GridParams.GridSizeY];

            // 绘制起点终点
            if (level.path.Count > 0)
            {
                roadMark[level.path.First().x, level.path.First().y] = true;
                sceneG.DrawImage(Resource1.entrance, GridParams.TileSize * level.path.First().x, GridParams.TileSize * level.path.First().y, GridParams.TileSize, GridParams.TileSize);

                roadMark[level.path.Last().x, level.path.Last().y] = true;
                sceneG.DrawImage(Resource1.exit, GridParams.TileSize * level.path.Last().x, GridParams.TileSize * level.path.Last().y, GridParams.TileSize, GridParams.TileSize);
            }

            // 绘制路径
            for (int i= 1;i < level.path.Count() - 1;++i)
            {
                var tile = level.path[i];
                roadMark[tile.x, tile.y] = true;
                sceneG.DrawImage(Resource1.road, GridParams.TileSize * tile.x, GridParams.TileSize * tile.y, GridParams.TileSize, GridParams.TileSize);
            }

            // 绘制其他网格
            for (int i = 0; i < GridParams.GridSizeX; ++i)
            {
                for (int j = 0; j < GridParams.GridSizeY; ++j)
                {
                    if (!roadMark[i, j])
                    {
                        sceneG.DrawImage(Resource1.tile, GridParams.TileSize * i, GridParams.TileSize * j, GridParams.TileSize, GridParams.TileSize);
                    }
                }
            }

            // 绘制塔与敌人
            game.paint(sceneG);

            // 将场景图片绘制到屏幕上
            Graphics g = e.Graphics;
            g.DrawImage(gameSceneImage, GridParams.StartX, GridParams.StartY, GridParams.GridSizeX * GridParams.TileSize, GridParams.GridSizeY * GridParams.TileSize);
        }

    }
}
