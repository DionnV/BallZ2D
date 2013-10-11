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
    public partial class LevelInfo : Form
    {
        public LevelInfo()
        {
            InitializeComponent();
            Button_OK.Text = "OK";
            Button_Cancel.Text = "Cancel";
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
