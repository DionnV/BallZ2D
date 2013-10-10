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
    ///<summary>
    ///This class will create a self-made button. These buttons can contain notes in the left-upper corner. 
    /// </summary>
    public partial class GDD_Button: UserControl, ICloneable
    {
        /// <summary>
        /// Constructor to create a new GDD_Button object.
        /// </summary>
        public GDD_Button()
        {
            InitializeComponent();

            //Default BackColor is White
            this.BackColor = Color.White;

            //Default ForeColor is Black
            this.ForeColor = Color.Black;

            //Default BorderWidth is 2f.
            this.BorderWidth = 2f;
           
        }

        /// <summary>
        /// This method will create a clone and return it.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return (GDD_Button)this.MemberwiseClone();
        }

        /// <summary>
        /// The Width of the border around the button
        /// </summary>
        [Browsable(true)]
        public float BorderWidth { get; set; }

        /// <summary>
        /// The text to display on the button
        /// </summary>
        [Browsable(true)]
        public override String Text { 
            get { return _Text; } 
            set { _Text = value; } }
        private String _Text;

        /// <summary>
        /// The note to be written on the button
        /// </summary>
        [Browsable(true)]
        public  String Note { 
             get { return _Note; } 
             set { _Note = value; } }
        private String _Note;

        /// <summary>
        /// Returns whether the button is selected.
        /// </summary>
        public bool IsSelected { 
            get { return _IsSelected; } 
            set { _IsSelected = value; } }
        private bool _IsSelected;

        /// <summary>
        /// This method will paint the Button.
        /// </summary>
        /// <param name="pevent">The PaintEventArgs.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Creating a bitmap
            Bitmap b = new Bitmap(this.Width, this.Height);

            //Creating graphics
            Graphics g = Graphics.FromImage(b);

            //Drawing the rectangle and border
            g.FillRectangle(new SolidBrush(this.BackColor), (BorderWidth / 2) + Padding.Left, (BorderWidth / 2) + Padding.Top, (this.Width - BorderWidth) - (Padding.Left + Padding.Right), (this.Height - BorderWidth) - (Padding.Bottom + Padding.Top));

            //Drawing an image
            if (this.BackgroundImage != null)
            {
                //Drawing a stretched image
                g.DrawImage(
                    this.BackgroundImage,     
                    new RectangleF((BorderWidth / 2) + Padding.Left, (BorderWidth / 2) + Padding.Top, (this.Width - BorderWidth) - (Padding.Left + Padding.Right), (this.Height - BorderWidth) - (Padding.Bottom + Padding.Top)),
                    new RectangleF(0, 0, BackgroundImage.Width, BackgroundImage.Height),
                    GraphicsUnit.Pixel);
            }

            //Drawing the border
            if (BorderWidth > 0)
            {
                g.DrawRectangle(new Pen(this.ForeColor, BorderWidth), (BorderWidth / 2) + Padding.Left, (BorderWidth / 2) + Padding.Top, (this.Width - BorderWidth) - (Padding.Left + Padding.Right), (this.Height - BorderWidth) - (Padding.Bottom + Padding.Top));

            }

            //Drawing the text
            SizeF size = g.MeasureString(this.Text, this.Font);
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF((this.Width - size.Width)/2f, (this.Height - size.Height)/ 2f));

            //Drawing note
            if (Note != "" && Note != null)
            {
                //Creating a new font
                Font NoteFont = new System.Drawing.Font(this.Font.FontFamily, this.FontHeight - 8);

                //Messuring the note
                size = g.MeasureString(this.Note, this.Font);

                //Drawing a rectangle
                g.FillRectangle(new SolidBrush(this.BackColor), this.Width - (size.Width + 20), 0, size.Width + 19, size.Height + 10);
                g.DrawRectangle(new Pen(ForeColor, 1f), this.Width - (size.Width + 20), 0, size.Width + 19, size.Height + 10);

                //Drawing the note.
                g.DrawString(this.Note, NoteFont, new SolidBrush(Color.Red), this.Width - (size.Width + 10), 5);

            }

            //Creating own graphics
            Graphics g2 = this.CreateGraphics();

            //Drawing the bitmap onto us
            g2.DrawImage(b, new Point(0, 0));

            //Dispose the graphics.
            g.Dispose();
            g2.Dispose();
            b.Dispose();
        }
    }
}
