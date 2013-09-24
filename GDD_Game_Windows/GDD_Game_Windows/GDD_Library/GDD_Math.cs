using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library
{
    public static class GDD_Math
    {
        /// <summary>
        /// A factor to calculate with radians and degrees
        /// </summary>
        public static float RadConverter = 0.0174532925f;
        

        /// <summary>
        /// Converts a GDD_Vector2F to a DeltaX and DeltaY
        /// </summary>
        /// <param name="input"></param>
        public static GDD_Point2F VectorToDXDY(GDD_Vector2F input)
        {
            //Calculating this to DX and DY
            float dx = (float)Math.Sin(input.Direction * RadConverter) * input.Size;
            float dy = (float)Math.Cos(input.Direction * RadConverter) * input.Size;

            return new GDD_Point2F(dx, -dy);
                
        }

        public static GDD_Vector2F DXDYToVector(GDD_Point2F input)
        {

            //Defining dir
            float dir = -1f;

            //Calculating the Direction of the first object
            if (input.x == 0)
            {
                if (input.y > 0)
                {
                    dir = 180f;
                }
                else
                {
                    dir = 0f;
                }
            }
            else
            {

                dir = (float)Math.Atan(input.y / input.x) / RadConverter;

                if (input.x < 0)
                {
                    dir -= 90;
                }
                else
                {
                    dir += 90;
                }
            }

            //Calculating the size
            float size = (float)Math.Sqrt(input.x * input.x + input.y * input.y);

            //Returning the vector
            return new GDD_Vector2F((dir < 0) ? (360f + dir) : dir, size);

        }

        /// <summary>
        /// The Euclidian distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double EuclidianDistance(GDD_Point2F p1, GDD_Point2F p2)
        {
            return Math.Sqrt(
                    Delta(p1.x, p2.x) * Delta(p1.x, p2.x) +
                    Delta(p1.y, p2.y) * Delta(p1.y, p2.y));

        }

        /// <summary>
        /// The delta of 2 values
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static double Delta(double d1, double d2)
        {
            return Math.Abs(d1 - d2);
        }

        public static float DeltaAngle(float f1, float f2)
        {
            float f = (float)Delta(f1, f2);

            if (f > 180)
            {
                f = f - 180;
            }

            return f;
        }

        public static float Angle(float f)
        {
            if (f < 0f)
            {
                f = 360f + f;
            }

            if (f > 360f)
            {
                f = f - 360f;
            }
            return f;
        }

    }
}
