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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start_menu_panel = new System.Windows.Forms.Panel();
            this.exit_button = new System.Windows.Forms.Button();
            this.select_level_button = new System.Windows.Forms.Button();
            this.start_game_button = new System.Windows.Forms.Button();
            this.cover_pictureBox = new System.Windows.Forms.PictureBox();
            this.start_menu_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // start_menu_panel
            // 
            this.start_menu_panel.Controls.Add(this.exit_button);
            this.start_menu_panel.Controls.Add(this.select_level_button);
            this.start_menu_panel.Controls.Add(this.start_game_button);
            this.start_menu_panel.Controls.Add(this.cover_pictureBox);
            this.start_menu_panel.Location = new System.Drawing.Point(0, 0);
            this.start_menu_panel.Name = "start_menu_panel";
            this.start_menu_panel.Size = new System.Drawing.Size(1181, 855);
            this.start_menu_panel.TabIndex = 0;
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
            // select_level_button
            // 
            this.select_level_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.select_level_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.select_level_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.select_level_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_level_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_level_button.ForeColor = System.Drawing.Color.Black;
            this.select_level_button.Location = new System.Drawing.Point(756, 659);
            this.select_level_button.Name = "select_level_button";
            this.select_level_button.Size = new System.Drawing.Size(288, 56);
            this.select_level_button.TabIndex = 2;
            this.select_level_button.Text = "SELECT LEVEL";
            this.select_level_button.UseVisualStyleBackColor = false;
            this.select_level_button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // start_game_button
            // 
            this.start_game_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.start_game_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.start_game_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.start_game_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_game_button.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_game_button.ForeColor = System.Drawing.Color.Black;
            this.start_game_button.Location = new System.Drawing.Point(756, 574);
            this.start_game_button.Name = "start_game_button";
            this.start_game_button.Size = new System.Drawing.Size(288, 56);
            this.start_game_button.TabIndex = 1;
            this.start_game_button.Text = "START";
            this.start_game_button.UseVisualStyleBackColor = false;
            this.start_game_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // cover_pictureBox
            // 
            this.cover_pictureBox.Image = global::TowerDefense.Properties.Resources.cover;
            this.cover_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.cover_pictureBox.Name = "cover_pictureBox";
            this.cover_pictureBox.Size = new System.Drawing.Size(1181, 855);
            this.cover_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cover_pictureBox.TabIndex = 0;
            this.cover_pictureBox.TabStop = false;
            this.cover_pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.start_menu_panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Tower Defense";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.start_menu_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel start_menu_panel;
        private System.Windows.Forms.PictureBox cover_pictureBox;
        private System.Windows.Forms.Button start_game_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button select_level_button;
    }
}

