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
    }
}
