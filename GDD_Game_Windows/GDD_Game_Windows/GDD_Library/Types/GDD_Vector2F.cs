using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GDD_Library
{
    [Serializable]
    public struct GDD_Vector2F: ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
            info.AddValue("Direction", Direction, typeof(float));
        }

        public GDD_Vector2F(SerializationInfo info, StreamingContext context)
        {
            Size = (float)info.GetValue("Size", typeof(float));
            Direction = (float)info.GetValue("Direction", typeof(float));
        }

    }
}
