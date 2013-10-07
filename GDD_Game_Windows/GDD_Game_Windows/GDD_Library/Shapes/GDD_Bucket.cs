using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Bucket : GDD_Polygon, ISerializable
    {
/*
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
        }
*/
        public GDD_Bucket(SerializationInfo info, StreamingContext context)
        {
            //Initializing the 8 points for the bucket
            this.PolygonPoints = new GDD_Point2F[8];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, -36f);
            this.PolygonPoints[1] = new GDD_Point2F(-40f, -36f);
            this.PolygonPoints[2] = new GDD_Point2F(-27f, 40f);
            this.PolygonPoints[3] = new GDD_Point2F(27f, 40f);
            this.PolygonPoints[4] = new GDD_Point2F(40f, -36f);
            this.PolygonPoints[5] = new GDD_Point2F(50f, -36f);
            this.PolygonPoints[6] = new GDD_Point2F(35f, 50f);
            this.PolygonPoints[7] = new GDD_Point2F(-35f, 50f);

            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
        }

        public GDD_Bucket() 
        {
            //Initializing the 8 points for the bucket
            this.PolygonPoints = new GDD_Point2F[8];
            this.PolygonPoints[0] = new GDD_Point2F(-50f, -36f);
            this.PolygonPoints[1] = new GDD_Point2F(-40f, -36f);
            this.PolygonPoints[2] = new GDD_Point2F(-27f, 40f);
            this.PolygonPoints[3] = new GDD_Point2F(27f, 40f);
            this.PolygonPoints[4] = new GDD_Point2F(40f, -36f);
            this.PolygonPoints[5] = new GDD_Point2F(50f, -36f);
            this.PolygonPoints[6] = new GDD_Point2F(35f, 50f);
            this.PolygonPoints[7] = new GDD_Point2F(-35f, 50f);
        }
    }
}
