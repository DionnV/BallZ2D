using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDD_Library.Shapes;

namespace GDD_Library
{
    public abstract class GDD_Shape
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

        public static GDD_CollisionInfo Collides(GDD_Shape shape1, GDD_Shape shape2)
        {
            //Making 2 circle's collide
            if ((shape1 is GDD_Circle) && (shape2 is GDD_Circle))
            {
                return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Circle)shape2);
            }

            
            if ((shape1 is GDD_Circle) && (!(shape2 is GDD_Circle)))
            {
                if (shape2 is GDD_Square)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Square)shape2);
                }
                if (shape2 is GDD_Line)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Line)shape2);
                }
            }


            return null;

        }



       
    }
}
