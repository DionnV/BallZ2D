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

            //Looping each thing
            for (int i = 0; i < this.Scene.Objects.Count; i++)
            {
                GDD_Object obj = this.Scene.Objects[i];

                if (obj.GravityType == GDD_GravityType.Normal)
                {

                    //Doing a calculation for when to 
                    float t = graphicsTimer.TickTime;
                    if (t == 0) { t = graphicsTimer.DesiredTickTime; }
                    float d = t / 1000;

                    //
                    float LongSize = (float)(Math.Sqrt(2d) * obj.Velocity.Size);

                    //Applying angulair momentum
                    obj.Rotation = new GDD_Vector2F(obj.Rotation.Direction + (obj.Rotation.Size * 360f) * d, obj.Rotation.Size);

                    //Applying gravity
                    obj.Velocity2 = new GDD_Point2F(obj.Velocity2.x, obj.Velocity2.y + (9.81f * d));

                    //Determining the new delta distance
                    GDD_Point2F end = new GDD_Point2F(obj.Velocity2.x, obj.Velocity2.y);

                    //Determining the end location
                    GDD_Point2F end_location = new GDD_Point2F(obj.Location.x + end.x, obj.Location.y + end.y);

                    //Determining the the object will be out of the scene
                    //if (end_location.x

                    List<GDD_Object> Collisions = (from obj1 in this.Scene.Objects
                            where GDD_Shape.Collides(obj.Shape, obj1.Shape) != null
                            select obj1).ToList<GDD_Object>();

                    if (Collisions.Count > 0)
                    {
                        MessageBox.Show("COLLISION");
                    }

                    //Adding the delta distance to the location
                    obj.Location = end_location;
                    obj.Shape.Draw(g);
                }
            }

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
