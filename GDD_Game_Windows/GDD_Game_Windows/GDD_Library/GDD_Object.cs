using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDD_Library.Shapes;

namespace GDD_Library
{
    public class GDD_Object
    {
        /// <summary>
        /// Creating a new instance 
        /// </summary>
        /// <param name="Shape"></param>
        public GDD_Object(GDD_Shape Shape)
        {
            //Setting it's shape
            this.Shape = Shape;
        }

        /// <summary>
        /// Mass in Kg
        /// </summary>
        public float Mass { get { return this._Mass; } set { this._Mass = value; } }
        private float _Mass = 1f;

        /// <summary>
        /// The shape of this object
        /// </summary>
        public GDD_Shape Shape { get { return this._Shape;} set { this._Shape = value; this._Shape.Owner = this; }}
        private GDD_Shape _Shape = new GDD_Square();

        /// <summary>
        /// The velocity 
        /// </summary>
        public GDD_Vector2F Velocity_Vector
        {
            get
            {
                //Defining dir
                float dir = -1f;

                //Calculating the Direction of the first object
                if (this.Velocity.x == 0)
                {
                    if (Velocity.y > 0)
                    {
                        dir = 180f;
                    }
                    else
                    {
                        dir = 0f;
                    }
                }
                else
                {
                    
                    dir = (float)Math.Atan(this.Velocity.y / this.Velocity.x) / 0.0174532925f;

                    if (Velocity.x < 0)
                    {
                        dir -= 90;
                    }
                    else
                    {
                        dir += 90;
                    }  
                }
                
                //Calculating the size
                float size = (float)Math.Sqrt(this.Velocity.x * this.Velocity.x + this.Velocity.y * this.Velocity.y);

                //Returning the vector
                return new GDD_Vector2F((dir<0) ? (360f + dir):dir, size);

            }
        }

        //Velocity defined as dX and dY
        public GDD_Point2F Velocity { get; set; }

        /// <summary>
        /// The force (Mass * Speed)
        /// </summary>
        public float Force { get { return this.Mass * this.Velocity_Vector.Size; } }

        /// <summary>
        /// The rotation
        /// </summary>
        public GDD_Vector2F Rotation { get { return this._Rotation; } set { this._Rotation = value; } }
        private GDD_Vector2F _Rotation = new GDD_Vector2F(180f, 0f);

        /// <summary>
        /// Wether the obj can leave the screen. If true; it will be removed from memory when it does
        /// </summary>
        public Boolean CanLeaveScene { get; set; }

        /// <summary>
        /// The object's current location
        /// </summary>
        public GDD_Point2F Location { get { return this._Location; } set { this._Location = value; } }
        private GDD_Point2F _Location = new GDD_Point2F(0f, 0f);

        /// <summary>
        /// The font color of the object
        /// </summary>
        public Color FrontColor { get { return this._FrontColor; } set { this._FrontColor = value; this._FrontPen = new Pen(new SolidBrush(this._FrontColor)); } }
        private Color _FrontColor = Color.Black;

        /// <summary>
        /// The frontpen used for drawing
        /// </summary>
        public Pen FrontPen { get { return _FrontPen; }}
        private Pen _FrontPen = new Pen(new SolidBrush(Color.Black));

        /// <summary>
        /// The gravity Type
        /// </summary>
        public GDD_GravityType GravityType { get { return this._GravityType; } set { this._GravityType = value; } }
        private GDD_GravityType _GravityType = GDD_GravityType.Normal;

        public override string ToString()
        {
            return "{ Location " + this.Location.ToString() + " Velocity {" + this.Velocity_Vector.ToString() + " }";
        }
    }

    public enum GDD_GravityType
    {
        Static,
        Normal
    }
}
