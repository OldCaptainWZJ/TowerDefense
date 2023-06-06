using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;

namespace TowerDefense
{
    
    public partial class GameForm : Form
    {
        private Game game;
        private GameScenePanel gameScenePanel;
        private System.Windows.Forms.Timer timer2;
        private int mouseX;
        private int mouseY;
        List<string> chapters;
        int currentChapterIndex;
        private PictureBox chapterImage;
        private Label chapterTitle;
        private Button confirmButton;
        private Button prevButton;
        private Button nextButton;
        private Panel chapterPanel;
        private Panel levelPanel;
        List<string> levels;
        int currentLevelIndex;
        PictureBox levelImage;
        Label levelTitle;
        Button selectButton;
        Button prevLevelButton;
        Button nextLevelButton;

        List<Image> levelImages;
        int currentImageIndex;
        PictureBox storyImage;
        Button prevStoryButton;
        Button nextStoryButton;
        Panel storyPanel;

        List<Image> helpImages;
        int currentHelpImageIndex;
        Panel helpPanel;
        PictureBox helpImage;
        Button prevHelpButton;
        Button nextHelpButton;

        public GameForm()
        {
            this.Padding = new Padding(GridParams.PaddingSize, GridParams.PaddingSize, GridParams.PaddingSize, GridParams.PaddingSize);
            gameScenePanel = new GameScenePanel();
            
            InitializeComponent();
            Size panelSize = new Size(GridParams.StartX+GridParams.TileSize*GridParams.GridSizeX, GridParams.StartY + GridParams.TileSize * GridParams.GridSizeY);

            //设置父组件为GameForm窗体
            gameScenePanel.Parent = start_menu_panel.Parent;
            gameScenePanel.Size = panelSize;
            start_menu_panel.Size = panelSize;
            cover_pictureBox.Size = panelSize;
            this.Size = panelSize;

            gameScenePanel.Location = new Point(0, 0);
            start_menu_panel.Location = new Point(0, 0);

            //添加子组件到start_menu_penel
            start_menu_panel.Controls.Add(cover_pictureBox);
            cover_pictureBox.Controls.Add(start_game_button);
            cover_pictureBox.Controls.Add(exit_button);
            cover_pictureBox.Controls.Add(select_level_button);
            cover_pictureBox.Controls.Add(help_button);

            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 500;
            timer2.Tick += timer2_Tick;
            
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
            int chapterNum = 1;
            int levelNum = 1;

            string savePath = Path.Combine("resource", "save.txt");
            if (System.IO.File.Exists(savePath))
            {
                string[] lines = System.IO.File.ReadAllLines(savePath);
                if (lines.Length > 0)
                {
                    string[] numbers = lines[0].Split(' ');
                    if (numbers.Length >= 2)
                    {
                        chapterNum = int.Parse(numbers[0]);
                        levelNum = int.Parse(numbers[1]);

                        // You can now use chapterNumber and levelNumber
                    }
                }
            }
            button1_Click_1(null, null);
            for(int i= 1;i<chapterNum;i++)
            {
                NextButton_Click(null, null);
            }
            ConfirmButton_Click(null, null);
            for (int i = 1; i < levelNum; i++)
            {
                NextLevelButton_Click(null, null);
            }
            SelectButton_Click(null, null);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("select level button!");
            //start_menu_panel.Parent.Controls.Remove(start_menu_panel);
            //start_menu_panel.Dispose();
            start_menu_panel.Visible = false;

            chapterPanel = new Panel()
            {
                Size = new Size(960, 720),
                BackColor = Color.LightBlue,
            };

            chapterImage = new PictureBox()
            {
                Size = new Size(400, 300),
                Location = new Point((chapterPanel.Width - 400) / 2, (chapterPanel.Height - 300) / 2),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            chapterTitle = new Label()
            {
                AutoSize = false,
                Width = chapterPanel.Width,
                Height = 50,
                Location = new Point(0, chapterImage.Bottom),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Serial",15,FontStyle.Bold)
            };


            confirmButton = new System.Windows.Forms.Button()
            {
                Width = 100,
                Height = 30,
                Location = new Point((chapterPanel.Width - 100) / 2, chapterTitle.Bottom + 10),
                Text = "Confirm",
                Font=new Font("Serial", 10, FontStyle.Bold)
            };
            confirmButton.Click += ConfirmButton_Click;

            prevButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(10, (chapterPanel.Height - 30) / 2),
                Text = "<",
            };
            prevButton.Click += PrevButton_Click;

            nextButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(chapterPanel.Width - 60, (chapterPanel.Height - 30) / 2),
                Text = ">",
            };
            
            nextButton.Click += NextButton_Click;
            Button back_to_start_button = new Button()
            {
                Location = new Point(850, 30),
                Text = "BACK"
            };
            back_to_start_button.Click += Back_To_Start_Button_Click;

            chapterPanel.Controls.Add(chapterImage);
            chapterPanel.Controls.Add(chapterTitle);
            chapterPanel.Controls.Add(confirmButton);
            chapterPanel.Controls.Add(prevButton);
            chapterPanel.Controls.Add(nextButton);
            chapterPanel.Controls.Add(back_to_start_button);

            this.Controls.Add(chapterPanel);

            // Load the list of chapters from the Resource folder
            chapters = Directory.GetDirectories("resource/games_config").ToList();
            for(int i = 0; i < chapters.Count; i++)
            {
                chapters[i] =chapters[i].Substring(22);
            }

            // Set the current chapter to the first one
            currentChapterIndex = 1;
            LoadChapter(currentChapterIndex);
            //加载选关页面的panel
        }

        private void Back_To_Start_Button_Click(object sender, EventArgs e)
        {
            start_menu_panel.Visible=true;
            chapterPanel.Visible=false;
        }

        private void LoadChapter(int index)
        {
            if (index <= 0 || index > chapters.Count)
                return;

            string chapter = chapters[index-1];
            string imageName = $"{chapter}_image.png";
            Debug.WriteLine(imageName);
            //Debug.WriteLine(chapterImage);
            chapterImage.Image = Image.FromFile(Path.Combine("resource/games_config", imageName));
            chapterTitle.Text = chapter;

            prevButton.Visible = (index != 1);
            nextButton.Visible = (index != chapters.Count);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            chapterPanel.Visible = false;
            levelPanel = new Panel()
            {
                Size = new Size(960, 720),
                BackColor = Color.LightBlue,
                Visible = false,
            };
            levelPanel.Visible = true;

            levelImage = new PictureBox()
            {
                Size = new Size(400, 300),
                Location = new Point((levelPanel.Width - 400) / 2, (levelPanel.Height - 300) / 2),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            levelTitle = new Label()
            {
                AutoSize = false,
                Width = levelPanel.Width,
                Height = 30,
                Location = new Point(0, levelImage.Bottom),
                TextAlign = ContentAlignment.MiddleCenter,
            };

            selectButton = new Button()
            {
                Width = 100,
                Height = 30,
                Location = new Point((levelPanel.Width - 100) / 2, levelTitle.Bottom + 10),
                Text = "Select",
            };
            selectButton.Click += SelectButton_Click;

            prevLevelButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(10, (levelPanel.Height - 30) / 2),
                Text = "<",
            };
            prevLevelButton.Click += PrevLevelButton_Click;

            nextLevelButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(levelPanel.Width - 60, (levelPanel.Height - 30) / 2),
                Text = ">",
            };
            nextLevelButton.Click += NextLevelButton_Click;

            Button back_to_chapter_button = new Button()
            {
                Location = new Point(850, 30),
                Text = "BACK"
            };
            back_to_chapter_button.Click += Back_To_Chapter_Button_Click;

            levelPanel.Controls.Add(levelImage);
            levelPanel.Controls.Add(levelTitle);
            levelPanel.Controls.Add(selectButton);
            levelPanel.Controls.Add(prevLevelButton);
            levelPanel.Controls.Add(nextLevelButton);
            levelPanel.Controls.Add(back_to_chapter_button);

            this.Controls.Add(levelPanel);

            levels = Directory.GetFiles("resource/games_config/" + chapters[currentChapterIndex-1],"*",SearchOption.AllDirectories).ToList();
            for (int i = 0; i < levels.Count; i++)
            {
                levels[i] = levels[i].Substring(31,3);
            }

            // Set the current level to the first one
            currentLevelIndex = 1;
            LoadLevel(currentLevelIndex);
        }

        private void Back_To_Chapter_Button_Click(object sender, EventArgs e)
        {
            chapterPanel.Visible = true;
            levelPanel.Visible = false;
        }

        private void LoadLevel(int index)
        {
            if (index < 1 || index > levels.Count)
                return;

            string level = levels[index-1];
            string imageName = $"0.png";

            levelImage.Image = Image.FromFile(Path.Combine("resource/stories/"+$"{levels[currentLevelIndex - 1]}/",imageName));;
            levelTitle.Text = level;

            prevLevelButton.Visible = (index != 1);
            nextLevelButton.Visible = (index != levels.Count);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            StartLevel(levels[currentLevelIndex-1]);
        }

        private void StartLevel(string levelName)
        {
            string savePath = Path.Combine("resource", "save.txt");
            string saveData = $"{currentChapterIndex} {currentLevelIndex}";

            System.IO.File.WriteAllText(savePath, saveData);
            storyPanel = new Panel()
            {
                Size = new Size(960, 720),
                BackColor = Color.LightBlue,
                Visible = false,
            };

            storyImage = new PictureBox()
            {
                Size = storyPanel.Size,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            
            prevStoryButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(10, (storyPanel.Height - 30) / 2),
                Text = "<",
            };
            prevStoryButton.Click += PrevStoryButton_Click;

            nextStoryButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(storyPanel.Width - 60, (storyPanel.Height - 30) / 2),
                Text = ">",
            };
            nextStoryButton.Click += NextStoryButton_Click;

            storyPanel.Controls.Add(storyImage);
            storyImage.Controls.Add(prevStoryButton);
            storyImage.Controls.Add(nextStoryButton);

            this.Controls.Add(storyPanel);

            string[] imagePaths = Directory.GetFiles(Path.Combine("resource", "stories", levelName))
        .OrderBy(path => int.Parse(Path.GetFileNameWithoutExtension(path)))
        .ToArray();

            levelImages = imagePaths.Select(Image.FromFile).ToList();
            currentImageIndex = 0;

            storyImage.Image = levelImages[currentImageIndex];
            prevStoryButton.Visible = false;
            nextStoryButton.Visible = true;
            levelPanel.Visible = false;
            storyPanel.Visible = true;
        }

        private void PrevStoryButton_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                storyImage.Image = levelImages[currentImageIndex];
                nextStoryButton.Visible = true;

                if (currentImageIndex == 0)
                {
                    prevStoryButton.Visible = false;
                }
            }
        }

        private void NextStoryButton_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < levelImages.Count)
            {
                
                prevStoryButton.Visible = true;

                if (currentImageIndex == levelImages.Count-1)
                {
                    StartGame();
                }
                else 
                {
                    currentImageIndex++;
                    storyImage.Image = levelImages[currentImageIndex];
                }
            }
        }
        void StartGame()
        {
            string levelPath = chapters[currentChapterIndex - 1] + "/" + levels[currentLevelIndex - 1] + ".txt";

            game = new Game(levelPath);
            gameScenePanel.SetGame(game);

            timer1.Start();


            //加载游戏界面的panel
            if(storyPanel!=null&&storyPanel.Parent!=null) storyPanel.Parent.Controls.Remove(storyPanel);
            if(storyPanel!=null) storyPanel.Dispose();
            gameScenePanel.Visible = true;
            Debug.WriteLine(gameScenePanel.Visible);
            timer2.Start();
        }


        private void PrevLevelButton_Click(object sender, EventArgs e)
        {
            if (currentLevelIndex > 1)
            {
                currentLevelIndex--;
                LoadLevel(currentLevelIndex);
            }
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            if (currentLevelIndex < levels.Count )
            {
                currentLevelIndex++;
                LoadLevel(currentLevelIndex);
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (currentChapterIndex > 1)
            {
                currentChapterIndex--;
                LoadChapter(currentChapterIndex);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currentChapterIndex < chapters.Count )
            {
                currentChapterIndex++;
                LoadChapter(currentChapterIndex);
            }
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
            helpPanel = new Panel()
            {
                Size = new Size(960, 720),
                BackColor = Color.LightBlue,
                Visible = false,
            };

            helpImage = new PictureBox()
            {
                Size = helpPanel.Size,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            prevHelpButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(10, (helpPanel.Height - 30) / 2),
                Text = "<",
            };
            prevHelpButton.Click += PrevHelpButton_Click;

            nextHelpButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(helpPanel.Width - 60, (helpPanel.Height - 30) / 2),
                Text = ">",
            };
            nextHelpButton.Click += NextHelpButton_Click;

            Button returnButton = new Button()
            {
                Width = 50,
                Height = 30,
                Location = new Point(helpPanel.Width - 60, 10),  // placed at top-right corner
                Text = "返回",
            };

            returnButton.Click += ReturnButton_Click;

            helpPanel.Controls.Add(returnButton);
            helpPanel.Controls.Add(helpImage);
            helpImage.Controls.Add(prevHelpButton);
            helpImage.Controls.Add(nextHelpButton);

            this.Controls.Add(helpPanel);
            helpImages = new List<Image>();
            LoadHelpImages();
            helpPanel.Visible = true;
        }
        private void LoadHelpImages()
        {
            string[] imagePaths = Directory.GetFiles(Path.Combine("resource", "help"))
                .OrderBy(path => int.Parse(Path.GetFileNameWithoutExtension(path)))
                .ToArray();
            helpImages = imagePaths.Select(Image.FromFile).ToList();
            Debug.WriteLine(helpImages.Count);
            currentHelpImageIndex = 0;

            helpImage.Image = helpImages[currentHelpImageIndex];
            prevHelpButton.Visible = false;
            nextHelpButton.Visible = (helpImages.Count >1);
        }

        private void PrevHelpButton_Click(object sender, EventArgs e)
        {
            if (currentHelpImageIndex > 0)
            {
                currentHelpImageIndex--;
                helpImage.Image = helpImages[currentHelpImageIndex];
                nextHelpButton.Visible = true;

                if (currentHelpImageIndex == 0)
                {
                    prevHelpButton.Visible = false;
                }
            }
        }

        private void NextHelpButton_Click(object sender, EventArgs e)
        {
            if (currentHelpImageIndex < helpImages.Count - 1)
            {
                currentHelpImageIndex++;
                helpImage.Image = helpImages[currentHelpImageIndex];
                prevHelpButton.Visible = true;

                if (currentHelpImageIndex == helpImages.Count - 1)
                {
                    nextHelpButton.Visible = false;
                }
            }
        }
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            start_menu_panel.Visible = true;
            helpPanel.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(gameScenePanel.Visible)
            {
                gameScenePanel.Invalidate();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!gameScenePanel.Visible)
            {
                if (game != null && game.gameResult == 0)
                {
                    timer2.Stop();
                    if (gameScenePanel != null && gameScenePanel.Parent != null) gameScenePanel.Parent.Controls.Remove(gameScenePanel);
                    if (gameScenePanel != null) gameScenePanel.Dispose();
                    gameScenePanel = new GameScenePanel();
                    gameScenePanel.Parent = start_menu_panel.Parent;
                    Size panelSize = new Size(GridParams.StartX + GridParams.TileSize * GridParams.GridSizeX, GridParams.StartY + GridParams.TileSize * GridParams.GridSizeY);
                    gameScenePanel.Size = panelSize;
                    gameScenePanel.Location = new Point(0, 0);
                    StartGame();
                }
                else if (game != null && game.gameResult == 2)
                {
                    timer2.Stop();
                    if (gameScenePanel != null && gameScenePanel.Parent != null) gameScenePanel.Parent.Controls.Remove(gameScenePanel);
                    if (gameScenePanel != null) gameScenePanel.Dispose();
                    gameScenePanel = new GameScenePanel();
                    gameScenePanel.Parent = start_menu_panel.Parent;
                    Size panelSize = new Size(GridParams.StartX + GridParams.TileSize * GridParams.GridSizeX, GridParams.StartY + GridParams.TileSize * GridParams.GridSizeY);
                    gameScenePanel.Size = panelSize;
                    gameScenePanel.Location = new Point(0, 0);
                    if (storyPanel != null && storyPanel.Parent != null) storyPanel.Parent.Controls.Remove(storyPanel);
                    if (storyPanel != null) storyPanel.Dispose();
                    if (currentLevelIndex == levels.Count)
                    {
                        if (levelPanel != null && levelPanel.Parent != null) levelPanel.Parent.Controls.Remove(levelPanel);
                        if (levelPanel != null) levelPanel.Dispose();
                        chapterPanel.Visible = true;
                    }
                    else
                    {
                        NextLevelButton_Click(null,null);
                        levelPanel.Visible = true;
                    }
                }
            }
        }
    }
    public class GameCharacter
    {
        public Image Icon { get; set; }
        public string Name { get; set; }
    }
}
