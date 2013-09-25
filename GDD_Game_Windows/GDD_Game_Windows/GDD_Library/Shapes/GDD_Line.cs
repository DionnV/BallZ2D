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
        public GDD_Point2F end
        {
            get
            {
                //Calculating the end, relative to the line
                GDD_Point2F end = GDD_Math.VectorToDXDY(new GDD_Vector2F(Owner.Rotation.Direction, this.Size));

                //Moving the end 
                end = new GDD_Point2F(end.x + this.Owner.Location.x, end.y + this.Owner.Location.y);

                //Returning
                return end;
            }
        }

        public override void Draw(Graphics G)
        {
            //Drawing a line given two points
            G.DrawLine(Owner.FrontPen, Owner.Location.x, Owner.Location.y, end.x, end.y);
        }

        public static GDD_Object Create(GDD_Point2F Start, GDD_Point2F End)
        {
            //Calculating a vector
            GDD_Vector2F vector = GDD_Math.DXDYToVector(new GDD_Point2F(Start.x - End.x, Start.y - End.y));

            //Filling in the info
            GDD_Object obj = new GDD_Object(new GDD_Line());
            obj.Location = Start;
            obj.Mass = 1f;
            obj.GravityType = GDD_GravityType.Static;
            obj.Velocity_Vector = new GDD_Vector2F(0f, 0f);
            obj.Rotation = new GDD_Vector2F(vector.Direction + 180f, 0f);
            obj.Shape.Size = vector.Size;

            return obj;
        }
    }
}
