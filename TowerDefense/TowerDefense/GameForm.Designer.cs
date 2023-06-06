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
            this.start_game_button = new System.Windows.Forms.Button();
            this.select_level_button = new System.Windows.Forms.Button();
            this.help_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.cover_pictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start_menu_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // start_menu_panel
            // 
            this.start_menu_panel.Controls.Add(this.start_game_button);
            this.start_menu_panel.Controls.Add(this.select_level_button);
            this.start_menu_panel.Controls.Add(this.help_button);
            this.start_menu_panel.Controls.Add(this.exit_button);
            this.start_menu_panel.Controls.Add(this.cover_pictureBox);
            this.start_menu_panel.Location = new System.Drawing.Point(0, 0);
            this.start_menu_panel.Name = "start_menu_panel";
            this.start_menu_panel.Size = new System.Drawing.Size(1181, 855);
            this.start_menu_panel.TabIndex = 0;
            // 
            // start_game_button
            // 
            this.start_game_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.start_game_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.start_game_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.start_game_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_game_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_game_button.ForeColor = System.Drawing.Color.Black;
            this.start_game_button.Location = new System.Drawing.Point(604, 376);
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
            this.select_level_button.Location = new System.Drawing.Point(604, 457);
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
            this.help_button.Location = new System.Drawing.Point(604, 538);
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
            this.exit_button.Location = new System.Drawing.Point(604, 623);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(288, 56);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "EXIT";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
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
            // timer1
            // 
            this.timer1.Interval = 13;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 896);
            this.Controls.Add(this.start_menu_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Tower Defense";
            this.start_menu_panel.ResumeLayout(false);
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
        private System.Windows.Forms.Timer timer1;
    }
}

