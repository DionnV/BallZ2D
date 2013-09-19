using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.Shapes
{   
    public class GDD_Square: GDD_Shape
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
            float LongSize = (float)(Math.Sqrt(2d) * (this.Size * 0.5f));
            float Rotation = -Owner.Rotation.Direction + 180f;

            //Calculating 4 corners to start drawing from
            GDD_Point2F p1 = new GDD_Point2F(Math.Sin((Rotation + 45f) * Rad2Deg) * LongSize, Math.Cos((Rotation + 45f) * Rad2Deg) * LongSize);
            GDD_Point2F p2 = new GDD_Point2F(Math.Sin((Rotation + 135f) * Rad2Deg) * LongSize, Math.Cos((Rotation + 135f) * Rad2Deg) * LongSize);
            GDD_Point2F p3 = new GDD_Point2F(Math.Sin((Rotation + 225f) * Rad2Deg) * LongSize, Math.Cos((Rotation + 225f) * Rad2Deg) * LongSize);
            GDD_Point2F p4 = new GDD_Point2F(Math.Sin((Rotation - 45f) * Rad2Deg) * LongSize, Math.Cos((Rotation - 45f) * Rad2Deg) * LongSize);

            //Drawing the box
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p1.x, Owner.Location.y + p1.y, Owner.Location.x + p2.x, Owner.Location.y + p2.y);
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p2.x, Owner.Location.y + p2.y, Owner.Location.x + p3.x, Owner.Location.y + p3.y);
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p3.x, Owner.Location.y + p3.y, Owner.Location.x + p4.x, Owner.Location.y + p4.y);
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p4.x, Owner.Location.y + p4.y, Owner.Location.x + p1.x, Owner.Location.y + p1.y);

            //Calculating the end point for our direction line
            GDD_Point2F end = new GDD_Point2F(Math.Sin(Rotation * Rad2Deg) * (0.5f * Size), Math.Cos(Rotation * Rad2Deg) * (0.5f * Size));

            //Drawing a line to get its rotation better
            G.DrawLine(Owner.FrontPen, Owner.Location.x, Owner.Location.y, Owner.Location.x + end.x, Owner.Location.y + end.y);
        }


    }
}
