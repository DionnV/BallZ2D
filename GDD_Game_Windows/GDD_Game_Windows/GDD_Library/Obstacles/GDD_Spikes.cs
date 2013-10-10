using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GDD_Library.Shapes;

namespace GDD_Library.Obstacles
{
    /// <summary>
    /// This class hold the intelligence to create a spikes object.
    /// </summary>
    [Serializable]
    public class GDD_Spikes : GDD_Polygon, ISerializable
    {
        /// <summary>
        /// Constructor to create a GDD_Spikes object.
        /// </summary>
        public GDD_Spikes()
        {
            //Initialize the 11 points for the spikes.
            this.PolygonPoints = new GDD_Point2F[11];
            this.PolygonPoints[0] = new GDD_Point2F(-50, 0);
            this.PolygonPoints[1] = new GDD_Point2F(-40, -30);
            this.PolygonPoints[2] = new GDD_Point2F(-30, 0);
            this.PolygonPoints[3] = new GDD_Point2F(-20, -30);
            this.PolygonPoints[4] = new GDD_Point2F(-10, 0);
            this.PolygonPoints[5] = new GDD_Point2F(0, -30);
            this.PolygonPoints[6] = new GDD_Point2F(10, 0);
            this.PolygonPoints[7] = new GDD_Point2F(20, -30);
            this.PolygonPoints[8] = new GDD_Point2F(30, 0);
            this.PolygonPoints[9] = new GDD_Point2F(40, -30);
            this.PolygonPoints[10] = new GDD_Point2F(50, 0);
        }

        /// <summary>
        /// Constructor which is called by a deserialize-method.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GDD_Spikes(SerializationInfo info, StreamingContext context)
        {
            this.PolygonPoints = new GDD_Point2F[11];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, 0f);
            this.PolygonPoints[1] = new GDD_Point2F(-40f, -30f);
            this.PolygonPoints[2] = new GDD_Point2F(-30f, 0f);
            this.PolygonPoints[3] = new GDD_Point2F(-20f, -30f);
            this.PolygonPoints[4] = new GDD_Point2F(-10f, 0f);
            this.PolygonPoints[5] = new GDD_Point2F(0f, -30f);
            this.PolygonPoints[6] = new GDD_Point2F(10f, 0f);
            this.PolygonPoints[7] = new GDD_Point2F(20f, -30f);
            this.PolygonPoints[8] = new GDD_Point2F(30f, 0f);
            this.PolygonPoints[9] = new GDD_Point2F(40f, -30f);
            this.PolygonPoints[10] = new GDD_Point2F(50f, 0f);
        }
    }
}
