using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDD_Library.Shapes;

namespace GDD_Library
{
    public class GDD_CollisionInfo
    {
        /// <summary>
        /// The fist GDD_Object that colides
        /// </summary>
        public GDD_Object obj1 { get; set; }

        /// <summary>
        /// The angle relative to the bounce angle
        /// </summary>
        public float obj1_CollisionAngle { get; set; }

        /// <summary>
        /// The velocity after the collision
        /// </summary>
        public GDD_Vector2F obj1_NewVelocity { get; set; }

        /// <summary>
        /// Have we come to rest
        /// </summary>
        public Boolean obj1_IsStill { get; set; }
 
        /// <summary>
        /// The second GDD_Object that will colide
        /// </summary>
        public GDD_Object obj2 { get; set; }

        /// <summary>
        /// The angle relative to the bounce angle
        /// </summary>
        public float obj2_CollisionAngle { get; set; }

        /// <summary>
        /// The velocity after the collision
        /// </summary>
        public GDD_Vector2F obj2_NewVelocity { get; set; }

        /// <summary>
        /// The line the objects will collide with
        /// </summary>
        public float BounceAngle { get { return _BounceAngle; } set { this._BounceAngle = value; this.BounceAngle_low = (value > 180f) ? value - 180f : value; } }
        private float _BounceAngle;
        public float BounceAngle_low { get; set; }

        /// <summary>
        /// Returns Info about a collision between GDD_Shapes
        /// </summary>
        /// <param name="circle1"></param>
        /// <param name="circle2"></param>
        /// <returns></returns>
        public static GDD_CollisionInfo get(GDD_Circle circle1, GDD_Circle circle2)
        {

            //Calculating the euclidian distance
            double Distance = EuclidianDistance(circle1.Owner.Desired_Location, circle2.Owner.Desired_Location);

            //Doing some calculations
            if ((Distance < ((circle1.Size + circle2.Size) / 2f)) && (circle1 != circle2))
            {
                //Creating collisionInfo
                GDD_CollisionInfo result = new GDD_CollisionInfo();

                //Filling collision info with the objects
                result.obj1 = circle1.Owner;
                result.obj2 = circle2.Owner;

                //Getting bounce angle
                result.GetBounceAngle();

                //Letting obj1 collide
                result.obj1VSBounceAngle();

                result.obj2VSBounceAngle();

                //D will hold the angle of impact for obj2
                /*d = (float)DeltaAngle(result.BounceAngle, result.obj2.Velocity_Vector.Direction);

                //The max bounce that can occur
                if (result.BounceAngle < 90f || result.BounceAngle > 270f)
                {
                    Bounce_Max = result.BounceAngle_low + d;
                }
                else
                {
                    Bounce_Max = result.BounceAngle_low - d;
                }

                //Caculating the new angle for obj1 
                result.obj2_NewVelocity = new GDD_Vector2F( Bounce_Max - ((Bounce_Max - result.obj2.Velocity_Vector.Direction) * (1f - force1Ratio)), result.obj2.Velocity_Vector.Size);
                */
                //Returning the Collision Info
                return result;
            }

            //Aparently we don't collide
            return null;
        }

        public static GDD_CollisionInfo get(GDD_Circle circle1, GDD_Square square1)
        {
            //A few constants that we calculate with
            float Rad2Deg = 0.0174532925f;
            float LongSize = (float)(Math.Sqrt(2d) * (square1.Size * 0.5f));
            float Rotation = -square1.Owner.Rotation.Direction + 180f;
            float x = square1.Owner.Desired_Location.x;
            float y = square1.Owner.Desired_Location.y;

            //Creating a list of square corners
            List<GDD_Point2F> corners = new List<GDD_Point2F>();

            //Filling them
            for (int i = 0; i < 4; i++)
            {
                corners.Add(new GDD_Point2F(Math.Sin((Rotation + Angle(45f + (90f * (float)i))) * Rad2Deg) * LongSize + x, Math.Cos((Rotation + Angle(45f + (90f * (float)i))) * Rad2Deg) * LongSize + y));
            }

            int closest = 0;
            
            for (int i = 0; i < 4; i++)
            {
                //Checking if we have a new closest
                if (EuclidianDistance(corners[i], circle1.Owner.Desired_Location) < EuclidianDistance(corners[closest], circle1.Owner.Desired_Location))
                {
                    closest = i;
                }
            }

            //Erhm
            int closest2 = ((closest + 1) > 3) ? 0 : closest + 1;

            //Finding the second closest point
            for (int i = 0; i < 4; i++)
            {
                if (i != closest)
                {
                    //Checking if we have a new closest
                    if (EuclidianDistance(corners[i], circle1.Owner.Desired_Location) < EuclidianDistance(corners[closest2], circle1.Owner.Desired_Location))
                    {
                        closest2 = i;
                    }
                }
            }


            //Doing some calculations
            if (((EuclidianDistance(corners[closest], circle1.Owner.Desired_Location) < (circle1.Size / 2f)) || (((circle1.Size + square1.Size) / 2f) > EuclidianDistance(circle1.Owner.Desired_Location, square1.Owner.Desired_Location))) && (circle1.Owner != square1.Owner))
            {
                //We're colliding
                GDD_Vector2F vec = GDD_Math.DXDYToVector(new GDD_Point2F(corners[closest].x - corners[closest2].x, corners[closest].y - corners[closest2].y));

                //Making a collision info
                GDD_CollisionInfo result = new GDD_CollisionInfo();
                result.obj1 = circle1.Owner;
                result.obj2 = square1.Owner;

                //Setting bounce angle
                result.BounceAngle = vec.Direction;

                //Letting obj collide
                result.obj1VSBounceAngle();

                //Checking if the vol
                GDD_Point2F DxDy = GDD_Math.VectorToDXDY(result.obj1_NewVelocity);

                //Checking if the Y Value has a big enough value
                if (Math.Abs(DxDy.y) < 30.0d)
                {
                    DxDy.y = 0;
                    result.obj1_NewVelocity = GDD_Math.DXDYToVector(DxDy);
                    result.obj1_IsStill = true;
                }


                //Returning;
                return result;

                    //circle1.Owner.Velocity_Vector = new GDD_Vector2F(,circle1.Owner.Velocity_Vector.Size);
                
            }

            return null;
        }


        /// <summary>
        /// Calculates the bounce angle
        /// </summary>
        private void GetBounceAngle()
        {
            if (obj1.Shape is GDD_Circle && obj2.Shape is GDD_Circle)
            {
                //D is now the distance to the collision from the centre of gravity of Circle1
                float f = obj1.Shape.Size / (obj2.Shape.Size + obj1.Shape.Size);

                //Calculating the collision point
                GDD_Point2F CollisionPoint = new GDD_Point2F(
                    (obj2.Desired_Location.x - obj1.Desired_Location.x) * f,
                    (obj2.Desired_Location.y - obj1.Desired_Location.y) * f);

                //The collision angle that we'll calculate
                float CollisionAngle;

                //Calculating the collision angle
                CollisionAngle = (float)Math.Acos(CollisionPoint.x / (obj1.Shape.Size / 2f)) / 0.0174532925f;

                //Minor adjustments
                if (CollisionPoint.y < 0)
                {
                    CollisionAngle = 90f - CollisionAngle;
                }
                else
                {
                    CollisionAngle += 90f;
                }

                //Filling data retarding obj1
                obj1_CollisionAngle = CollisionAngle;

                //Filling data regarding obj2
                obj2_CollisionAngle = Angle(CollisionAngle - 180f);

                //We can now conclude the bounce angle
                BounceAngle = Angle(CollisionAngle - 90f);
            }
        }

        /// <summary>
        /// Letting obj1 collide with the BounceAngle
        /// </summary>
        /// <param name="obj"></param>
        private void obj1VSBounceAngle()
        {            
            //The ratio of force from obj1
            float force1Ratio = obj1.Force / (obj1.Force + obj2.Force);

            //Applying the circle rules if obj1 is a circle 
            if (obj1.Shape is GDD_Circle)
            {
                //D will hold the angle of impact for obj1
                float d = (float)DeltaAngle(BounceAngle_low, obj1.Velocity_Vector.Direction);

                //The max bounce that can occur
                float Bounce_Max1 = Angle(BounceAngle + d);

                //Checking for static and null objects
                if ((obj2 == null) || (obj2.GravityType == GDD_GravityType.Static))
                {
                    if (obj1.Velocity_Vector.Direction < 90 || (obj1.Velocity_Vector.Direction > 270))
                    {
                        //Applying a simple rule:)
                        float a = BounceAngle_low + d;

                        //Swapping if nessecairy
                        if (BounceAngle>270)
                        {
                            a = 360 - a;
                        }

                        //Giving new velocity
                        obj1_NewVelocity = new GDD_Vector2F(a, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);
                    }
                    else
                    {
                            obj1_NewVelocity = new GDD_Vector2F(BounceAngle_low - d, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);                                                    
                    }
                }
                else
                {
                    float Bounce_Max2 = obj2.Velocity_Vector.Direction;

                    float a = (Bounce_Max2 - Bounce_Max1) * force1Ratio;
                } 
            }
        }

        
        /// <summary>
        /// Letting obj1 collide with the BounceAngle
        /// </summary>
        /// <param name="obj"></param>
        private void obj2VSBounceAngle()
        {
            //The ratio of force from obj1
            float force1Ratio = 1f - (obj1.Force / (obj1.Force + obj2.Force));

            //Applying the circle rules if obj1 is a circle 
            if (obj2.Shape is GDD_Circle)
            {
                //D will hold the angle of impact for obj1
                float d = (float)DeltaAngle(BounceAngle, obj2.Velocity_Vector.Direction);

                //The max bounce that can occur
                /*float Bounce_Max1 = BounceAngle + d;

                //if obj2 != null
                float Bounce_Max2 = obj1.Velocity_Vector.Direction;

                float a = (Bounce_Max2 - Bounce_Max1) * force1Ratio;*/


                //Caculating the new angle for obj1 
                obj2_NewVelocity = new GDD_Vector2F(obj1.Velocity_Vector.Direction, obj1.Velocity_Vector.Size);


            }
        }


        private static double EuclidianDistance(GDD_Point2F p1, GDD_Point2F p2)
        {
            return Math.Sqrt(
                    Delta(p1.x, p2.x) * Delta(p1.x, p2.x) +
                    Delta(p1.y, p2.y) * Delta(p1.y, p2.y));

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

            if (f > 360f)
            {
                f = f - 360f;
            }
            return f;
        }

    }

    
}
