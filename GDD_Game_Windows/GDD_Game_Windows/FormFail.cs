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
    public partial class FormFail : FormScore
    {
        public FormFail()
        {
            InitializeComponent();

            this.Button_Back.Text = "Retry";
            this.label_Status.Text = "You died";
            this.label_Score.Visible = false;
            this.label_Highscore.Visible = false;

            this.Button_Back.Click += Button_Back_Click;
        }


        void Button_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
