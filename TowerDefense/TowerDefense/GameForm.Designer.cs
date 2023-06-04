namespace TowerDefense
{
    partial class GameForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.start_menu_panel = new System.Windows.Forms.Panel();
            this.help_panel = new System.Windows.Forms.Panel();
            this.game_scene_panel = new System.Windows.Forms.Panel();
            this.help_to_start_menu_button = new System.Windows.Forms.Button();
            this.help_content_textBox = new System.Windows.Forms.TextBox();
            this.cover_pictureBox = new System.Windows.Forms.PictureBox();
            this.start_game_button = new System.Windows.Forms.Button();
            this.select_level_button = new System.Windows.Forms.Button();
            this.help_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start_menu_panel.SuspendLayout();
            this.help_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // start_menu_panel
            // 
            this.start_menu_panel.Controls.Add(this.help_panel);
            this.start_menu_panel.Controls.Add(this.cover_pictureBox);
            this.start_menu_panel.Controls.Add(this.start_game_button);
            this.start_menu_panel.Controls.Add(this.select_level_button);
            this.start_menu_panel.Controls.Add(this.help_button);
            this.start_menu_panel.Controls.Add(this.exit_button);
            this.start_menu_panel.Location = new System.Drawing.Point(0, 0);
            this.start_menu_panel.Name = "start_menu_panel";
            this.start_menu_panel.Size = new System.Drawing.Size(1181, 855);
            this.start_menu_panel.TabIndex = 0;
            // 
            // help_panel
            // 
            this.help_panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.help_panel.Controls.Add(this.game_scene_panel);
            this.help_panel.Controls.Add(this.help_to_start_menu_button);
            this.help_panel.Controls.Add(this.help_content_textBox);
            this.help_panel.Location = new System.Drawing.Point(0, 1);
            this.help_panel.Name = "help_panel";
            this.help_panel.Size = new System.Drawing.Size(1181, 851);
            this.help_panel.TabIndex = 5;
            this.help_panel.Visible = false;
            // 
            // game_scene_panel
            // 
            this.game_scene_panel.BackColor = System.Drawing.Color.IndianRed;
            this.game_scene_panel.Location = new System.Drawing.Point(0, 0);
            this.game_scene_panel.Name = "game_scene_panel";
            this.game_scene_panel.Size = new System.Drawing.Size(1181, 854);
            this.game_scene_panel.TabIndex = 6;
            this.game_scene_panel.Visible = false;
            this.game_scene_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.game_scene_panel_Paint);
            // 
            // help_to_start_menu_button
            // 
            this.help_to_start_menu_button.Location = new System.Drawing.Point(947, 11);
            this.help_to_start_menu_button.Name = "help_to_start_menu_button";
            this.help_to_start_menu_button.Size = new System.Drawing.Size(213, 59);
            this.help_to_start_menu_button.TabIndex = 1;
            this.help_to_start_menu_button.Text = "BACK";
            this.help_to_start_menu_button.UseVisualStyleBackColor = true;
            this.help_to_start_menu_button.Click += new System.EventHandler(this.help_to_start_menu_button_Click);
            // 
            // help_content_textBox
            // 
            this.help_content_textBox.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.help_content_textBox.Location = new System.Drawing.Point(151, 92);
            this.help_content_textBox.Multiline = true;
            this.help_content_textBox.Name = "help_content_textBox";
            this.help_content_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.help_content_textBox.Size = new System.Drawing.Size(864, 759);
            this.help_content_textBox.TabIndex = 0;
            // 
            // cover_pictureBox
            // 
            this.cover_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("cover_pictureBox.Image")));
            this.cover_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.cover_pictureBox.Name = "cover_pictureBox";
            this.cover_pictureBox.Size = new System.Drawing.Size(1181, 855);
            this.cover_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cover_pictureBox.TabIndex = 0;
            this.cover_pictureBox.TabStop = false;
            this.cover_pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // start_game_button
            // 
            this.start_game_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.start_game_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.start_game_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.start_game_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_game_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_game_button.ForeColor = System.Drawing.Color.Black;
            this.start_game_button.Location = new System.Drawing.Point(756, 496);
            this.start_game_button.Name = "start_game_button";
            this.start_game_button.Size = new System.Drawing.Size(288, 56);
            this.start_game_button.TabIndex = 1;
            this.start_game_button.Text = "START";
            this.start_game_button.UseVisualStyleBackColor = false;
            this.start_game_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // select_level_button
            // 
            this.select_level_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.select_level_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.select_level_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.select_level_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_level_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_level_button.ForeColor = System.Drawing.Color.Black;
            this.select_level_button.Location = new System.Drawing.Point(756, 579);
            this.select_level_button.Name = "select_level_button";
            this.select_level_button.Size = new System.Drawing.Size(288, 56);
            this.select_level_button.TabIndex = 2;
            this.select_level_button.Text = "SELECT LEVEL";
            this.select_level_button.UseVisualStyleBackColor = false;
            this.select_level_button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // help_button
            // 
            this.help_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.help_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.help_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.help_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_button.ForeColor = System.Drawing.Color.Black;
            this.help_button.Location = new System.Drawing.Point(756, 659);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(288, 56);
            this.help_button.TabIndex = 4;
            this.help_button.Text = "HELP";
            this.help_button.UseVisualStyleBackColor = false;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exit_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.exit_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_button.ForeColor = System.Drawing.Color.Black;
            this.exit_button.Location = new System.Drawing.Point(756, 743);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(288, 56);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "EXIT";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.start_menu_panel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Tower Defense";
            this.start_menu_panel.ResumeLayout(false);
            this.help_panel.ResumeLayout(false);
            this.help_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel start_menu_panel;
        private System.Windows.Forms.PictureBox cover_pictureBox;
        private System.Windows.Forms.Button start_game_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button select_level_button;
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.Panel help_panel;
        private System.Windows.Forms.TextBox help_content_textBox;
        private System.Windows.Forms.Button help_to_start_menu_button;
        private System.Windows.Forms.Panel game_scene_panel;
        private System.Windows.Forms.Timer timer1;
    }
}

