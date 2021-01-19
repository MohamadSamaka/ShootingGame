using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace ShootingGame
{
    public partial class Form1 : Form
    {
        string MaterialsDoc;
        PictureBox SpaceShip = new PictureBox();
        string[] EnemiesPicsSrc = new string[5];
        public Panel ScoreTimePan = new Panel();
        Label TScore = new Label();
        Label Time = new Label();
        Button StartStop = new Button();
        List<PictureBox> Enemies = new List<PictureBox>();
        List<PictureBox> ShipBullets = new List<PictureBox>();
        List<PictureBox> EnemiesBullets = new List<PictureBox>();
        int x_ship = 450, y_ship = 850, x_enemy = -600, y_enemy = 20, IScore = 0, speed = 5;
        int Tmins = 2, Tsecs = 0, Flip = 20;
        public int Level;
        bool start = true;
        Keys K;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            EventAdder();
            MaterialsDoc = GetMaterialsDocSource();
            this.BackgroundImage = Image.FromFile(MaterialsDoc + @"\Background\background.jpg");
            LevelMenu.BackgroundImage = Image.FromFile(MaterialsDoc + @"\Background\MenuBackground.jpg");
            EnemeiesSrcFiller();
        }


        private void EventAdder()
        {
            Level1.Click += new EventHandler(ShipSpawn);
            Level1.Click += new EventHandler(MouseClickSound);
            Level2.Click += new EventHandler(ShipSpawn);
            Level2.Click += new EventHandler(MouseClickSound);
            StartStop.Click += new EventHandler(StartStopGame);
        }


        private void LevelMen(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "Level 1":
                    Level = 1;
                    LevelMenu.Hide();
                    this.Size = new Size(1000, 1000);
                    SetPanStuff(Tmins.ToString() + " : " + Tsecs.ToString() + "0");
                    EnemiesPictureBoxesMaker();
                    CenterWindow();
                    break;
                case "Level 2":
                    Level = 2;
                    LevelMenu.Hide();
                    this.Size = new Size(1000, 1000);
                    SetPanStuff("");
                    EnemiesPictureBoxesMaker();
                    CenterWindow();
                    break;
            }
        }


        public void Reset()
        {
            x_ship = 450;
            y_ship = 850;
            x_enemy = -600;
            y_enemy = 20;
            IScore = 0;
            speed = 5;
            Tmins = 2;
            Tsecs = 0;
            start = true;
            ScoreTimePan.Controls.Clear();
            this.Size = new Size(385, 408);
            LevelMenu.Show();
            CenterWindow();
            if (Level == 2)
            {
                int size = Enemies.Count();
                for (int i = 0; i < size; i++)
                {
                    Enemies[i].Dispose();
                    Enemies.Remove(Enemies[i]);
                    size--;
                    i--;
                }
                size = EnemiesBullets.Count();
                for (int i = 0; i < size; i++)
                {
                    EnemiesBullets[i].Dispose();
                    EnemiesBullets.Remove(EnemiesBullets[i]);
                    size--;
                    i--;
                }
            }
        }


        void ClearCurrentWindow()
        {
            ScoreTimePan.Click -= new EventHandler(BulletMaker);
            StartStop.Enabled = false;
            this.Click -= new EventHandler(BulletMaker);
            if (ShipBullets.Count != 0)
                for (int i = 0; i < ShipBullets.Count(); i++)
                {
                    ShipBullets[i].Dispose();
                    ShipBullets.Remove(ShipBullets[i]);
                    i--;
                }
            if (Enemies.Count != 0)
                for (int i = 0; i < Enemies.Count(); i++)
                {
                    Enemies[i].Dispose();
                    Enemies.Remove(Enemies[i]);
                    i--;
                }

        }


        private void SetPanStuff(string time)
        {
            if (Level == 1)
            {
                ScoreTimePan.Location = new Point(800, 300);
                ScoreTimePan.Size = new Size(200, 250);
                ScoreTimePan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                ScoreTimePan.BackColor = Color.Transparent;
                Time.Location = new Point(50, 50);
                Time.Font = new Font("murtuza", 20);
                Time.ForeColor = System.Drawing.Color.White;
                Time.Text = time;
                Time.Size = new Size(100, 40);
                Time.Location = new Point(55, 100);
                TScore.Location = new Point(55, 30);
                TScore.Font = new Font("murtuza", 15);
                TScore.ForeColor = System.Drawing.Color.White;
                TScore.Text = ("Score: " + IScore.ToString());
                TScore.Size = new Size(90, 50);
                StartStop.Location = new Point(45, 150);
                StartStop.Font = new Font("murtuza", 20);
                StartStop.ForeColor = System.Drawing.Color.White;
                StartStop.BackColor = Color.Black;
                StartStop.Text = "Start";
                StartStop.Size = new Size(100, 40);
                StartStop.Enabled = true;
                ScoreTimePan.Controls.Add(Time);
                ScoreTimePan.Controls.Add(TScore);
                ScoreTimePan.Controls.Add(StartStop);
                this.Controls.Add(ScoreTimePan);
                ScoreTimePan.Show();
                ScoreTimePan.SendToBack();
            }
            else
            {
                ScoreTimePan.Location = new Point(800, 300);
                ScoreTimePan.Size = new Size(200, 150);
                ScoreTimePan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                ScoreTimePan.BackColor = Color.Transparent;
                TScore.Location = new Point(55, 30);
                TScore.Font = new Font("murtuza", 15);
                TScore.ForeColor = System.Drawing.Color.White;
                TScore.Text = ("Score: " + IScore.ToString());
                TScore.Size = new Size(90, 50);
                StartStop.Location = new Point(45, 80);
                StartStop.Font = new Font("murtuza", 20);
                StartStop.ForeColor = System.Drawing.Color.White;
                StartStop.BackColor = Color.Black;
                StartStop.Text = "Start";
                StartStop.Size = new Size(100, 40);
                StartStop.Enabled = true;
                ScoreTimePan.Controls.Add(TScore);
                ScoreTimePan.Controls.Add(StartStop);
                this.Controls.Add(ScoreTimePan);
                ScoreTimePan.Show();
                ScoreTimePan.SendToBack();
            }
                
        }


        private string GetMaterialsDocSource()
        {
            string str = System.IO.Directory.GetCurrentDirectory();
            int FirstIndex = str.IndexOf("ShootingGame");
            string beginString = str.Substring(0, FirstIndex + "ShootingGame".Length);
            string result = beginString + @"\materials";
            for (int i = 0; i < result.Length; i++)
                if (result[i] == '\\' && result[i - 1] != '\\')
                    result = result.Insert(i, "\\");
            return result;
        }

        
        private void CenterWindow()
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }


        private void ShipSpawn(object sender, EventArgs e)
        {
            SpaceShip.SizeMode = PictureBoxSizeMode.StretchImage;
            SpaceShip.Size = new Size(100, 100);
            SpaceShip.Image = Image.FromFile(MaterialsDoc + @"\red\alienship_new_red_try.png");
            SpaceShip.Location = new Point(x_ship, y_ship);
            SpaceShip.BackColor = Color.Transparent;
            this.Controls.Add(SpaceShip);
        }


        private void StartStopGame(object sender, EventArgs e)
        {
            if (StartStop.Text == "Start")
            {
                StartStop.Text = "Pause";
                if (Level == 1)
                {
                    if (start)
                    {
                        EnemiesSpawner();
                        start = false;
                    }
                    IntersectionsDetecter.Start();
                    TimeWatcher.Start();
                    EnemiesMover.Start();
                    BulletChecker.Start();
                    ScoreTimePan.Click += new EventHandler(BulletMaker);
                    this.Click += new EventHandler(BulletMaker);
                    this.KeyDown += new KeyEventHandler(Level1_KeyDown);
                    this.ActiveControl = null;
                }
                else
                {
                    if (start)
                    {
                        EnemiesSpawner();
                        start = false;
                    }
                    IntersectionsDetecter.Start();
                    EnemiesMover.Start();
                    BulletChecker.Start();
                    ScoreTimePan.Click += new EventHandler(BulletMaker);
                    this.Click += new EventHandler(BulletMaker);
                    this.KeyDown += new KeyEventHandler(Level1_KeyDown);
                    this.ActiveControl = null;
                    RandomEnemyBullets.Start();
                    WinOrLose.Start();
                }
            }
            else
            {
                StartStop.Text = "Start";
               if (Level == 1)
                {
                    IntersectionsDetecter.Stop();
                    TimeWatcher.Stop();
                    EnemiesMover.Stop();
                    BulletChecker.Stop();
                    ScoreTimePan.Click -= new EventHandler(BulletMaker);
                    this.Click -= new EventHandler(BulletMaker);
                    this.KeyDown -= new KeyEventHandler(Level1_KeyDown);
                }
                else
                {
                    IntersectionsDetecter.Stop();
                    EnemiesMover.Stop();
                    BulletChecker.Stop();
                    ScoreTimePan.Click -= new EventHandler(BulletMaker);
                    this.Click -= new EventHandler(BulletMaker);
                    this.KeyDown -= new KeyEventHandler(Level1_KeyDown);
                    this.ActiveControl = null;
                    RandomEnemyBullets.Stop();
                    WinOrLose.Stop();
                }
            }
            
        }


        private void RandomEnemyBullets_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int n = 3;
            if (Enemies.Count() <= 3)
                n = 1;
                int num = rnd.Next(n, Enemies.Count());
            List<int> UsedNums = new List<int>();
            List<PictureBox> temp = new List<PictureBox>();
            for (int i = 0; i < num; i++)
            {
                PictureBox box = new PictureBox();
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.Size = new Size(50, 50);
                box.Image = Image.FromFile(MaterialsDoc + @"\red\Enemy_bullet_red.png");
                box.ImageLocation = MaterialsDoc + @"\red\Enemy_bullet_red.png";
                int t = rnd.Next(0, Enemies.Count());
                while (UsedNums.Contains(t))
                    t = rnd.Next(0, Enemies.Count());
                UsedNums.Add(t);
                box.Location = new Point(Enemies[t].Location.X + 22, Enemies[t].Location.Y - 30);
                box.BackColor = Color.Transparent;
                EnemiesBullets.Add(box);
                this.Controls.Add(box);
                box.BringToFront();
                BulletChecker.Start();
            }
        }



        private void TimeWatcher_Tick(object sender, EventArgs e)
        {
            if (Tmins == 0 && Tsecs == 0)
            {
                TimeWatcher.Stop();
                EnemiesMover.Stop();
                BulletChecker.Stop();
                IntersectionsDetecter.Stop();
                this.KeyDown -= new KeyEventHandler(Level1_KeyDown);
                StartStop.Text = "Start";
                Tsecs = 2;
                Tmins = 0;
                ClearCurrentWindow();
                if (IScore >= 3000)
                    GameResult("Winner");
                else
                    GameResult("Loser");
                return;
            }
            else if (Tmins >= 1 && Tsecs == 0)
            {
                Tmins--;
                Tsecs = 59;
            }
            else if (Tsecs > 0)
                Tsecs--;
            UpdateTime();

        }


        void GameResult(string result)
        {

            IntersectionsDetecter.Stop();
            TimeWatcher.Stop();
            EnemiesMover.Stop();
            RandomEnemyBullets.Stop();
            Form2 f = new Form2(result);
            f.Show();
        }


        private void UpdateTime()
        {
            if (Tsecs <= 10 && Tmins < 1)
                Time.ForeColor = System.Drawing.Color.Red;
            if (Tsecs < 10)
                Time.Text = (Tmins + " : 0" + Tsecs);
            else
                Time.Text = (Tmins + " : " + Tsecs);
        }


        private void EnemeiesSrcFiller()
        {
            string Tstr = MaterialsDoc + @"\red";
            string[] EnemiesSrc = { Tstr + @"\space_mine.png" , Tstr + @"\Communicationship2.png", Tstr + @"\space_bomb.png", Tstr + @"\Enemy_animation\spaceship_enemy_start.png"};
            for (int i = 0; i < 4; i++)
            {
                EnemiesPicsSrc[i] = EnemiesSrc[i];
            }
        }


        private void IntersectionsDetecter_Tick(object sender, EventArgs e)
        {
            int CEnemies = Enemies.Count();
            int CShipBullets = ShipBullets.Count();
            int CEnemiesBullets = EnemiesBullets.Count();
            for (int i = 0; i < CEnemies; i++)
                for (int j = 0; j < CShipBullets; j++)
                    if (CEnemies == 0 || CShipBullets == 0)
                        break;
                    else if(Enemies[i].Bounds.IntersectsWith(ShipBullets[j].Bounds))
                    {
                        ScoreUpdater(Enemies[i]);
                        Enemies[i].Dispose();
                        ShipBullets[j].Dispose();
                        Enemies.Remove(Enemies[i]);
                        ShipBullets.Remove(ShipBullets[j]);
                        SoundPlayer player = new SoundPlayer(MaterialsDoc + @"\Sound\Explosion.wav");
                        player.Play();
                        CEnemies--;
                        if (i - 1 >= 0)
                            i--;
                        if (j - 1 >= 0)
                            j--;
                        CShipBullets--;
                    }
            CEnemiesBullets = EnemiesBullets.Count();
            if (Level == 2)
            {
                for (int i = 0; i < CEnemiesBullets; i++)
                    for (int j = 0; j < CShipBullets; j++)
                    {
                        if (EnemiesBullets.Count() == 0 || CShipBullets == 0)
                            break;
                        if (EnemiesBullets[i].Bounds.IntersectsWith(ShipBullets[j].Bounds))
                        {
                            ScoreUpdater(EnemiesBullets[i]);
                            EnemiesBullets[i].Dispose();
                            ShipBullets[j].Dispose();
                            EnemiesBullets.Remove(EnemiesBullets[i]);
                            ShipBullets.Remove(ShipBullets[j]);
                            SoundPlayer player = new SoundPlayer(MaterialsDoc + @"\Sound\Explosion.wav");
                            player.Play();
                            CEnemiesBullets--;
                            if (i - 1 >= 0)
                                i--;
                            if (j - 1 >= 0)
                                j--;
                            CShipBullets--;
                        }
                    }  
                CEnemiesBullets = EnemiesBullets.Count();
                for (int i = 0; i < CEnemiesBullets; i++)
                {
                    if (EnemiesBullets[i].Bounds.IntersectsWith(SpaceShip.Bounds))
                    {
                        EnemiesMover.Stop();
                        BulletChecker.Stop();
                        IntersectionsDetecter.Stop();
                        RandomEnemyBullets.Stop();
                        WinOrLose.Stop();
                        GameResult("Loser");
                        break;
                    }
                }
            }
            if(Enemies.Count == 0 && Level == 1)
            {
                EnemiesPictureBoxesMaker();
                EnemiesSpawner();
            }
        }


        private void ScoreUpdater(PictureBox box)
        {
            if (box.ImageLocation == EnemiesPicsSrc[0])
            {
                IScore += 300;
            }
            else if (box.ImageLocation == EnemiesPicsSrc[1])
            {
                IScore += 200;
            }
            else if (box.ImageLocation == EnemiesPicsSrc[2])
            {
                IScore += 100;
            }
            else if (box.ImageLocation == EnemiesPicsSrc[3])
            {
                IScore += 400;
            }
            else if (box.ImageLocation == EnemiesBullets[0].ImageLocation)
            {
                IScore += 100;
            }
            TScore.Text = ("Score: " + IScore.ToString());
        }

        private void WinOrLose_Tick(object sender, EventArgs e)
        {
            if(Enemies.Count == 0)
            {
                GameResult("Winner");
                WinOrLose.Stop();
            }
        }


        private void EnemiesPictureBoxesMaker()
        {
            if(Level == 1)
            {
                for(int i = 0; i < 3; i++)
                {
                    Enemies.Add(new PictureBox());
                    Enemies[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    Enemies[i].Size = new Size(100, 100);
                    Enemies[i].Image = Image.FromFile(EnemiesPicsSrc[i]);
                    Enemies[i].BackColor = Color.Transparent;
                    Enemies[i].ImageLocation = EnemiesPicsSrc[i];
                    Enemies[i].Click += new EventHandler(BulletMaker);
                }
            }
            else
            {
                Random rnd = new Random();
                for (int i = 0; i < rnd.Next(3, 10); i++)
                {
                    Enemies.Add(new PictureBox());
                    Enemies[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    Enemies[i].Size = new Size(100, 100);
                    Enemies[i].Image = Image.FromFile(EnemiesPicsSrc[3]);
                    Enemies[i].BackColor = Color.Transparent;
                    Enemies[i].ImageLocation = EnemiesPicsSrc[3];
                    Enemies[i].Click += new EventHandler(BulletMaker);
                }
            }
        }


        private void EnemiesSpawner()
        {
            if(Level == 1)
            {
                Random rnd = new Random();
                for (int i = 0; i < 3; i++)
                {
                    Enemies[i].Location = new Point(x_enemy, y_enemy);
                    this.Controls.Add(Enemies[i]);
                    x_enemy += rnd.Next(150, 400);
                }
                if (Enemies[2].Location.X > -200)
                {
                    int n = Enemies[2].Location.X + 200;
                    foreach (PictureBox box in Enemies)
                        box.Location = new Point(box.Location.X - n, y_enemy);
                }
                foreach (PictureBox box in Enemies)
                    this.Controls.Add(box);
                EnemiesMover.Start();
            }
            else
            {
                int[] x = { 100, 400, 700 , 250, 550, 850, 50, 350, 650};
                int y = 20;
                for(int i = 0; i < Enemies.Count(); i++)
                {
                    Enemies[i].Location = new Point(x[i] , y);
                    if (i == 2 || i == 5)
                        y += 110;
                }
                foreach (PictureBox box in Enemies)
                    this.Controls.Add(box);
                EnemiesMover.Start();

            }

        }


        private void EnemiesMover_Tick(object sender, EventArgs e)
        {
            if(Level == 1)
            {
                int S = Enemies.Count();
                for (int i = 0; i < S; i++)
                {
                    if ((Enemies[0].Location.X + 20) >= 1100)
                    {
                        for (int j = 0; j < S; j++)
                        {
                            Enemies[j].Dispose();
                            Enemies.Remove(Enemies[j]);
                            S--; j--;
                        }

                        EnemiesMover.Stop();
                        EnemiesPictureBoxesMaker();
                        EnemiesSpawner();
                        x_enemy = -600;
                        break;
                    }
                    Enemies[i].Location = new Point(Enemies[i].Location.X + 20, Enemies[i].Location.Y);
                }
            }
            else
            {
                int S = Enemies.Count();
                bool warning = false;
                List<int> higher = new List<int>();
                List<int> lower = new List<int>();
                for (int i = 0; i < S; i++)
                {
                    if (Enemies[i].Location.X + Flip > 900 || Enemies[i].Location.X + Flip < -10)
                        warning = true;
                }

                if (warning)
                    Flip *= -1;
                else if (lower.Count == 0 && higher.Count == 0)
                {
                    foreach (PictureBox box in Enemies)
                        box.Location = new Point(box.Location.X + Flip, box.Location.Y);
                }
            }
           
        }


        private void BulletMaker(object sender, EventArgs e)
        {
            BulletChecker.Start();
            PictureBox box = new PictureBox();
            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.Size = new Size(50, 50);
            box.Image = Image.FromFile(MaterialsDoc + @"\red\bullet_red.png");
            box.Location = new Point(SpaceShip.Location.X + 22, SpaceShip.Location.Y - 30);
            box.BackColor = Color.Transparent;
            ShipBullets.Add(box);
            this.Controls.Add(box);
            box.BringToFront();
            SoundPlayer player = new SoundPlayer(MaterialsDoc + @"\Sound\LaserBeam.wav");
            player.Play();
        }


        private void BulletChecker_Tick(object sender, EventArgs e)
        {
            int Size = ShipBullets.Count();
            for (int i = 0; i < Size; i++)
                if ((ShipBullets[i].Location.Y - 50) >= -10)
                {
                    if (ShipBullets.Count != 0)
                        ShipBullets[i].Location = new Point(ShipBullets[i].Location.X, ShipBullets[i].Location.Y - 50);
                }
                else
                {
                    ShipBullets[i].Dispose();
                    ShipBullets.Remove(ShipBullets[i]);
                    x_enemy = -500;
                    Size--;
                }

            int Size1 = EnemiesBullets.Count();
            for (int i = 0; i < Size1; i++)
                if ((EnemiesBullets[i].Location.Y - 50) <= 900)
                {
                    if (EnemiesBullets.Count != 0)
                        EnemiesBullets[i].Location = new Point(EnemiesBullets[i].Location.X, EnemiesBullets[i].Location.Y + 50);
                }
                else
                {
                    EnemiesBullets[i].Dispose();
                    EnemiesBullets.Remove(EnemiesBullets[i]);
                    Size1--;
                }
        }


        private void MouseClickSound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(MaterialsDoc + @"\Sound\mouse.wav");
            player.Play();
        }


        private void Level1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    if (K == Keys.Right)
                        speed = 5;
                    K = Keys.Left;
                    if((x_ship - speed) >= 0)
                        x_ship -= speed;
                    SpaceShip.Location = new Point(x_ship, y_ship);
                    if((speed + 1) <= 20)
                        speed++;
                    break;
                case Keys.Right:
                    if (K == Keys.Left)
                        speed = 5;
                    K = Keys.Right;
                    if ((x_ship + speed) <= 900)
                        x_ship += speed;
                    SpaceShip.Location = new Point(x_ship, y_ship);
                    if ((speed + 1) <= 20)
                        speed++;
                    break;
            }

        }
    }
}
