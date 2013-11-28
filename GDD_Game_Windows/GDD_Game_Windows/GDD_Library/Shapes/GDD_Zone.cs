/*using System;
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
        /// How big is the edge size?
        /// </summary>
        public float EdgeSize { get; set; }

        /// <summary>
        /// Constructor which is called by a deserialize-method.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GDD_Zone(SerializationInfo info, StreamingContext context)
        {
            //Initializing the 4 points for 
            this.PolygonPoints = new GDD_Point2F[4];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, -50f);
            this.PolygonPoints[1] = new GDD_Point2F(50f, -50f);
            this.PolygonPoints[2] = new GDD_Point2F(50f, 50f);
            this.PolygonPoints[3] = new GDD_Point2F(-50f, 50f);

            //The edgeshape
            EdgeShape = new GDD_Polygon();
            EdgeShape.PolygonPoints = new GDD_Point2F[4];
            EdgeShape.PolygonPoints[0] = new GDD_Point2F(0f, 0f);
            EdgeShape.PolygonPoints[1] = new GDD_Point2F(100f, 100f);
            EdgeShape.PolygonPoints[2] = new GDD_Point2F(200f, 100f);
            EdgeShape.PolygonPoints[3] = new GDD_Point2F(100f, 0f);

            //The Edgesize is normally 5
            EdgeSize = 5;
        }

        /// <summary>
        /// Creates a new instance of zone
        /// </summary>
        public GDD_Zone()
        {

            //Creating the basic shape for ourself
            this.PolygonPoints = new GDD_Point2F[4];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, -50f);
            this.PolygonPoints[1] = new GDD_Point2F(50f, -50f);
            this.PolygonPoints[2] = new GDD_Point2F(50f, 50f);
            this.PolygonPoints[3] = new GDD_Point2F(-50f, 50f);

            //The edgeshape
            EdgeShape = new GDD_Polygon();
            EdgeShape.PolygonPoints = new GDD_Point2F[4];
            EdgeShape.PolygonPoints[0] = new GDD_Point2F(0f, 0f);
            EdgeShape.PolygonPoints[1] = new GDD_Point2F(100f, 100f);
            EdgeShape.PolygonPoints[2] = new GDD_Point2F(200f, 100f);
            EdgeShape.PolygonPoints[3] = new GDD_Point2F(100f, 0f);

            //The Edgesize is normally 5
            EdgeSize = 5;
        }

        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        {
            GC.Collect();

            //Size represents the size of the border
            float SizeFactor = Size / 100f;
           // float EdgeFactor = EdgeSize / 100f;

            //Getting the lines
            GDD_Object[] Lines = TranslatePolygon_ToLines();

            //Defining variables we're using
            GDD_Vector2F vec, vec1;
            GDD_Point2F dxdy, dxdy1;
            PointF end;

            //Using 
            GraphicsPath polygonPath = new GraphicsPath();
            

            //Looping each line
            foreach (GDD_Object line in Lines)
            {
                //
                vec = new GDD_Vector2F(line.Rotation.Direction, 200f * SizeFactor);
                dxdy = vec.ToDXDY();

                //Making sure we got the right brush
                vec1 = new GDD_Vector2F(line.Rotation.Direction + 90f, 100f * SizeFactor);
                dxdy1 = vec1.ToDXDY();

                //Doing a transformation
                end = new PointF(dxdy1.x + line.Location.x, dxdy1.y + line.Location.y);

                //Using a new brush
                Point p = line.Location.ToPoint();
                Brush brush = new LinearGradientBrush(p, end, Owner.FrontColor, Color.White);
  
                //The count of shapes to draw
                int cnt = (int)(line.Shape.Size / vec.Size);
                
                //Lets define shape forhand
                PointF[] shape;

                //Looping multiple times
                for (int i = 0; i < cnt; i++)
                {
                    //Transformin g the points
                    shape = EdgeShape.TranslatePolygonPoints(line.Rotation.Direction - 90f, 0.1f, new GDD_Point2F(line.Location.x + (i * dxdy.x), line.Location.y + (i * dxdy.y)));

                    G.FillPolygon(brush, shape);
                }
                    

                //Draws the shape using the poligon data
                G.DrawPolygon(Owner.FrontPen, this.TranslatePolygonPoints(Owner.Rotation.Direction, Size / 100f, Owner.Location));
            }

            G.Dispose();
        }
    }

    /// <summary>
    /// These enums will define what kind of zone we are using.
    /// </summary>
    public enum GDD_ZoneType
    {
        NoDraw,
        NoGravity,
        Normal
    }
}*/
