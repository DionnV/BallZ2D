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
        /// The roll velocity
        /// </summary>
        public GDD_Vector2F obj1_RollVelocity { get; set; }

        /// <summary>
        /// The velocity after the collision
        /// </summary>
        public GDD_Vector2F obj1_NewVelocity { get; set; }

        /// <summary>
        /// Have we come to rest
        /// </summary>
        public Boolean obj1_IsStill { get; set; }

        /// <summary>
        /// The rotation after the collision
        /// </summary>
        public GDD_Vector2F obj1_NewRotation { get; set; }

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
            double Distance = GDD_Math.EuclidianDistance(circle1.Owner.Desired_Location, circle2.Owner.Desired_Location);

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

                //Checking if the vol
                GDD_Point2F DxDy = GDD_Math.VectorToDXDY(result.obj1_NewVelocity);

                //Checking if the Y Value has a big enough value
                if (Math.Abs(DxDy.y) < 30.0d)
                {

                    if (Math.Abs(DxDy.x) < 0.05d)
                    {
                        result.obj1_IsStill = true;
                        DxDy.y = 0;
                        result.obj1_NewVelocity = GDD_Math.DXDYToVector(DxDy);
                    }
                }

                //Collicing obj2
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
                corners.Add(new GDD_Point2F(Math.Sin((Rotation + GDD_Math.Angle(45f + (90f * (float)i))) * Rad2Deg) * LongSize + x, Math.Cos((Rotation + GDD_Math.Angle(45f + (90f * (float)i))) * Rad2Deg) * LongSize + y));
            }

            int closest = 0;

            for (int i = 0; i < 4; i++)
            {
                //Checking if we have a new closest
                if (GDD_Math.EuclidianDistance(corners[i], circle1.Owner.Desired_Location) < GDD_Math.EuclidianDistance(corners[closest], circle1.Owner.Desired_Location))
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
                    if (GDD_Math.EuclidianDistance(corners[i], circle1.Owner.Desired_Location) < GDD_Math.EuclidianDistance(corners[closest2], circle1.Owner.Desired_Location))
                    {
                        closest2 = i;
                    }
                }
            }

            //Calculating the euclidian distances
            float eud_corner = (float)GDD_Math.EuclidianDistance(corners[closest], circle1.Owner.Desired_Location);
            float eud_obj = (float)GDD_Math.EuclidianDistance(circle1.Owner.Desired_Location, square1.Owner.Desired_Location);

            //Doing some calculations
            if ((eud_corner < (circle1.Size / 2f) || (((circle1.Size + square1.Size) / 2f) > eud_obj)) && (circle1.Owner != square1.Owner))
            {
                //Making a collision info
                GDD_CollisionInfo result = new GDD_CollisionInfo();
                result.obj1 = circle1.Owner;
                result.obj2 = square1.Owner;

                //Determining if we're colliding with a face or a point
                if (eud_obj > Math.Sqrt(Math.Pow((square1.Size / 2f) + (circle1.Size / 2f), 2) + Math.Pow(square1.Size / 2f, 2)))
                {
                    //With point
                    GDD_Vector2F vec = GDD_Math.DXDYToVector(new GDD_Point2F(corners[closest].x - circle1.Owner.Desired_Location.x, corners[closest].y - circle1.Owner.Desired_Location.y));
                    result.BounceAngle = vec.Direction - 90f;
                }
                else
                {
                    //With face - creating a virutal Line to collide with
                    GDD_Object obj = new GDD_Object(new GDD_Line());
                    obj.Location = corners[closest];
                    obj.Rotation = GDD_Math.DXDYToVector(
                                        new GDD_Point2F(
                                            corners[closest2].x - corners[closest].x,
                                            corners[closest2].y - corners[closest].y));
                    ((GDD_Line)obj.Shape).Size = obj.Rotation.Size; 
                    obj.Rotation = new GDD_Vector2F(obj.Rotation.Direction, square1.Owner.Rotation.Size);
                    obj.GravityType = GDD_GravityType.Static;
                    
                    //Returning the result
                    result = GDD_CollisionInfo.get(circle1, (GDD_Line)obj.Shape);

                    return result;

                }

                //Letting obj collide
                result.obj1VSBounceAngle();

                //Calculating the new velocity as DxDy
                GDD_Point2F DxDy = GDD_Math.VectorToDXDY(result.obj1_NewVelocity);

                //Calculating the collision angle
                result.obj1_CollisionAngle = GDD_Math.Angle((float)GDD_Math.Delta(result.obj1.Velocity_Vector.Direction, result.BounceAngle));

                //The circumference
                float circumference = (float)Math.PI * result.obj1.Shape.Size;

                //Rotation of the Circle in Pixels per second
                float PXS = (float)(result.obj1.Rotation.Size * circumference);

                //Calculating the force factor
                float forceFactor = PXS / result.obj1.Velocity_Vector.Size;

                //Calculating the angle factor
                float angleFactor = -((90f - result.obj1_CollisionAngle) / 90f);

                //Calculating the new velocity as DxDy
                // DxDy.x = DxDy.x + (angleFactor * PXS);

                //result.obj1_NewRotation = new GDD_Vector2F(result.obj1.Rotation.Direction, result.obj1.Rotation.Size / 2f);
                //result.obj1_NewRotation = new GDD_Vector2F(result.obj1.Rotation.Direction, result.obj1_NewRotation.Size + DxDy.x / circumference);


                //Calculating the angular momentum
                /*result.obj1_NewRotation = new GDD_Vector2F(
result.obj1.Rotation.Direction,
((PXS * forceFactor * angleFactor + DxDy.x * (1f - forceFactor) * (1f - angleFactor)) / 2f) / ((float)Math.PI * result.obj1.Shape.Size));*/




                //Modifying the DXDY
                //float f = result.obj1_NewRotation.Direction + ((PXS * angleFactor) / ((float)Math.PI * result.obj1.Shape.Size));
                //DxDy = GDD_Math.VectorToDXDY(new GDD_Vector2F(result.obj1_NewVelocity.Direction + , result.obj1_NewVelocity.Size));

                //DxDy.x = ((PXS * forceFactor + DxDy.x * (1f - forceFactor)) / 2f);


                //Stopping the rotation if necessary
                /*if (Math.Abs(((PXS * forceFactor * angleFactor) / ((float)Math.PI * result.obj1.Shape.Size))) < 0.02)
{
result.obj1_NewRotation = new GDD_Vector2F(result.obj1.Rotation.Direction, 0f);
}*/

                //Stopping the movement if necessary
                if (Math.Abs(DxDy.y) < 30.0d)
                {
                    if (Math.Abs(DxDy.x) < 0.5d)
                    {
                        result.obj1_IsStill = true;
                        DxDy.y = 0;
                    }
                }

                //Adjusting the velocity
                result.obj1_NewVelocity = GDD_Math.DXDYToVector(DxDy);

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
                obj2_CollisionAngle = GDD_Math.Angle(CollisionAngle - 180f);

                //We can now conclude the bounce angle
                BounceAngle = GDD_Math.Angle(CollisionAngle - 90f);
            }
        }

        public static GDD_CollisionInfo get(GDD_Circle circle1, GDD_Line line1)
        {
            //The hypothecial roll direction
            float RollDirection = 0;
            float arot = GDD_Math.Angle(line1.Owner.Rotation.Direction);

            if (arot < 90f)
            {
                RollDirection = 180f + arot;
            }
            else if (arot > 270f)
            {
                RollDirection = arot - 180f;
            }
            else
            {
                RollDirection = arot;
            }

            if (circle1.Owner.RollVelocity.Direction == RollDirection)
            {
                return null;
            }

            GDD_Point2F line_end = line1.end;
            float start_to_circle = (float)GDD_Math.EuclidianDistance(line1.Owner.Location, circle1.Owner.Desired_Location);
            float end_to_circle = (float)GDD_Math.EuclidianDistance(line_end, circle1.Owner.Desired_Location);
            
            float dx;
            float dy;
            
            if (line1.Owner.Rotation.Direction > 180f)
            {
                dx = line1.Owner.Location.x - line_end.x;
                dy = line1.Owner.Location.y - line_end.y;
            }
            else
            {
                dx = line_end.x - line1.Owner.Location.x;
                dy = line_end.y - line1.Owner.Location.y;
            
            }
            float dxdy = dy / dx;

            GDD_Point2F func1;
            GDD_Point2F func2;

            if ((GDD_Math.Angle(line1.Owner.Rotation.Direction) == 90f))
            {
                func1 = GDD_Math.DXDYToFunc(0, line1.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(10000, circle1.Owner.Desired_Location);
            }
            else if(GDD_Math.Angle(line1.Owner.Rotation.Direction) == 270f)
            {
                func1 = GDD_Math.DXDYToFunc(0, line1.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(-10000, circle1.Owner.Desired_Location);             
            }
            else if (GDD_Math.Angle(line1.Owner.Rotation.Direction) == 180f)
            {
                func1 = GDD_Math.DXDYToFunc(-10000, line1.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(0, circle1.Owner.Desired_Location);
            }
            else if (GDD_Math.Angle(line1.Owner.Rotation.Direction) == 0f)
            {
                func1 = GDD_Math.DXDYToFunc(10000, line1.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(0, circle1.Owner.Desired_Location);
            }
            else
            {
                func1 = GDD_Math.DXDYToFunc(dxdy, line1.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(-1 / dxdy, circle1.Owner.Desired_Location);
            }
            

            GDD_Point2F intersection = GDD_Math.intersection(func1, func2);

            if (GDD_Math.EuclidianDistance(intersection, circle1.Owner.Desired_Location) < (circle1.Size / 2F))
            {

                //We might be colliding
                GDD_CollisionInfo result = null;


                //Colliding with the point
                if ((intersection.x > Math.Min(line1.Owner.Location.x, line_end.x)) && (intersection.x < Math.Max(line1.Owner.Location.x, line_end.x)))
                {
                    //We're colliding
                    result = new GDD_CollisionInfo();

                    //We are probably colliding or already penetrating a bit
                    result.obj1 = circle1.Owner;
                    result.obj2 = line1.Owner;

                    //RollDireciton
                    result.obj1_RollVelocity = new GDD_Vector2F(RollDirection, result.obj1_NewVelocity.Size);

                    //Rotation remains the same
                    result.obj1_NewRotation = circle1.Owner.Rotation;
                    
                    if (line1.Owner.Rotation.Direction < 0)
                    {
                        result.BounceAngle = line1.Owner.Rotation.Direction + 180f;
                    }
                    else
                    {
                        result.BounceAngle = line1.Owner.Rotation.Direction;
                    }
                }
                else
                {
                    float eud_start = (float)GDD_Math.EuclidianDistance(line1.Owner.Location, circle1.Owner.Desired_Location);
                    float eud_end = (float)GDD_Math.EuclidianDistance(line_end, circle1.Owner.Desired_Location);

                    //Collision with the end of the line?
                    if (eud_start < (circle1.Size / 2f))
                    { //We're colliding
                        result = new GDD_CollisionInfo();

                        //We are probably colliding or already penetrating a bit
                        result.obj1 = circle1.Owner;
                        result.obj2 = line1.Owner;

                        //Rotation remains the same
                        result.obj1_NewRotation = circle1.Owner.Rotation;

                        //Calculating new bounce angle
                        GDD_Vector2F vec = GDD_Math.DXDYToVector(new GDD_Point2F(line1.Owner.Location.x - circle1.Owner.Desired_Location.x, line1.Owner.Location.y - circle1.Owner.Desired_Location.y));
                        result.BounceAngle = vec.Direction - 90f;
                    }
                    if (eud_end < (circle1.Size / 2f))
                    {
                        //We're colliding
                        result = new GDD_CollisionInfo();

                        //We are probably colliding or already penetrating a bit
                        result.obj1 = circle1.Owner;
                        result.obj2 = line1.Owner;

                        //Rotation remains the same
                        result.obj1_NewRotation = circle1.Owner.Rotation;
                    
                        //Calculating new bounce angle
                        GDD_Vector2F vec = GDD_Math.DXDYToVector(new GDD_Point2F(line_end.x - circle1.Owner.Desired_Location.x, line_end.y - circle1.Owner.Desired_Location.y));
                        result.BounceAngle = vec.Direction - 90f;


                    }
                }

                if (result != null)
                {
                    //Lettng it do it's work!
                    result.obj1VSBounceAngle();

                    //Check for roll
                    //if (GDD_Math.DeltaAngle(result.obj1_NewVelocity.Direction, line1.Owner.Rotation.Direction) < 5f)
                    //{
                    //}
                }

                return result;
            }
            return null;
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
                float d = (float)GDD_Math.DeltaAngle(BounceAngle_low, obj1.Velocity_Vector.Direction);

                //The max bounce that can occur
                float Bounce_Max1 = GDD_Math.Angle(BounceAngle + d);

                //Checking for static and null objects
                if ((obj2 == null) || (obj2.GravityType == GDD_GravityType.Static))
                {
                    if (obj1.Velocity_Vector.Direction < 90 || (obj1.Velocity_Vector.Direction > 270))
                    {
                        //Applying a simple rule:)
                        float a = BounceAngle + d;

                        //Swapping if nessecairy
                        if (BounceAngle > 270)
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
                float d = (float)GDD_Math.DeltaAngle(BounceAngle, obj2.Velocity_Vector.Direction);

                //The max bounce that can occur
                /*float Bounce_Max1 = BounceAngle + d;

//if obj2 != null
float Bounce_Max2 = obj1.Velocity_Vector.Direction;

float a = (Bounce_Max2 - Bounce_Max1) * force1Ratio;*/


                //Caculating the new angle for obj1
                obj2_NewVelocity = new GDD_Vector2F(obj1.Velocity_Vector.Direction, obj1.Velocity_Vector.Size);


            }
        }



    }


}
