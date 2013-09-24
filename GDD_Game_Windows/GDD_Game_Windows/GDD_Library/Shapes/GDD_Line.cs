using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.Shapes
{
    public class GDD_Line : GDD_Shape
    {


        public override void Draw(Graphics G)
        {
            float x_start = Owner.Location.x;
            float y_start = Owner.Location.y;
            float x_end = x_start + (float)(Owner.Shape.Size * Math.Sin(Owner.Rotation.Direction * GDD_Math.RadConverter));
            float y_end = y_start + (float)(Owner.Shape.Size * Math.Cos(Owner.Rotation.Direction * GDD_Math.RadConverter));

            //Drawing a line given two points
            G.DrawLine(Owner.FrontPen, x_start, y_start, x_end, y_end);
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
