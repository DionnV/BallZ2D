using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GDD_Library.Shapes;

namespace GDD_Library
{
    public class GDD_Scene
    {
        /// <summary>
        /// Initializes a new scene
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public GDD_Scene(int width, int height)
        {
            //Setting the width and the height to our own width and height
            this.Width = width;
            this.Height = height;

            this.GravityFactor = 9.81f * 100f;

            //Starting the physics computing
            //this.physicsTimer = new GDD_Timer();
            //this.physicsTimer.TickCap = 60;
            //this.physicsTimer.Tick += new EventHandler(physicsTimer_Tick);
           // this.physicsTimer.Start();


        }


        /// <summary>
        /// A list of GDD Objects in this scene
        /// </summary>
        public List<GDD_Object> Objects { get { return _Objects; } set { this._Objects = value; } }
        private List<GDD_Object> _Objects = new List<GDD_Object>();

        /// <summary>
        /// A list of GDD_Zones that can be used for no-draw, no gravity etc
        /// </summary>
        public List<GDD_Object> Zones{ get { return _Zones; } set { this._Zones = value; } }
        private List<GDD_Object> _Zones = new List<GDD_Object>();

        /// <summary>
        /// The width of the scene
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The Gravity Constant
        /// </summary>
        public float GravityFactor { get; set; }

        /// <summary>
        /// The height of the scene
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The background worker that handles all the physics related computing
        /// </summary>
        public GDD_Timer physicsTimer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void physicsTimer_Tick(object sender, EventArgs e)
        {
            /*foreach (GDD_Object obj in Objects)
            {
                obj.Location = new GDD_Point2F(obj.Location.x - 1f, obj.Location.y) ;
            }*/
        }

    }
}
