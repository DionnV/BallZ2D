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

namespace GDD_Library
{
    public partial class GDD_View : UserControl
    {
        public GDD_View()
        {
            InitializeComponent();

            //Create a new graphics timer
            graphicsTimer = new GDD_Timer();
            graphicsTimer.TickCap = 60;
            graphicsTimer.Tick += new EventHandler(graphicsTimer_Tick);
            graphicsTimer.Start();
            
        }

        ~GDD_View()
        {
            //Stop drawing
            
        }

        /// <summary>
        /// An acurate timer that ticks regularly
        /// </summary>
        public GDD_Timer graphicsTimer { get; set; }


        /// <summary>
        /// The GDD_Scene on which we are viewing
        /// </summary>
        public GDD_Scene Scene
        {
            get
            {
                return _Scene;
            }
            set
            {
                this._Scene = value;
            }
        }
        private GDD_Scene _Scene = new GDD_Scene(100, 100);

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

        protected void graphicsTimer_Tick(Object sender, EventArgs e)
        {
            Repaint();
            Application.DoEvents(); 
        }

        float lowestSize = 1000f;

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
                    //
                    obj.IsRolling = false;

                    //Doing a calculation for when to 
                    float t = graphicsTimer.TickTime;
                    if (t == 0) { t = graphicsTimer.DesiredTickTime; }
                    float d = t / 1000;

                    //Applying angulair momentum
                    obj.Rotation = new GDD_Vector2F(obj.Rotation.Direction + (obj.Rotation.Size * 360f) * d, obj.Rotation.Size);

                    //Applying gravity
                    obj.Velocity = new GDD_Point2F(obj.Velocity.x, obj.Velocity.y + ((9.81f * 100) * d));
                   
                    //Determining the end location
                    obj.Desired_Location = new GDD_Point2F(obj.Location.x + (obj.Velocity.x * d), obj.Location.y + (obj.Velocity.y * d));

                    //List of collision
                    List<GDD_CollisionInfo> Collisions = new List<GDD_CollisionInfo>();

                    //Filing the list of objects that we collide with
                    for (int j = 0; j < this.Scene.Objects.Count; j++)
                    {
                        GDD_Object obj1 = this.Scene.Objects[j];

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
                        //The shortest is by default index 0
                        int shortest = 0;
                        float shortest_dst = (float)GDD_Math.EuclidianDistance(Collisions[shortest].obj1.Desired_Location, Collisions[shortest].obj2.Desired_Location);
                        float dst = 0f;

                        //Checking if we have any more shorterr
                        if (Collisions.Count > 1)
                        {
                            //We're only colliding with the closest object - finding it
                            for (int j = 1; j < Collisions.Count; j++)
                            {
                                //Calculating the new dst
                                dst = (float)GDD_Math.EuclidianDistance(Collisions[j].obj1.Desired_Location, Collisions[j].obj2.Desired_Location);

                                //Is it shorter?
                                if (dst < shortest_dst)
                                {
                                    shortest = j;
                                    shortest_dst = (float)GDD_Math.EuclidianDistance(Collisions[shortest].obj1.Desired_Location, Collisions[shortest].obj2.Desired_Location);
                                }
                            }
                        }



                        //Looping each collision
                        //foreach (GDD_CollisionInfo collision in Collisions)
                        // {
                        GDD_CollisionInfo collision = Collisions[shortest];

                        //Applying the direction of the objection
                        collision.obj1.Velocity_Vector = collision.obj1_NewVelocity;

                        if ((collision.obj1.MaxVelocitySinceLastBounce < 50) || collision.obj1_IsRolling)
                        {
                            //Are we rolling?
                            collision.obj1.IsRolling = true;

                            GDD_Vector2F vec = GDD_Math.DXDYToVector(new GDD_Point2F(obj.Velocity.x, obj.Velocity.y + ((9.81f * 100) * d)));

                            //Taking the 
                            collision.obj1.Velocity_Vector = new GDD_Vector2F(collision.obj1_NewVelocity.Direction, collision.obj1_NewVelocity.Size * 2f);            

                            //Determining the end location
                            collision.obj1.Location = new GDD_Point2F(obj.Location.x + (obj.Velocity.x * d), obj.Location.y + (obj.Velocity.y * d));

                        }
                        else
                        {
                            collision.obj2.Velocity_Vector = collision.obj2_NewVelocity;

                            //Applying the new rotation
                            collision.obj1.Rotation = collision.obj1_NewRotation;

                            //Determining the end location
                            collision.obj1.Location = new GDD_Point2F(obj.Location.x + (obj.Velocity.x * d), obj.Location.y + (obj.Velocity.y * d));

                            //Is the object now laying still?
                            if (collision.obj1_IsStill)
                            {
                                collision.obj1.GravityType = GDD_GravityType.Still;
                            }
                        }



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
