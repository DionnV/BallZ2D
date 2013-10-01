using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Square : GDD_Polygon, ISerializable
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
        }

        public GDD_Square(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
        }

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
