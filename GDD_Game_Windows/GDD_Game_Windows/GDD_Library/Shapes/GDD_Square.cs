using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    /// <summary>
    /// This class hold the intelligence to create a square.
    /// </summary>
    [Serializable]
    public class GDD_Square : GDD_Polygon, ISerializable
    {
        /// <summary>
        /// Constructor which is called by a deserialize-method.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GDD_Square(SerializationInfo info, StreamingContext context)
        {
            //Initializing the 4 points for 
            this.PolygonPoints = new GDD_Point2F[4];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, -50f);
            this.PolygonPoints[1] = new GDD_Point2F(50f, -50f);
            this.PolygonPoints[2] = new GDD_Point2F(50f, 50f);
            this.PolygonPoints[3] = new GDD_Point2F(-50f, 50f);

            Size = (float) info.GetValue("Size", typeof(float));
        }

        /// <summary>
        /// Constructor to create a GDD_Square object.
        /// </summary>
        public GDD_Square() 
        {
            //Initializing the 4 points for 
            this.PolygonPoints = new GDD_Point2F[4];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, -50f);
            this.PolygonPoints[1] = new GDD_Point2F(50f, -50f);
            this.PolygonPoints[2] = new GDD_Point2F(50f, 50f);
            this.PolygonPoints[3] = new GDD_Point2F(-50f, 50f);
        }
    }
}
