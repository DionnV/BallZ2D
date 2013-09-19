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

    }
}
