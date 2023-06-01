using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public partial class GameForm : Form
    {
        private Game game;
        private Level level;

        public GameForm()
        {
            InitializeComponent();
            start_menu_panel.Controls.Add(cover_pictureBox);
            cover_pictureBox.Controls.Add(start_game_button);
            cover_pictureBox.Controls.Add(exit_button);
            cover_pictureBox.Controls.Add(select_level_button);
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
            start_menu_panel.Parent.Controls.Remove(start_menu_panel);
            start_menu_panel.Dispose();
            //加载游戏界面的panel
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("select level button!");
            start_menu_panel.Parent.Controls.Remove(start_menu_panel);
            start_menu_panel.Dispose();
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
    }
}
