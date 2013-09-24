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
        /// Returns a function as in y = a*x + b, given in a GDD_Point2f(a, b).
        /// </summary>
        /// <param name="dxdy"></param>
        /// <param name="point_on_line"></param>
        /// <returns></returns>
        public static GDD_Point2F DXDYToFunc(float slope, GDD_Point2F point_on_line)
        {
            GDD_Point2F result = new GDD_Point2F();

            //Let's make a function as in y = a*x + b
            //We will return a and b as a GDD_Point2F
            float a = slope;
            float b = point_on_line.y - a * point_on_line.x;

            result.x = a;
            result.y = b;

            return result;
        }

        public static GDD_Point2F intersection(GDD_Point2F func1, GDD_Point2F func2)
        {
            GDD_Point2F result = new GDD_Point2F();

            //Given two function consisting of y = a*x + b and y = c*x + b,
            //the intersection will be a*x + b = c*x + d.
            //
            //Therefore, we will calculate x = (d - b)/(a - c)

            float x = (func2.y - func1.y) / (func1.x - func2.x);

            //Then y will be given from either func1 or func2,
            //let's just use func1.
            float y = func1.x * x + func1.y;

            //Lastly, put the found values in the GDD_Point2F
            result.x = x;
            result.y = y;

            return result;
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
