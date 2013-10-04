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
        /// The direction of the vector in Degrees ( always normalized to 0-360 )
        /// </summary>
        public float Direction
        {
            get
            {
                //Returning the direction
                return _Direction;
            }
            set
            {
                //Setting the direction
                this._Direction = value % 360f;
            }
        }
        private float _Direction;

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
            this.Size = Size;
            //this.Direction = Direction;
            this._Direction = Direction;
            
        }

        /// <summary>
        /// Creates a new instance using serializing info
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GDD_Vector2F(SerializationInfo info, StreamingContext context)
        {
            Size = (float)info.GetValue("Size", typeof(float));
            _Direction = (float)info.GetValue("Direction", typeof(float));
        }

        /// <summary>
        /// Converts this object to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + Direction.ToString() + " ; " + Size.ToString() + "}";
        }

        /// <summary>
        /// Converts the Point2F to a string, with
        /// </summary>
        /// <returns></returns>
        public string ToString(string format)
        {
            return "{" + Direction.ToString(format) + " ; " + Size.ToString(format) + "}";
        }


        /// <summary>
        /// Creates a DXDY based on this Vector
        /// </summary>
        /// <returns></returns>
        public GDD_Point2F ToDXDY()
        {
            //Calculating this to DX and DY
            float dx = (float)Math.Sin(this.Direction * GDD_Math.RadConverter) * this.Size;
            float dy = (float)Math.Cos(this.Direction * GDD_Math.RadConverter) * this.Size;

            return new GDD_Point2F(dx, -dy);
        }

        /// <summary>
        /// Sets the serializing data
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
            info.AddValue("Direction", Direction, typeof(float));
        }


    }
}
