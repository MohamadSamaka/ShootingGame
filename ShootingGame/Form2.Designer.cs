
namespace ShootingGame
{
    partial class Form2
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
            this.GoToMenu = new System.Windows.Forms.Button();
            this.PlayAgain = new System.Windows.Forms.Button();
            this.GameResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GoToMenu
            // 
            this.GoToMenu.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToMenu.Location = new System.Drawing.Point(286, 149);
            this.GoToMenu.Name = "GoToMenu";
            this.GoToMenu.Size = new System.Drawing.Size(146, 42);
            this.GoToMenu.TabIndex = 5;
            this.GoToMenu.Text = "Go to menu";
            this.GoToMenu.UseVisualStyleBackColor = true;
            this.GoToMenu.Click += new System.EventHandler(this.GoToMenu_Click);
            // 
            // PlayAgain
            // 
            this.PlayAgain.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayAgain.Location = new System.Drawing.Point(34, 149);
            this.PlayAgain.Name = "PlayAgain";
            this.PlayAgain.Size = new System.Drawing.Size(146, 42);
            this.PlayAgain.TabIndex = 4;
            this.PlayAgain.Text = "Play Again";
            this.PlayAgain.UseVisualStyleBackColor = true;
            this.PlayAgain.Click += new System.EventHandler(this.PlayAgain_Click);
            // 
            // GameResult
            // 
            this.GameResult.AutoSize = true;
            this.GameResult.Location = new System.Drawing.Point(197, 68);
            this.GameResult.Name = "GameResult";
            this.GameResult.Size = new System.Drawing.Size(0, 13);
            this.GameResult.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 258);
            this.Controls.Add(this.GoToMenu);
            this.Controls.Add(this.PlayAgain);
            this.Controls.Add(this.GameResult);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoToMenu;
        private System.Windows.Forms.Button PlayAgain;
        private System.Windows.Forms.Label GameResult;
    }
}