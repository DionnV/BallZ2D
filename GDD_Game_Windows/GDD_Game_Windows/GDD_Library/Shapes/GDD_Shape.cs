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

                //The collision angle that we'll calculate
                float CollisionAngle;

                //Calculating the collision angle
                CollisionAngle = (float)Math.Acos(CollisionPoint.x / (circle1.Size / 2f)) / 0.0174532925f;

                //Minor adjustments
                if (CollisionPoint.y < 0)
                {
                    CollisionAngle = 90f - CollisionAngle;
                }
                else 
                {
                    CollisionAngle += 90f;
                }     
                
                 //Creating collisionInfo
                GDD_CollisionInfo result = new GDD_CollisionInfo();

                //Filling data retarding obj1
                result.obj1 = circle1.Owner;
                result.obj1_CollisionAngle = CollisionAngle;

                //Filling data regarding obj2
                result.obj2 = circle2.Owner;
                result.obj2_CollisionAngle = Angle(CollisionAngle -180f);

                //We can now conclude the bounce angle
                result.BounceAngle = Angle(CollisionAngle - 90f);

                //The ratio of force from obj1
                float force1Ratio = result.obj1.Force / (result.obj1.Force + result.obj2.Force);


                //D will hold the angle of impact for obj1
                float d = (float)DeltaAngle(result.BounceAngle, result.obj1.Velocity_Vector.Direction);

                //The max bounce that can occur
                float Bounce_Max = result.BounceAngle_low + d;

                //Caculating the new angle for obj1 
                float obj1_newAngle = Bounce_Max - ((Bounce_Max - result.obj1.Velocity_Vector.Direction) * force1Ratio);

                //D will hold the angle of impact for obj2
                d = (float)DeltaAngle(result.BounceAngle, result.obj2.Velocity_Vector.Direction);

                //The max bounce that can occur
                Bounce_Max = result.BounceAngle_low - d;

                //Caculating the new angle for obj1 
                float obj2_newAngle = Bounce_Max - ((Bounce_Max - result.obj2.Velocity_Vector.Direction) * (1f-force1Ratio));

                
                //Returning the Collision Info
                return result;
            }

            //Aparently we don't collide
            return null;
        }

        private static double Delta(double d1, double d2)
        {
            return Math.Abs(d1 - d2);
        }

        private static float DeltaAngle(float f1, float f2)
        {
            float f = (float)Delta(f1, f2);

            if (f > 180)
            {
                f = f - 180;
            }

            return f;
        }

         private static float Angle(float f)
        {
            if (f < 0f)
            {
                f = 360f + f;
            }
            return f;
        }
    }
}
