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
            //GD

            if ((shape1 is GDD_Circle) && (shape2 is GDD_Circle))
            {
                return Collides_CircleVSCircle((GDD_Circle)shape1, (GDD_Circle)shape2);
            }

            return null;

        }

        private static GDD_CollisionInfo Collides_CircleVSCircle(GDD_Circle circle1, GDD_Circle circle2)
        {

            //Calculating the euclidian distance
            double Distance = Math.Sqrt(
                    Delta(circle1.Owner.Location.x, circle2.Owner.Location.x) * Delta(circle1.Owner.Location.x, circle2.Owner.Location.x) +
                    Delta(circle1.Owner.Location.y, circle2.Owner.Location.y) * Delta(circle1.Owner.Location.y, circle2.Owner.Location.y));

            //Doing some calculations
            if (( Distance < ((circle1.Size + circle2.Size) / 2f)) && (circle1 != circle2))
            {
                //D is now the distance to the collision from the centre of gravity of Circle1
                float f = circle1.Size / (circle1.Size + circle2.Size) ;

                //Calculating the collision point
                GDD_Point2F CollisionPoint = new GDD_Point2F(
                    (circle2.Owner.Location.x - circle1.Owner.Location.x) * f,
                    (circle2.Owner.Location.y - circle1.Owner.Location.y) * f);

                //Calcuating the collision angle, relative to circle1
                /*float CollisionAngle;
                if (CollisionPoint.y == 0)
                {
                    CollisionAngle = 90f;
                }
                else
                {
                    if (CollisionPoint.x == 0)
                    {
                        CollisionAngle = (CollisionPoint.y > 0) ? 180f : 0f;
                    }
                    else
                    {
                        CollisionAngle = (float)Math.Atan(CollisionPoint.y / Col) /  0.0174532925f;
                        CollisionAngle = 90f - CollisionAngle;
                    }
                }*/


                float CollisionAngle;

                //Calculating the collision angle
                CollisionAngle = (float)Math.Acos(CollisionPoint.x / (circle1.Size / 2f)) / 0.0174532925f;
                if (CollisionPoint.y < 0)
                {
                    CollisionAngle = 90f - CollisionAngle;
                }
                else 
                {
                    CollisionAngle += 90f;
                }     
                
                 




                return new GDD_CollisionInfo() ;
            }

            //Aparently we don't collide
            return null;
        }

        private static double Delta(double d1, double d2)
        {
            return Math.Abs(d1 - d2);
        }
    }
}
