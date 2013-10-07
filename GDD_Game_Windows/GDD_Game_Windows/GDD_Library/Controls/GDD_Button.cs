using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDD_Library.Controls
{
    public partial class GDD_Button: UserControl
    {
        public GDD_Button()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.BorderWidth = 2f;
           
        }

        /// <summary>
        /// The Width of the border around the button
        /// </summary>
        public float BorderWidth { get; set; }

        /// <summary>
        /// The text to display on the border
        /// </summary>
        public override String Text { get { return _Text; } set { _Text = value; } }
        private String _Text = "";

        /// <summary>
        /// We're going to paint this!
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Creating a bitmap
            Bitmap b = new Bitmap(this.Width, this.Height);

            //Creating graphics
            Graphics g = Graphics.FromImage(b);

            //Drawing the rectangle and border
            g.FillRectangle(new SolidBrush(this.BackColor), BorderWidth / 2, BorderWidth / 2, this.Width - BorderWidth, this.Height - BorderWidth);
            if (this.BorderWidth > 0)
            {
                g.DrawRectangle(new Pen(new SolidBrush(this.ForeColor), this.BorderWidth), BorderWidth / 2, BorderWidth / 2, this.Width - BorderWidth, this.Height - BorderWidth);
            }

            //Drawing the text
            SizeF size = g.MeasureString(this.Text, this.Font);
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF((this.Width - size.Width)/2f, (this.Height - size.Height)/ 2f));

            //Creating own graphics
            Graphics g2 = this.CreateGraphics();

            //Drawing the bitmap onto us
            g2.DrawImage(b, new Point(0, 0));

            g.Dispose();
            g2.Dispose();
            b.Dispose();

        }
    }
}
