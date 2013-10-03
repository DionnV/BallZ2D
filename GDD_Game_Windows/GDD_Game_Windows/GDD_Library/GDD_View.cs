using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using GDD_Library.Shapes;

namespace GDD_Library
{
    public partial class GDD_View : UserControl
    {
        public GDD_View()
        {
            InitializeComponent();

            //Creating a view
            this.Scene = new GDD_Scene(this.Width, this.Height);

            //Create a new graphics timer
            graphicsTimer = new GDD_Timer();
            graphicsTimer.TickCap = 60;
            graphicsTimer.Tick += new EventHandler(graphicsTimer_Tick);        
        }

        ~GDD_View()
        {
            //Stop drawing
            graphicsTimer.Stop();
        }

        /// <summary>
        /// An acurate timer that ticks regularly
        /// </summary>
        public GDD_Timer graphicsTimer { get; set; }


        /// <summary>
        /// The GDD_Scene on which we are viewing
        /// </summary>
        public GDD_Scene Scene { get; set; }

        /// <summary>
        /// The Rectangle we are viewing
        /// </summary>
        public Rectangle ViewingRect { 
            get 
            {
                return _ViewingRect;
            }
            set
            {
                this._ViewingRect = value;
            }
        }
        private Rectangle _ViewingRect = new Rectangle();

        /// <summary>
        /// Painting all the objects on the scene
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Draw the realm
            //Repaint();
        }

        /// <summary>
        /// The tick even for the graphics timer; forces a new redraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void graphicsTimer_Tick(Object sender, EventArgs e)
        {
            Repaint();
            Application.DoEvents(); 
        }

        /// <summary>
        /// Repainting the scene on this view
        /// </summary>
        private void Repaint()
        {
            //We can only continue if we have a scene
            if (this.Scene == null)
            {
                return;
            }

            //Creating a bitmap
            Bitmap b = new Bitmap(this.Width, this.Height);

            //Creating graphics
            Graphics g = Graphics.FromImage(b);

            //Filling it
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, this.Width, this.Height));

            //Drawing Background image
            if (this.BackgroundImage != null)
            {
                
                //g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height), new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height), GraphicsUnit.Pixel);
            }

            //Drawing the zones
            foreach (GDD_Object zone in Scene.Zones)
            {
                zone.Shape.Draw(g);
            }

           
            //Drawing FPS
            g.DrawString("FPS: " + this.graphicsTimer.TPS, new Font("Ariel", 10), new SolidBrush(Color.Black), new PointF(0, 0));

            //Calculating some constatns
            //float Deg2Rad = 0.0174532925f;

            List<GDD_Object> CollisionExceptions = new List<GDD_Object>();

            //Looping each thing
            for (int i = 0; i < this.Scene.Objects.Count; i++)
            {

                if (graphicsTimer.CancellationPending)
                {
                    return;
                }

                GDD_Object obj = this.Scene.Objects[i];

                //We only apply gravity when its gravity type is normal
                if (obj.GravityType == GDD_GravityType.Normal)
                {
                    //Doing a calculation for when to 
                    float t = graphicsTimer.TickTime;
                    if (t == 0) { t = graphicsTimer.DesiredTickTime; }
                    float d = t / 1000;

                    //Applying angulair momentum
                    obj.Rotation = new GDD_Vector2F(obj.Rotation.Direction + (obj.Rotation.Size * 360f) * d, obj.Rotation.Size);

                    //Applying gravity
                    obj.Velocity = new GDD_Point2F(obj.Velocity.x, obj.Velocity.y + (this.Scene.GravityFactor * d));

                    //Determining the end location
                    obj.Desired_Location = new GDD_Point2F(obj.Location.x + (obj.Velocity.x * d), obj.Location.y + (obj.Velocity.y * d));

                    //List of collision
                    List<GDD_CollisionInfo> Collisions = new List<GDD_CollisionInfo>();

                    //Filing the list of objects that we collide with
                    for (int j = 0; j < this.Scene.Objects.Count; j++)
                    {
                        GDD_Object obj1 = this.Scene.Objects[j];

                        if (!this.Scene.Objects[j].CanLeaveScene)
                        {
                            //Can't leave scene, colliding with borders
                            //this.Scene.Objects[j].Shape.Collides(SouthBorder)
                            //this.Scene.Objects[j].Shape.Collides(SouthBorder)
                            //this.Scene.Objects[j].Shape.Collides(SouthBorder)
                            //this.Scene.Objects[j].Shape.Collides(SouthBorder)
                        }

                        if (!CollisionExceptions.Contains(obj1))
                        {
                            //Calculating the collision
                            GDD_CollisionInfo collision = GDD_Shape.Collides(obj.Shape, obj1.Shape);

                            //Did we have a collision
                            if (collision != null)
                            {
                                //Adding a collision
                                Collisions.Add(collision);
                            }
                        }
                    }

                    //Checking for collisions
                    if (Collisions.Count > 0)
                    {   
                        //Do we have more than 1 collision?
                        if (Collisions.Count > 1)
                        {
                            //Sorting the collisions by distance to collision
                            Collisions = Collisions.OrderBy(c => c.DistanceToCollision).ToList();                                   
                        }

                        //Applying the collision with the closest object
                        GDD_CollisionInfo collision = Collisions[0];

                        //The true bounce angle
                        float ba = GDD_Math.Loop(collision.BounceAngle, -180f, 180f);
                        if (collision.obj1_AfterCollision.Velocity_Vector.Direction < 0f)
                        {
                            ba = -180f + collision.BounceAngle;
                        }

                        //Delta angle between BounceAngle and object1's direction
                        float dAngle = GDD_Math.DeltaAngle(collision.obj1_AfterCollision.Velocity_Vector.Direction, ba);

                        //Checking if the velocity is too low and the new velocity is pointing upwards
 /*                       if (((collision.obj1_AfterCollision.Velocity_Vector.Size < 40f) && (GDD_Math.DeltaAngle(collision.obj1_AfterCollision.Velocity_Vector.Direction, 0f) < 90f)) || (dAngle < 5f))
                        {
                            //Addapting movement to ba(the true BounceAngle), with the correct size
                            //Getting the inverse angle of the true bounce angle
                            
                            float ba_inf = (ba < 0) ? GDD_Math.Angle(ba - 90f) : GDD_Math.Angle(ba + 90f);
                            ba_inf = GDD_Math.Loop(ba_inf, -180f, 180f);
                            dAngle = GDD_Math.DeltaAngle(180f, ba_inf);
                            float Speed = (float)Math.Sin(dAngle * GDD_Math.RadConverter) * (collision.obj1.Mass * this.Scene.GravityFactor);
                            float r = (collision.obj1_AfterCollision.Velocity_Vector.ToDXDY().x < 0) ? -1 : 1;

                            //float Speed = (float)Math.Sqrt(Math.Pow(this.Scene.GravityFactor, 2) - Math.Pow(collision.obj1.Mass, 2));
                            collision.obj1_AfterCollision .Velocity_Vector= new GDD_Vector2F(ba, Speed / 100);

                            //Making the rotation
                            collision.obj1_AfterCollision.Rotation = new GDD_Vector2F(
                                collision.obj1.Rotation.Direction,
                                r * (collision.obj1_AfterCollision.Velocity_Vector.Size / ((float)Math.PI * collision.obj1.Shape.Size)
                                ));                           
                        }*/


                        //Applying obj2 new velocity
                        collision.obj2.Velocity_Vector = collision.obj2_AfterCollision.Velocity_Vector;

                        //Applying the new rotation
                        collision.obj1.Rotation = collision.obj1_AfterCollision.Rotation;
                        collision.obj1.Velocity_Vector = collision.obj1_AfterCollision.Velocity_Vector;

                        //Determining the end location
                        collision.obj1.Location = new GDD_Point2F(obj.Location.x + (obj.Velocity.x * d), obj.Location.y + (obj.Velocity.y * d));

                        //Is the object now laying still?
                        if (collision.obj1_AfterCollision.Velocity_Vector.Size == 0f)
                        {
                            collision.obj1.GravityType = GDD_GravityType.Still;
                        }

                        //We've collided, raising the event
                        collision.obj1.RaiseOnCollision(collision.obj1, EventArgs.Empty);
                        collision.obj2.RaiseOnCollision(collision.obj2, EventArgs.Empty);

                        //We haven't bounced yet
                        collision.obj1.MaxVelocitySinceLastBounce = 0;

                        //We've collided, adding object 2 to the exceptions list
                        CollisionExceptions.Add(collision.obj2);
                    }
                    else
                    {
                        //Adding the delta distance to the location, because we haven't colided
                        obj.Location = obj.Desired_Location;
                    }
                }

                //Drawing
                obj.Shape.Draw(g);
            }
            if (this != null)
            {

                //Creating own graphics
                Graphics g2 = this.CreateGraphics();

                //Drawing the bitmap onto us
                g2.DrawImage(b, new Point(0, 0));

                g.Dispose();
                g2.Dispose();
                b.Dispose();
            }

        }
    }
}
