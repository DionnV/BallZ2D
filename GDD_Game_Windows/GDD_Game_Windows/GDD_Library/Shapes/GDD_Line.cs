using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.Shapes
{
    public class GDD_Line : GDD_Shape
    {
        /// <summary>
        /// The end of the line
        /// </summary>
        public GDD_Point2F end = new GDD_Point2F(0f, 0f);


        public override void Draw(Graphics G)
        {


            float x_start = Owner.Location.x;
            float y_start = Owner.Location.y;
            //float x_end = x_start + (float)(Owner.Shape.Size * Math.Sin(Owner.Rotation.Direction * GDD_Math.RadConverter));
            end = GDD_Math.VectorToDXDY(new GDD_Vector2F(Owner.Rotation.Direction, this.Size)) ;
            end = new GDD_Point2F(end.x + x_start, end.y + y_start);

            //Drawing a line given two points
            G.DrawLine(Owner.FrontPen, x_start, y_start, end.x, end.y);
        }

        /// <summary>
        /// The type of the line
        /// </summary>
        public enum LineType
        {
            Straight,
            Loose
        }
    }
}
