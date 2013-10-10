using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GDD_Library.Shapes;
using GDD_Library;

namespace GDD_Library.Obstacles
{
    /// <summary>
    /// This class holds the intelligence to create a gravity lift
    /// </summary>
    [Serializable]
    public class GDD_GravityLift : GDD_Polygon, ISerializable
    {
        /// <summary>
        /// Constructor which is called by a deserialize-method.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GDD_GravityLift(SerializationInfo info, StreamingContext context)
        {
            //Initializing the 6 points fo the gravity lift.
            this.PolygonPoints = new GDD_Point2F[6];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, 10f);
            this.PolygonPoints[1] = new GDD_Point2F(-30f, -20f);
            this.PolygonPoints[2] = new GDD_Point2F(-10f, -10f);
            this.PolygonPoints[3] = new GDD_Point2F(10f, -10f);
            this.PolygonPoints[4] = new GDD_Point2F(30f, -20f);
            this.PolygonPoints[5] = new GDD_Point2F(50f, 10f);

            // Use the AddValue method to specify serialized values.
            Size = (float)info.GetValue("Size", typeof(float));
        }

        /// <summary>
        /// Constructor to create a GDD_GravityLift object.
        /// </summary>
        public GDD_GravityLift()
        {
            //Initializing the 6 points fo the gravity lift.
            this.PolygonPoints = new GDD_Point2F[6];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, 10f);
            this.PolygonPoints[1] = new GDD_Point2F(-30f, -20f);
            this.PolygonPoints[2] = new GDD_Point2F(-10f, -10f);
            this.PolygonPoints[3] = new GDD_Point2F(10f, -10f);
            this.PolygonPoints[4] = new GDD_Point2F(30f, -20f);
            this.PolygonPoints[5] = new GDD_Point2F(50f, 10f);
        }
    }
}
