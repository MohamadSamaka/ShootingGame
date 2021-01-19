
namespace ShootingGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LevelMenu = new System.Windows.Forms.Panel();
            this.Level2 = new System.Windows.Forms.Button();
            this.Level1 = new System.Windows.Forms.Button();
            this.ModeTile = new System.Windows.Forms.Label();
            this.BulletChecker = new System.Windows.Forms.Timer(this.components);
            this.EnemiesMover = new System.Windows.Forms.Timer(this.components);
            this.IntersectionsDetecter = new System.Windows.Forms.Timer(this.components);
            this.TimeWatcher = new System.Windows.Forms.Timer(this.components);
            this.RandomEnemyBullets = new System.Windows.Forms.Timer(this.components);
            this.WinOrLose = new System.Windows.Forms.Timer(this.components);
            this.LevelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LevelMenu
            // 
            this.LevelMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LevelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LevelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LevelMenu.Controls.Add(this.Level2);
            this.LevelMenu.Controls.Add(this.Level1);
            this.LevelMenu.Controls.Add(this.ModeTile);
            this.LevelMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LevelMenu.Location = new System.Drawing.Point(-2, -1);
            this.LevelMenu.Name = "LevelMenu";
            this.LevelMenu.Size = new System.Drawing.Size(374, 375);
            this.LevelMenu.TabIndex = 1;
            this.LevelMenu.AutoSizeChanged += new System.EventHandler(this.LevelMen);
            // 
            // Level2
            // 
            this.Level2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Level2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Level2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level2.ForeColor = System.Drawing.Color.Red;
            this.Level2.Location = new System.Drawing.Point(125, 202);
            this.Level2.Name = "Level2";
            this.Level2.Size = new System.Drawing.Size(97, 56);
            this.Level2.TabIndex = 3;
            this.Level2.Text = "Level 2";
            this.Level2.UseVisualStyleBackColor = false;
            this.Level2.Click += new System.EventHandler(this.LevelMen);
            // 
            // Level1
            // 
            this.Level1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Level1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Level1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Level1.Location = new System.Drawing.Point(125, 128);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(97, 56);
            this.Level1.TabIndex = 1;
            this.Level1.Text = "Level 1";
            this.Level1.UseVisualStyleBackColor = false;
            this.Level1.Click += new System.EventHandler(this.LevelMen);
            // 
            // ModeTile
            // 
            this.ModeTile.AutoSize = true;
            this.ModeTile.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ModeTile.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeTile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ModeTile.Location = new System.Drawing.Point(57, 67);
            this.ModeTile.Name = "ModeTile";
            this.ModeTile.Size = new System.Drawing.Size(239, 28);
            this.ModeTile.TabIndex = 0;
            this.ModeTile.Text = "Choose the diffculity:";
            // 
            // BulletChecker
            // 
            this.BulletChecker.Interval = 30;
            this.BulletChecker.Tick += new System.EventHandler(this.BulletChecker_Tick);
            // 
            // EnemiesMover
            // 
            this.EnemiesMover.Tick += new System.EventHandler(this.EnemiesMover_Tick);
            // 
            // IntersectionsDetecter
            // 
            this.IntersectionsDetecter.Interval = 10;
            this.IntersectionsDetecter.Tick += new System.EventHandler(this.IntersectionsDetecter_Tick);
            // 
            // TimeWatcher
            // 
            this.TimeWatcher.Interval = 1000;
            this.TimeWatcher.Tick += new System.EventHandler(this.TimeWatcher_Tick);
            // 
            // RandomEnemyBullets
            // 
            this.RandomEnemyBullets.Interval = 5000;
            this.RandomEnemyBullets.Tick += new System.EventHandler(this.RandomEnemyBullets_Tick);
            // 
            // WinOrLose
            // 
            this.WinOrLose.Tick += new System.EventHandler(this.WinOrLose_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 369);
            this.Controls.Add(this.LevelMenu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LevelMenu.ResumeLayout(false);
            this.LevelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LevelMenu;
        public System.Windows.Forms.Button Level2;
        private System.Windows.Forms.Label ModeTile;
        private System.Windows.Forms.Timer BulletChecker;
        private System.Windows.Forms.Timer EnemiesMover;
        private System.Windows.Forms.Timer IntersectionsDetecter;
        private System.Windows.Forms.Timer TimeWatcher;
        public System.Windows.Forms.Button Level1;
        private System.Windows.Forms.Timer RandomEnemyBullets;
        private System.Windows.Forms.Timer WinOrLose;
    }
}

