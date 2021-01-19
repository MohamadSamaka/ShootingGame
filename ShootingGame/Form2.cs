using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class Form2 : Form
    {
        string Result;
        public Form2(string result)
        {
            InitializeComponent();
            Result = result;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetResultLabel();
        }

        private void SetResultLabel()
        {
            if (Result == "Winner")
                GameResult.ForeColor = System.Drawing.Color.Green;
            else
                GameResult.ForeColor = System.Drawing.Color.Red;
            GameResult.Font = new Font("murtuza", 20);
            GameResult.Text = Result;
        }

        private void GoToMenu_Click(object sender, EventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).Reset();
            (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).ScoreTimePan.Hide();
            this.Close();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            var F = System.Windows.Forms.Application.OpenForms["Form1"] as Form1;
            F.ScoreTimePan.Hide();
            F.Reset();
            switch (F.Level)
            {
                case 1:
                    F.Level1.PerformClick();
                    break;
                case 2:
                    F.Level2.PerformClick();
                    break;
            }
            this.Close();
        }
    }
}
