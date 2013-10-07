using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Line : GDD_Shape, ISerializable
    {
        /// <summary>
        /// The end of the line
        /// </summary>
        public GDD_Point2F end
        {
            get
            {
                //Calculating the end, relative to the line
                GDD_Point2F end = new GDD_Vector2F(Owner.Rotation.Direction, this.Size).ToDXDY();

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
            GDD_Vector2F vector = new GDD_Point2F(Start.x - End.x, Start.y - End.y).ToVector();

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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
        }

        public GDD_Line(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
        }

        public GDD_Line()
        {
        }

        public override bool Contains(GDD_Point2F p)
        {
            return false;
        }

        public GDD_Point2F toFunction()
        {
            //Rotation
            float rot = GDD_Math.Angle(Owner.Rotation.Direction);

            GDD_Point2F result;

            float dx;
            float dy;
            //Calulating the default slope
            if (Owner.Rotation.Direction > 180f)
            {
                dx = Owner.Location.x - end.x;
                dy = Owner.Location.y - end.y;
            }
            else
            {
                dx = end.x - Owner.Location.x;
                dy = end.y - Owner.Location.y;
            }
            float dxdy = dy / dx;


            //Getting the slope
            if (rot == 90f)
            {
                result = GDD_Math.DXDYToFunc(0, Owner.Location);
            }
            else if (rot == 270f)
            {
                result = GDD_Math.DXDYToFunc(0, Owner.Location);
            }
            else if (rot == 180f)
            {
                result = GDD_Math.DXDYToFunc(-1000, Owner.Location);
            }
            else if (rot == 0f)
            {
                result = GDD_Math.DXDYToFunc(1000, Owner.Location);
            }
            else
            {
                result = GDD_Math.DXDYToFunc(dxdy, Owner.Location);
            }

            return result;
        }
    }
}
