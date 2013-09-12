using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library
{
    public struct GDD_Point2F
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

        /// <summary>
        /// Converts the Point2F to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + x.ToString() + " ; " + y.ToString() + "}";
        }
    }
}
