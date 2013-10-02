using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDD_Library.Shapes;
using System.Runtime.Serialization;

namespace GDD_Library
{
    [Serializable]
    public abstract class GDD_Shape : ISerializable, ICloneable
    {
        public abstract void Draw(Graphics G);

        /// <summary>
        /// The size of this Square
        /// </summary>
        public float Size { get { return _Size; } set { this._Size = value; } }
        private float _Size = 1f;

        /// <summary>
        /// The Owner of this shape
        /// </summary>
        public GDD_Object Owner { get { return _Owner; } set { this._Owner = value; } }
        private GDD_Object _Owner;

        /// <summary>
        /// returns a clone of this object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static GDD_CollisionInfo Collides(GDD_Shape shape1, GDD_Shape shape2)
        {
            //Making 2 circle's collide
            if (shape1 is GDD_Circle)
            {  
                if (shape2 is GDD_Circle)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Circle)shape2);
                }

        
                if (shape2 is GDD_Polygon)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Polygon)shape2);
                }

                if (shape2 is GDD_Line)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Line)shape2);
                
                }
            }


            return null;

        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
            info.AddValue("Owner", Owner, typeof(GDD_Object));
        }

        public GDD_Shape(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
            Owner = (GDD_Object)info.GetValue("Owner", typeof(GDD_Object));
        }

        public GDD_Shape() { }
       
    }
}
