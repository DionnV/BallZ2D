using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Polygon : GDD_Shape, ISerializable
    {
        /// <summary>
        /// Creates a new instance of GDD Polygon
        /// </summary>
        public GDD_Polygon()
        {
            //Initializing the points
            this.PolygonPoints = new GDD_Point2F[0];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
            info.AddValue("PolygonPoints", PolygonPoints, typeof(GDD_Point2F[]));
        }

        public GDD_Polygon(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float)info.GetValue("Size", typeof(float));
            PolygonPoints = (GDD_Point2F[])info.GetValue("PolygonPoints", typeof(GDD_Point2F[]));
        }        

        /// <summary>
        /// The points of the polygon, normalized to a shape of 100 units
        /// </summary>
        public GDD_Point2F[] PolygonPoints { get; set; }

        /// <summary>
        /// Translating the polygon, applying owner's rotation and a scale
        /// </summary>
        /// <returns></returns>
        public PointF[] TranslatePolygonPoints()
        {
            return TranslatePolygonPoints(Owner.Rotation.Direction, this.Size / 100f, Owner.Location);
        }

        /// <summary>
        /// Translating the polygon, applying rotation and a scale
        /// </summary>
        /// <param name="Rotation">Rotation in degrees to rotate the Polygon for</param>
        /// <param name="Scale">The scale factor for the size</param>
        /// <returns></returns>
        public PointF[] TranslatePolygonPoints(float Rotation, float Scale, GDD_Point2F offset)
        {
            //Initializing result
            PointF[] result = new PointF[this.PolygonPoints.Length];

            //Initializing a vector and point that will do all the calculations for us
            GDD_Vector2F vector;
            GDD_Point2F dxdy;

            //Looping each point, translating the individual rotation and scale
            for (int i = 0; i < this.PolygonPoints.Length; i++)
            {
                //Creating a vector
                vector = this.PolygonPoints[i].ToVector();

                //Applying the rotation change
                vector.Direction += Rotation;

                //Applying the size change
                vector.Size *= Scale;

                //Translating to a dxdy
                dxdy = vector.ToDXDY();

                //Translating to a XY
                result[i] = new PointF(offset.x + dxdy.x, offset.y + dxdy.y);
            }

            //Returning the result
            return result;
        }

        /// <summary>
        /// Translating the polygon, applying rotation and a scale
        /// </summary>
        /// <param name="Rotation">Rotation in degrees to rotate the Polygon for</param>
        /// <param name="Scale">The scale factor for the size</param>
        /// <returns></returns>
        public GDD_Point2F[] TranslatePolygonGDDPoints(float Rotation, float Scale, GDD_Point2F offset)
        {
            //Initializing result
            GDD_Point2F[] result = new GDD_Point2F[this.PolygonPoints.Length];

            //Initializing a vector and point that will do all the calculations for us
            GDD_Vector2F vector;
            GDD_Point2F dxdy;

            //Looping each point, translating the individual rotation and scale
            for (int i = 0; i < this.PolygonPoints.Length; i++)
            {
                //Creating a vector
                vector = this.PolygonPoints[i].ToVector();

                //Applying the rotation change
                vector.Direction += Rotation;

                //Applying the size change
                vector.Size *= Scale;

                //Translating to a dxdy
                dxdy = vector.ToDXDY();

                //Translating to a XY
                result[i] = new GDD_Point2F(offset.x + dxdy.x, offset.y + dxdy.y);
            }

            //Returning the result
            return result;
        }

        /// <summary>
        /// Checks wether this shape contains a cirtain point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override Boolean ContainsPoint(GDD_Point2F point)
        {
            //Getting the translated points
            GDD_Point2F[] Points = TranslatePolygonGDDPoints(Owner.Rotation.Direction, 1, Owner.Location);

            if (Points.Length > 2)
            {
                //Sorting by X to get the xMIn and xMax
                Points = Points.OrderBy(p => p.x).ToArray();
                float xMin = Points[0].x;
                float xMax = Points[Points.Length - 1].x;

                //Sorting by Y to get the yMax and yMin
                Points = Points.OrderBy(p => p.y).ToArray();
                float yMin = Points[0].y;
                float yMax = Points[Points.Length - 1].y;

                //Checking if we're outside the polygon
                if (point.x < xMin || point.x > xMax || point.y < yMin || point.y > yMax)
                {
                    //Definately outside polygon
                    return false;
                }

                //Check to see if we're in the polygon, translated to C# originally written by Nathan Mercer.
                int i, j = Points.Length - 1;
                bool result = false;

                for (i = 0; i < Points.Length; i++)
                {
                    if ((Points[i].y < point.y && Points[j].y >= point.y || Points[j].y < point.y && Points[i].y >= point.y) && (Points[i].x <= point.x || Points[j].x <= point.x))
                    {
                        if (Points[i].x + (point.y - Points[i].y) / (Points[j].y - Points[i].y) * (Points[j].x - Points[i].x) < point.x)
                        {
                            result = !result;
                        }
                    }
                    j = i;
                }
                //Returning the result
                return result;
            }
            return false;
        }

        /// <summary>
        /// Converts the polygon to a set of faces / lines
        /// </summary>
        /// <returns></returns>
        public GDD_Object[] TranslatePolygon_ToLines()
        {
            //Getting all the translated points
            GDD_Point2F[] Points = TranslatePolygonGDDPoints(Owner.Rotation.Direction, this.Size / 100f, Owner.Location);

            //Initializing a list of lines
            GDD_Object[] Lines = new GDD_Object[Points.Length];

            //Looping all the points, making lines and collisions
            for (int i = 0; i < Points.Count(); i++)
            {
                //Making a line
                Lines[i] = GDD_Line.Create(Points[i], Points[(i + 1) % Points.Length]);
                Lines[i].Rotation = new GDD_Vector2F(Lines[i].Rotation.Direction % 360f, Lines[i].Rotation.Size);
            }

            //Returning the lines
            return Lines;
        }

        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        {
            //Getting a translated polygon
            PointF[] poly = TranslatePolygonPoints(Owner.Rotation.Direction, Size / 100f, Owner.Location);

            //Draws the shape using the poligon data
            G.FillPolygon(DrawingColor, poly);
            G.DrawPolygon(Owner.FrontPen, poly);
        }

    }
}
