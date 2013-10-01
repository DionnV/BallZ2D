using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Square : GDD_Shape, ISerializable
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

            /*G.FillPolygon(new SolidBrush(Color.Brown), new Point[] { 
                p1.ToPoint().Offset(Owner.Location.ToPoint()), 
                p2.ToPoint().Offset(Owner.Location.ToPoint()), 
                p3.ToPoint(), p4.ToPoint() });
            */

            PointF[] p = new PointF[4];
            p[0] = new PointF(Owner.Location.x + p1.x, Owner.Location.y + p1.y);
            p[1] = new PointF(Owner.Location.x + p2.x, Owner.Location.y + p2.y);
            p[2] = new PointF(Owner.Location.x + p3.x, Owner.Location.y + p3.y);
            p[3] = new PointF(Owner.Location.x + p4.x, Owner.Location.y + p4.y);

            //Drawing the box
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p1.x, Owner.Location.y + p1.y, Owner.Location.x + p2.x, Owner.Location.y + p2.y);
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p2.x, Owner.Location.y + p2.y, Owner.Location.x + p3.x, Owner.Location.y + p3.y);
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p3.x, Owner.Location.y + p3.y, Owner.Location.x + p4.x, Owner.Location.y + p4.y);
            G.DrawLine(Owner.FrontPen, Owner.Location.x + p4.x, Owner.Location.y + p4.y, Owner.Location.x + p1.x, Owner.Location.y + p1.y);

            //G.DrawLines(Owner.FrontPen, new Point[{ p1.T,p2,p3,p4});

            G.FillPolygon(new SolidBrush(Color.Brown), p);

            //Calculating the end point for our direction line
            GDD_Point2F end = new GDD_Point2F(Math.Sin(Rotation * Rad2Deg) * (0.5f * Size), Math.Cos(Rotation * Rad2Deg) * (0.5f * Size));

            //Drawing a line to get its rotation better
            //G.DrawLine(Owner.FrontPen, Owner.Location.x, Owner.Location.y, Owner.Location.x + end.x, Owner.Location.y + end.y);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
        }

        public GDD_Square(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
        }

        public GDD_Square() { }

    }
}
