using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.Shapes
{   
    public class GDD_Circle: GDD_Shape
    {
        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        {
            //Drawing a square
            //G.DrawRectangle(Owner.FrontPen, Owner.Location.x - (this.Size / 2), Owner.Location.y - (this.Size / 2), this.Size, this.Size);
            
            //A few constants that we calculate with
            float Rad2Deg = 0.0174532925f;
            float LongSize = (float)(Math.Sqrt(2d) * this.Size);
            float Rotation = -Owner.Rotation.Direction + 180f;

            G.DrawEllipse(Owner.FrontPen, Owner.Location.x - Size/2f, Owner.Location.y - Size/2f, Size, Size);

            //Calculating the end point for our direction line
            GDD_Point2F end = new GDD_Point2F(Math.Sin(Rotation * Rad2Deg) * this.Size/2f, Math.Cos(Rotation * Rad2Deg) * Size/2f);

            //Drawing a line to get its rotation better
            G.DrawLine(Owner.FrontPen, Owner.Location.x, Owner.Location.y, Owner.Location.x + end.x, Owner.Location.y + end.y);
        }

        /// <summary>
        /// The bounce rate, 0.8 default
        /// </summary>
        public float RestitutionRate { get { return this._RestitutionRate; } set { _RestitutionRate = value;  } }
        private float _RestitutionRate = 0.6f;
    }
}
