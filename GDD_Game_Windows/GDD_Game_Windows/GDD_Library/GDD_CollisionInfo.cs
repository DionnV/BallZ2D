using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDD_Library.Shapes;

namespace GDD_Library
{
    /// <summary>
    /// This class will hold the intelligence of colliding objects.
    /// </summary>
    public class GDD_CollisionInfo
    {
        //Creates a new instance of the 
        public GDD_CollisionInfo(GDD_Object obj1, GDD_Object obj2)
        {
            //Setting Obj1 and Obj1 after collision
            this.obj1 = obj1;
            this.obj1_AfterCollision = (GDD_Object)obj1.Clone();
            this.obj2 = obj2;
            this.obj2_AfterCollision = (GDD_Object)obj2.Clone();
        }

        /// <summary>
        /// The first GDD_Object that collides
        /// </summary>
        public GDD_Object obj1 { get; set; }

        /// <summary>
        /// The first GDD_Object that collides, with new values
        /// </summary>
        public GDD_Object obj1_AfterCollision { get; set; }

        /// <summary>
        /// The Euclidian Distance between the 2 objects
        /// </summary>
        public float DistanceToCollision { get; set; }

        /// <summary>
        /// The second GDD_Object that collides
        /// </summary>
        public GDD_Object obj2 { get; set; }

        /// <summary>
        /// The second GDD_Object that collides, with new values
        /// </summary>
        public GDD_Object obj2_AfterCollision { get; set; }

        /// <summary>
        /// The angle relative to the bounce angle
        /// </summary>
        public float obj1_CollisionAngle { get; set; }
         
        /// <summary>
        /// The angle relative to the bounce angle
        /// </summary>
        public float obj2_CollisionAngle { get; set; }
         
        /// <summary>
        /// The line the objects will collide with
        /// </summary>
        public float BounceAngle { get { return _BounceAngle; } set { this._BounceAngle = value; this.BounceAngle_low = (value > 180f) ? value - 180f : value; } }
        private float _BounceAngle;
        public float BounceAngle_low { get; set; }

        /// <summary>
        /// Returns Info about a collision between GDD_Shapes
        /// </summary>
        /// <param name="circle">The first circle.</param>
        /// <param name="circle2">The second circle.</param>
        /// <returns>A GDD_CollisionInfo object containing all collision data.</returns>
        public static GDD_CollisionInfo get(GDD_Circle circle, GDD_Circle circle2)
        {
            //Calculating the euclidian distance
            double Distance = GDD_Math.EuclidianDistance(circle.Owner.Desired_Location, circle2.Owner.Desired_Location);

            //Doing some calculations
            if ((Distance < ((circle.Size + circle2.Size) / 2f)) && (circle != circle2))
            {
                //Creating collisionInfo
                GDD_CollisionInfo result = new GDD_CollisionInfo(circle.Owner, circle2.Owner);

                //Getting bounce angle
                result.GetBounceAngle();

                //Letting obj1 collide
                result.obj1VSBounceAngle();              

                //Colliding obj2
                result.obj2VSBounceAngle();

                 //Returning the Collision Info
                return result;
            }

            //Aparently we don't collide
            return null;
        }

        /// <summary>
        /// Returns Info about a collision between GDD_Shapes,
        /// </summary>
        /// <param name="circle">The circle.</param>
        /// <param name="circle2">The polygon.</param>
        /// <returns>A GDD_CollisionInfo object containing all collision data.</returns>
        public static GDD_CollisionInfo get(GDD_Circle circle, GDD_Polygon polygon)
        {
            //A list of collisions
            List<GDD_CollisionInfo> Collisions = new List<GDD_CollisionInfo>();
            
            //A list of lines
            GDD_Object[] Lines = polygon.TranslatePolygon_ToLines();

            //Looping all the points, making lines and collisions
            for (int i = 0; i < Lines.Count(); i++)
            {
                //Looking for collision
                GDD_CollisionInfo Collision = get(circle, (GDD_Line)Lines[i].Shape);

                //Adding a collision!
                if (Collision != null)
                {
                    Collisions.Add(Collision);
                }
            }

            //To track which line is the closest
            int Closest_i = -1;
            float Closest_dst = -1f;

            //Returning the closest Line of which to collide with
            for (int i = 0; i < Collisions.Count(); i++)
            {
                if (Collisions[i] != null)
                {
                    if (Closest_i == -1)
                    {
                        Closest_i = i;
                        Closest_dst = (float)GDD_Math.EuclidianDistance(Collisions[i].obj1.Desired_Location, Collisions[i].obj2.Desired_Location);
                    }
                    else
                    {
                        float dst = (float)GDD_Math.EuclidianDistance(Collisions[i].obj1.Desired_Location, Collisions[i].obj2.Desired_Location);

                        if (dst < Closest_dst)
                        {
                            Closest_i = i;
                            Closest_dst = dst;
                        }
                    }
                }
            }

            //Looking for the clostest collision and returning it
            if (Closest_i != -1)
            {
                //TODO: check if the collision is actually occuring
                Collisions[Closest_i].obj2 = polygon.Owner;

                return Collisions[Closest_i];
            }

            //If we have not found any collisions, returning null
            return null;
        }

        /// <summary>
        /// Returns Info about a collision between GDD_Shapes,
        /// </summary>
        /// <param name="circle">The circle.</param>
        /// <param name="circle2">The line.</param>
        /// <returns>A GDD_CollisionInfo object containing all collision data.</returns>
        public static GDD_CollisionInfo get(GDD_Circle circle, GDD_Line line)
        {            
            GDD_Point2F line_end = line.end;
            float start_to_circle = (float)GDD_Math.EuclidianDistance(line.Owner.Location, circle.Owner.Desired_Location);
            float end_to_circle = (float)GDD_Math.EuclidianDistance(line_end, circle.Owner.Desired_Location);
                        
            float dx;
            float dy;
            
            if (line.Owner.Rotation.Direction > 180f)
            {
                dx = line.Owner.Location.x - line_end.x;
                dy = line.Owner.Location.y - line_end.y;
            }
            else
            {
                dx = line_end.x - line.Owner.Location.x;
                dy = line_end.y - line.Owner.Location.y;
            }
            float dxdy = dy / dx;

            //2 Function that will detect collision
            GDD_Point2F func1;
            GDD_Point2F func2;

            //Rotation
            float rot = GDD_Math.Angle(line.Owner.Rotation.Direction);

            if (rot == 90f)
            {
                func1 = GDD_Math.DXDYToFunc(0, line.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(1000, circle.Owner.Desired_Location);
            }
            else if (rot == 270f)
            {
                func1 = GDD_Math.DXDYToFunc(0, line.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(-1000, circle.Owner.Desired_Location);             
            }
            else if (rot == 180f)
            {
                func1 = GDD_Math.DXDYToFunc(-1000, line.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(0, circle.Owner.Desired_Location);
            }
            else if (rot == 0f)
            {
                func1 = GDD_Math.DXDYToFunc(1000, line.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(0, circle.Owner.Desired_Location);
            }
            else
            {
                func1 = GDD_Math.DXDYToFunc(dxdy, line.Owner.Location);
                func2 = GDD_Math.DXDYToFunc(-1 / dxdy, circle.Owner.Desired_Location);
            }

            //Calculating the intersection of the 2 lines
            GDD_Point2F intersection = GDD_Math.Intersection(func1, func2);

            //Calculating the euclidian Distance to the collision
            float eud = (float)GDD_Math.EuclidianDistance(intersection, circle.Owner.Desired_Location);
            
            //If the distance to the collision closer than half of the cirlce
            if (eud < (circle.Size / 2F))
            {
                //We might be colliding
                GDD_CollisionInfo result = null;

                if (
                        (
                            (
                                (rot == 0f) || (rot == 180f)
                            ) 
                            && 
                            (
                                (intersection.y > Math.Min(line.Owner.Location.y, line_end.y)) &&
                                (intersection.y < Math.Max(line.Owner.Location.y, line_end.y)) 
                            )
                        )
                    || 
                        (                       
                            (intersection.x > Math.Min(line.Owner.Location.x, line_end.x)) && 
                            (intersection.x < Math.Max(line.Owner.Location.x, line_end.x))
                            
                        )
                    )
                {

                //Colliding with the point or a line?
                //if ((intersection.x > Math.Min(line.Owner.Location.x, line_end.x)) && (intersection.x < Math.Max(line.Owner.Location.x, line_end.x)))
                //{
                    //We're colliding with the line
                    result = new GDD_CollisionInfo(circle.Owner, line.Owner);

                    //Rotation remains the same
                    result.obj1_AfterCollision.Rotation = circle.Owner.Rotation;
                    
                    //Calculatint the a new bounceangle
                    result.BounceAngle = line.Owner.Rotation.Direction % 360f;

                    if ((line.Owner.Rotation.Direction == 180f) || (line.Owner.Rotation.Direction == 0f))
                    {
                    }

                    //Calculating the distance to a the point of collision
                    result.DistanceToCollision = eud;
                      
                }
                else
                {
                    float eud_start = (float)GDD_Math.EuclidianDistance(line.Owner.Location, circle.Owner.Desired_Location);
                    float eud_end = (float)GDD_Math.EuclidianDistance(line_end, circle.Owner.Desired_Location);

                    //Are we colliding with a point
                    if (((eud_start) < (circle.Size / 2f)) || ((eud_end) < (circle.Size / 2f)))
                    {
                        //We're definately colliding with a point, assuming its the start
                        GDD_Point2F collisionPoint = line.Owner.Location;

                        //We're colliding
                        result = new GDD_CollisionInfo(circle.Owner, line.Owner);

                        //If the distance to end point is shorter; then we're colliding with the end point
                        if (eud_end < eud_start)
                        {
                            collisionPoint = line_end;
                        }

                        //We're Colliding with the start
                        GDD_Vector2F vec = new GDD_Point2F(collisionPoint.x - circle.Owner.Desired_Location.x, collisionPoint.y - circle.Owner.Desired_Location.y).ToVector();
                        result.BounceAngle = vec.Direction - 90f;

                        //Calculating the distance to a the point of collision
                        result.DistanceToCollision = (float)GDD_Math.EuclidianDistance(result.obj1.Desired_Location, collisionPoint);
                      
                    }
                }

                if (result != null)
                {                  
                    //Bouncing to the oppisite direction
                    result.obj1VSBounceAngle();         
                } 
                return result;
            }

            //We aren't colliding
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

        /// <summary>
        /// Letting obj1 collide with the BounceAngle
        /// </summary>
        private void obj1VSBounceAngle()
        {
            
            //The ratio of force from obj1
            float force1Ratio = obj1.Force / (obj1.Force + obj2.Force);

            //Applying the circle rules if obj1 is a circle
            if (obj1.Shape is GDD_Circle)
            {
                //D will hold the angle of impact for obj1
                float d = (float)GDD_Math.Delta(BounceAngle_low, obj1.Velocity_Vector.Direction) % 180f;

                //The max bounce that can occur
                float Bounce_Max1 = GDD_Math.Angle(BounceAngle + d);

                //Checking for static and null objects
                if ((obj2 == null) || (obj2.GravityType == GDD_GravityType.Static))
                {
                    //Normalizing the angles to 0..180;
                    /*float BA = BounceAngle % 180f;
                    float VA = obj1.Velocity_Vector.Direction % 90f;
                    float CA = 90f - VA;                  
                    obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(BA + 180f - CA, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);
                    */

                    if (obj1.Velocity_Vector.Direction < 90 || (obj1.Velocity_Vector.Direction > 270))
                    {
                        //Applying a simple rule:)
                        float a = GDD_Math.Angle(BounceAngle + d) ;

                        //Swapping if nessecairy
                        if (BounceAngle > 270) 
                        {
                            a = 360 - a;
                        }

                        //Another exception
                        if (BounceAngle == 180f)
                        {
                            a = d - 90f;
                        }

                        if (BounceAngle == 0f)
                        {
                            a = 360 - d;
                        }

                        //New velocity
                        obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(a, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);
                   }
                   else
                   {
                       //Applying a simple rule:)
                       float a = BounceAngle - d;

                      /* //Swapping if nessecairy
                       if (BounceAngle == 270)
                       {
                           a = a - 180;
                       }

                       //Another exception
                       if (BounceAngle == 180f)
                       {
                           a = BounceAngle + d;
                       }

                       if (BounceAngle == 0f)
                       {
                           a = 360 - d;
                       }

                       if (BounceAngle == 90f)
                       {

                       }
                     * 8
                     */
                        obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(a, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);
                                          
                   }
                    //Checking if obj1 has enough speed
                   /* if (Math.Abs(obj1_AfterCollision.Velocity_Vector.Size) < 50d)
                    {
                        obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(obj1_AfterCollision.Velocity_Vector.Direction, 0f);
                    }*/

                }
                else
                {
                    //float Bounce_Max2 = obj2.Velocity_Vector.Direction;

                    //float a = (Bounce_Max2 - Bounce_Max1) * force1Ratio;
                }
            }
        }

        /// <summary>
        /// Letting obj2 collide with the BounceAngle
        /// </summary>
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
                obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(obj1.Velocity_Vector.Direction, obj1.Velocity_Vector.Size);
            }
        }
    }
}
