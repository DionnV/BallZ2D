using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDD_Library.Shapes;

namespace GDD_Library
{
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
                GDD_CollisionInfo result = new GDD_CollisionInfo(circle1.Owner, circle2.Owner);

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

   /*     public static GDD_CollisionInfo get(GDD_Circle circle, GDD_Bucket bucket)
        {
            //The arrays we need to work with
            GDD_Object[] Line = new GDD_Object[8];
            GDD_Vector2F[] Vector = new GDD_Vector2F[8];
            GDD_Point2F[] Points = new GDD_Point2F[8];
            List<GDD_CollisionInfo> Collisions = new List<GDD_CollisionInfo>();
            GDD_Vector2F Vec;

            //The vectors
            Vector[0] = new GDD_Vector2F(350.7539f, 61.61169f);
            Vector[1] = new GDD_Vector2F(356.872f, 53.8145f);
            Vector[2] = new GDD_Vector2F(259.0193f, 48.25971f);
            Vector[3] = new GDD_Vector2F(190.9807f, 48.25971f);
            Vector[4] = new GDD_Vector2F(93.01279f, 53.8145f);
            Vector[5] = new GDD_Vector2F(99.24611f, 61.61169f);
            Vector[6] = new GDD_Vector2F(190.008f, 61.03278f);
            Vector[7] = new GDD_Vector2F(259.992f, 61.03278f);

            //The vectors above are designed for a bucket of size 100
            float sizeFactor = bucket.Size / 100f;

            //Looping each vector, translating it to a point
            for (int i = 0; i<Vector.Count(); i++)
            {
                Vec = Vector[i];
                Vec = new GDD_Vector2F(Vec.Direction + (bucket.Owner.Rotation.Direction - 45f), Vec.Size * sizeFactor);
                Points[i] = Vec.ToDXDY();
                Points[i] = new GDD_Point2F(Points[i].x + bucket.Owner.Location.x, Points[i].y + bucket.Owner.Location.y);
            }
            
            //Looping all the points, making lines and collisions
            for (int i = 0; i<Points.Count(); i++)
            {
                //Making a line
                Line[i] = GDD_Line.Create(Points[i], Points[(i + 1) % 8]);

                //Looking for collision
                GDD_CollisionInfo Collision = get(circle, (GDD_Line)Line[i].Shape);
                
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


            if (Closest_i != -1)
            {
                Collisions[Closest_i].obj2 = bucket.Owner;
                return Collisions[Closest_i];
            }
            return null;
        }
        */
        public static GDD_CollisionInfo get(GDD_Circle circle1, GDD_Line line1)
        {                        
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

            GDD_Point2F intersection = GDD_Math.Intersection(func1, func2);

            float eud = (float)GDD_Math.EuclidianDistance(intersection, circle1.Owner.Desired_Location);
            
            if (eud < (circle1.Size / 2F))
            {
                //We might be colliding
                GDD_CollisionInfo result = null;

                //Colliding with the point or a line?
                if ((intersection.x > Math.Min(line1.Owner.Location.x, line_end.x)) && (intersection.x < Math.Max(line1.Owner.Location.x, line_end.x)))
                {
                    //We're colliding with the line
                    result = new GDD_CollisionInfo(circle1.Owner, line1.Owner);

                    //Rotation remains the same
                    result.obj1_AfterCollision.Rotation = circle1.Owner.Rotation;
                    
                    if (line1.Owner.Rotation.Direction < 0)
                    {
                        result.BounceAngle = line1.Owner.Rotation.Direction + 180f;
                    }
                    else
                    {
                        result.BounceAngle = line1.Owner.Rotation.Direction % 360f;
                    }
                }
                else
                {
                    float eud_start = (float)GDD_Math.EuclidianDistance(line1.Owner.Location, circle1.Owner.Desired_Location);
                    float eud_end = (float)GDD_Math.EuclidianDistance(line_end, circle1.Owner.Desired_Location);

                    //Are we colliding with a point
                    if (((eud_start + 1) < (circle1.Size / 2f)) || ((eud_end+1) < (circle1.Size / 2f)))
                    {
                        //We're definately colliding with a point, assuming its the start
                        GDD_Point2F collisionPoint = line1.Owner.Location;

                        //We're colliding
                        result = new GDD_CollisionInfo(circle1.Owner, line1.Owner);

                        //If the distance to end point is shorter; then we're colliding with the end point
                        if (eud_end < eud_start)
                        {
                            collisionPoint = line_end;
                        }

                        //We're Colliding with the start
                        GDD_Vector2F vec = new GDD_Point2F(collisionPoint.x - circle1.Owner.Desired_Location.x, collisionPoint.y - circle1.Owner.Desired_Location.y).ToVector();
                        result.BounceAngle = vec.Direction - 90f;   
                      
                    }
                }

                if (result != null)
                {                   
                    result.obj1VSBounceAngle();           
                } 
                return result;
            }

            //We aren't colliding
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

                        //New velocity
                        obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(a, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);
                    }
                    else
                    {
                        obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(BounceAngle - d, obj1.Velocity_Vector.Size * ((GDD_Circle)obj1.Shape).RestitutionRate);
                    
                    }

                    //Checking if obj1 has enough speed
                    /*Iif (Math.Abs(obj1_AfterCollision.Velocity_Vector.Size) < 10d)
                    {
                        obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(obj1_AfterCollision.Velocity_Vector.Direction, 0f);
                    }*/

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
                obj1_AfterCollision.Velocity_Vector = new GDD_Vector2F(obj1.Velocity_Vector.Direction, obj1.Velocity_Vector.Size);


            }
        }

    }


}
