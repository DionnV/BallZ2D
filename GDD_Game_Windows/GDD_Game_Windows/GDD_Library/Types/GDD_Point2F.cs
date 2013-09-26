using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

namespace GDD_Library
{
    [Serializable]
    public struct GDD_Point2F: ISerializable
    {
        /// <summary>
        /// The x coordinate of the Point
        /// </summary>
        public float x;

        /// <summary>
        /// The y coordinate of the point
        /// </summary>
        public float y;

        /// <summary>
        /// Creates a new instance of GDD_Point2F
        /// </summary>
        /// <param name="x">The X value</param>
        /// <param name="y">The Y value</param>
        public GDD_Point2F(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public GDD_Point2F(double x, double y)
        {
            this.x = (float)x;
            this.y = (float)y;
        }

        public Point ToPoint()
        {
            return new Point((int)Math.Round(this.x), (int)Math.Round(this.y));
        }

        /// <summary>
        /// Converts the Point2F to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + x.ToString() + " ; " + y.ToString() + "}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("x", x, typeof(float));
            info.AddValue("y", y, typeof(float));
        }

        public GDD_Point2F(SerializationInfo info, StreamingContext context)
        {
            x = (float) info.GetValue("x", typeof(float));
            y = (float) info.GetValue("y", typeof(float));
        }
    }
}
