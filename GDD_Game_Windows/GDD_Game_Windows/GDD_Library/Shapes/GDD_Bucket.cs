using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Bucket : GDD_Shape, ISerializable
    {
        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        {
            //A few constants that we calculate with
            float LongSize = (float)(Math.Sqrt(2d) * (this.Size * 0.5f));
            float Rotation = -Owner.Rotation.Direction + 180f;

            //GDD_Vector2F vec = new GDD_Vector2F(
            GDD_Point2F dxdy = GDD_Math.VectorToDXDY(new GDD_Vector2F(10f + Rotation, this.Size));

            //DefinedPoints for a bucket of size 100
            float sizeFactor = this.Size / 100f;

            //All the points that are needed to draw this
            /*GDD_Point2F[] p = new GDD_Point2F[8];
            p[0] = new GDD_Point2F(-50f, -36f);
            p[1] = new GDD_Point2F(-40f, -36f);
            p[2] = new GDD_Point2F(-27f, 40f);
            p[3] = new GDD_Point2F(27f, 40f);
            p[4] = new GDD_Point2F(40f, -36f);
            p[5] = new GDD_Point2F(50f, -36f);
            p[6] = new GDD_Point2F(35f, 50f);
            p[7] = new GDD_Point2F(-35f, 50f);

            //A vector for translating the points
            GDD_Vector2F v;
            int cnt = p.Count();*/

            GDD_Vector2F[] v = new GDD_Vector2F[8];
            GDD_Point2F[] p = new GDD_Point2F[8];
            PointF[] p2 = new PointF[8];
            v[0] = new GDD_Vector2F(350.7539f, 61.61169f);
            v[1] = new GDD_Vector2F(356.872f, 53.8145f);
            v[2] = new GDD_Vector2F(259.0193f, 48.25971f);
            v[3] = new GDD_Vector2F(190.9807f, 48.25971f);
            v[4] = new GDD_Vector2F(93.01279f, 53.8145f);
            v[5] = new GDD_Vector2F(99.24611f, 61.61169f);
            v[6] = new GDD_Vector2F(190.008f, 61.03278f);
            v[7] = new GDD_Vector2F(259.992f, 61.03278f);

            //The count of v
            int cnt = v.Count();
            GDD_Vector2F vec;

            //Translating the points
            for (int i = 0; i < cnt; i++)
            {
                vec = v[i];
                vec = new GDD_Vector2F(vec.Direction + (this.Owner.Rotation.Direction - 45f), vec.Size * sizeFactor);
                p[i] = GDD_Math.VectorToDXDY(vec);
                p2[i] = new PointF(Owner.Location.x + p[i].x, Owner.Location.y + p[i].y);
            }

            //Filling the bucket with a green color, ( yay )
            G.FillPolygon(new SolidBrush(Color.Green), p2);

            //Drawing a border around the already displaying bucket
            for (int i = 0; i < cnt; i++)
            {
                //Drawing the line
                G.DrawLine(Owner.FrontPen, Owner.Location.x + p[i].x, Owner.Location.y + p[i].y, Owner.Location.x + p[(i + 1) % cnt].x, Owner.Location.y + p[(i + 1) % cnt].y);
            }            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
        }

        public GDD_Bucket(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
        }

        public GDD_Bucket() { }
    }
}
