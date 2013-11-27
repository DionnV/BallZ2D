using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDD_Game_Windows
{
    public partial class FormScore : Form
    {
        public FormScore()
        {
            InitializeComponent();
            Button_Back.Text = "Back";
        }

        public void SetScores(int score, int highscore)
        {
            label_Highscore.Text = "Highscore: " + highscore.ToString();
            label_Score.Text = "Score: " + score.ToString();
        }

        private void Button_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
