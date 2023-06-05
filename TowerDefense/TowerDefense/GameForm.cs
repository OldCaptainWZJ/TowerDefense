using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace TowerDefense
{
    
    public partial class GameForm : Form
    {
        private Game game;
        private GameScenePanel gameScenePanel;
        private int mouseX;
        private int mouseY;
        public GameForm()
        {
            this.Padding = new Padding(GridParams.PaddingSize, GridParams.PaddingSize, GridParams.PaddingSize, GridParams.PaddingSize);
            gameScenePanel = new GameScenePanel();
            
            InitializeComponent();
            Size panelSize = new Size(GridParams.StartX+GridParams.TileSize*GridParams.GridSizeX, GridParams.StartY + GridParams.TileSize * GridParams.GridSizeY);

            //设置父组件为GameForm窗体
            help_panel.Parent = start_menu_panel.Parent;
            help_panel.Size = panelSize;
            gameScenePanel.Parent = start_menu_panel.Parent;
            gameScenePanel.Size = panelSize;
            start_menu_panel.Size = panelSize;
            cover_pictureBox.Size = panelSize;
            this.Size = panelSize;

            gameScenePanel.Location = new Point(0, 0);
            start_menu_panel.Location = new Point(0, 0);
            help_panel.Location = new Point(0, 0);

            //添加子组件到start_menu_penel
            start_menu_panel.Controls.Add(cover_pictureBox);
            cover_pictureBox.Controls.Add(start_game_button);
            cover_pictureBox.Controls.Add(exit_button);
            cover_pictureBox.Controls.Add(select_level_button);
            cover_pictureBox.Controls.Add(help_button);

            //添加子组件到help_panel
            help_panel.Controls.Add(help_content_textBox);
            
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

            game = new Game("chapter1/1-1.txt");
            gameScenePanel.SetGame(game);

            timer1.Start();

            Thread thread = new Thread(() => { game.waveRun(this); });
            thread.Start();

            //加载游戏界面的panel
            gameScenePanel.Visible = true;
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

        public void waveCallback(int val)
        {
            //callback: 0:failed, 1:wave success, 2:level complete
            throw new NotImplementedException();
            //TODO
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(gameScenePanel.Visible)
            {
                gameScenePanel.Invalidate();
            }
        }
    }
    public class GameCharacter
    {
        public Image Icon { get; set; }
        public string Name { get; set; }
    }
}
