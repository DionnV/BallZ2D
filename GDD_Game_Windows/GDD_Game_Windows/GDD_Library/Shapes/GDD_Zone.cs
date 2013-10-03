using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Zone : GDD_Polygon
    {
        /// <summary>
        /// The type of the zone
        /// </summary>
        public GDD_ZoneType ZoneType { get; set; }

        /// <summary>
        /// An array of the BorderEdge Shape
        /// </summary>
        protected GDD_Polygon EdgeShape { get; set; }

        /// <summary>
        /// Creates a new instance of zone
        /// </summary>
        public GDD_Zone() 
        {
            EdgeShape = new GDD_Polygon();
            EdgeShape.PolygonPoints = new GDD_Point2F[4];
            EdgeShape.PolygonPoints[0] = new GDD_Point2F(0f, 0f);
            EdgeShape.PolygonPoints[1] = new GDD_Point2F(100f, 100f);
            EdgeShape.PolygonPoints[2] = new GDD_Point2F(200f, 100f);
            EdgeShape.PolygonPoints[3] = new GDD_Point2F(100f, 0f);
        }

        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        {
            //Size represents the size of the border
            float SizeFactor = Size / 100f;
            
            //Getting the lines for the polygon
            GDD_Object[] Lines = TranslatePolygon_ToLines();

            //Using 
            using (var polygonPath = new GraphicsPath())
            {
                //Looping each line
                foreach (GDD_Object line in Lines)
                {
                    GDD_Vector2F vec = new GDD_Vector2F(line.Rotation.Direction, 200f * SizeFactor);
                    GDD_Point2F dxdy = vec.ToDXDY();



                    //Making sure we got the right brush
                    GDD_Vector2F vec1 = new GDD_Vector2F(line.Rotation.Direction + 90f, 100f * SizeFactor);
                    GDD_Point2F dxdy1 = vec1.ToDXDY();
                    /*
                    //Adding the shape to the path
                    polygonPath.AddPolygon(shape);*/

                    //Using a new brush
                   /* using (var brush = new LinearGradientBrush(new PointF(0, 0), dxdy1.ToPoint(), Owner.FrontColor, Color.LightGray))
                    {
                        //Looping multiple times
                        for (int i = 0; Math.Abs((float)i * dxdy.x) < line.Shape.Size; i++)
                        {
                            //Transformin g the points
                            PointF[] shape = EdgeShape.TranslatePolygonPoints(line.Rotation.Direction, SizeFactor, new GDD_Point2F(line.Location.x + (i * dxdy.x), line.Location.y + (i * -dxdy.y)));


                            //G.FillPolygon(brush, shape);
                        }
                    }*/

                    //line.Shape.Draw(G);
                    


                }
            }

            //Draws the shape using the poligon data
            G.DrawPolygon(Owner.FrontPen, this.TranslatePolygonPoints(Owner.Rotation.Direction, Size / 100f, Owner.Location));
        }
    }

    public enum GDD_ZoneType
    {
        NoDraw,
        NoGravity,
        Normal
    }
}
