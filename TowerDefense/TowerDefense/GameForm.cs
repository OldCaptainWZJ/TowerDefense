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

        public GameForm()
        {
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

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            startMenuPaint(sender, e);
            gameScenePaint(sender, e);
            towerPlacementPaint(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            gameSceneLoad(sender, e);
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
    }
}
