using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library
{
    public struct GDD_Vector2F
    {
        /// <summary>
        /// The direction of the vector
        /// </summary>
        public float Direction;

        /// <summary>
        /// The size of the vector
        /// </summary>
        public float Size;

        /// <summary>
        /// Creates a new instance of a vector
        /// </summary>
        /// <param name="Direction">The direction</param>
        /// <param name="Size">The size, or speed</param>
        public GDD_Vector2F(float Direction, float Size)
        {
            this.Direction = Direction;
            this.Size = Size;
        }

        /// <summary>
        /// Converts this object to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + Direction.ToString() + " ; " + Size.ToString() + "}";
        }

    }
}
