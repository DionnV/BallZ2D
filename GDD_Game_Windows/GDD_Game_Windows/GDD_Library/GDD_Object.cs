﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDD_Library.Shapes;
using System.Runtime.Serialization;

namespace GDD_Library
{
    [Serializable]
    public class GDD_Object : ISerializable, ICloneable
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

        public GDD_Object(SerializationInfo info, StreamingContext context)
        {

            Mass = (float) info.GetValue("Mass", typeof(float));
            Shape = (GDD_Shape) info.GetValue("Shape", typeof(GDD_Shape));
            Location = (GDD_Point2F) info.GetValue("Location", typeof(GDD_Point2F));
            Rotation = (GDD_Vector2F) info.GetValue("Rotation", typeof(GDD_Vector2F));
            GravityType = (GDD_GravityType) info.GetValue("GravityType", typeof(GDD_GravityType));
            CanLeaveScene = (bool) info.GetValue("CanLeaveScene", typeof(bool));
            Velocity = (GDD_Point2F) info.GetValue("Velocity", typeof(GDD_Point2F));
        }

        /// <summary>
        /// Will return a clone of this instance
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            //Gets a shallow Clone
            GDD_Object result = (GDD_Object)this.MemberwiseClone();

            //Cloning the shape ( this will set the owner )
            result.Shape = (GDD_Shape)this.Shape.Clone();

            //We're done
            return result;
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
                /*if (MaxVelocitySinceLastBounce < _Velocity_Vector.Size)
                {
                    MaxVelocitySinceLastBounce = _Velocity_Vector.Size;
                }*/
                return _Velocity_Vector;
            }
            set
            {          
                //Getting a DXDY from the vector
                this._Velocity = value.ToDXDY();
                this._Velocity_Vector = value;                
            }
        }
        private GDD_Vector2F _Velocity_Vector;

        /// <summary>
        /// 
        /// </summary>
        public float MaxVelocitySinceLastBounce = 0f;

        //Velocity defined as dX and dY
        public GDD_Point2F Velocity
        {
            get
            { 
                return _Velocity; 
            }
            set 
            {
                this._Velocity = value;
                this._Velocity_Vector = value.ToVector();             
            }
        }

        private GDD_Point2F _Velocity = new GDD_Point2F(0f, 0f);

        /// <summary>
        /// The force (Mass * Speed)
        /// </summary>
        public float Force { get { return this.Mass * this.Velocity_Vector.Size; } }

        /// <summary>
        /// The rotation
        /// </summary>
        public GDD_Vector2F Rotation 
        { 
            get 
            { 
                return this._Rotation; 
            } 
            set 
            {

                this._Rotation = value;
            } 
        }
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
        /// The desired location, for collision detection
        /// </summary>
        public GDD_Point2F Desired_Location { get; set; }

        /// <summary>
        /// The font color of the object
        /// </summary>
        public Color FrontColor { get { return this._FrontColor; } set { this._FrontColor = value; this._FrontPen = new Pen(new SolidBrush(this._FrontColor), 2); } }
        private Color _FrontColor = Color.Black;

        /// <summary>
        /// The frontpen used for drawing
        /// </summary>
        public Pen FrontPen { get { return _FrontPen; } 
            set {
                this._FrontPen = value; 
               } }
        private Pen _FrontPen = new Pen(new SolidBrush(Color.Black),2);

        /// <summary>
        /// The gravity Type
        /// </summary>
        public GDD_GravityType GravityType { get { return this._GravityType; } set { this._GravityType = value; if (value == GDD_GravityType.Static) { this.Desired_Location = this.Location; } } }
        private GDD_GravityType _GravityType = GDD_GravityType.Normal;

        /*public Boolean IsInZone(GDD_Zone zone)
        {
            Rectangle rec = new Rectangle((int)zone.Location.x, (int)zone.Location.y, (int)zone.Width, (int)zone.Height);
            if(rec.Contains((int)this.Desired_Location.x, (int)this.Desired_Location.y))
            {
                return true;
            }
            return false;
        }*/

        public override string ToString()
        {
            return "Location " + this.Location.ToString("0.00") + " Velocity " + this.Velocity_Vector.ToString("0.00") + " Rotation " + this.Rotation.ToString("0.00");
        }

        /// <summary>
        /// Will be raised whenever this objects collides
        /// </summary>
        public event CollisionHandler OnCollision;

        public event OutOfSceneHandler outOfSceneEvent;

        /// <summary>
        /// Will raise the OnCollision event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RaiseOnCollision(object sender, CollisionEventArgs e)
        {
            if (OnCollision != null)
            {
                OnCollision(sender, e);
            }
        }

        public void RaiseOnOutOfScene(object sender)
        {
            if (outOfSceneEvent != null)
            {
                outOfSceneEvent(sender);
            }
        }

        /// <summary>
        /// This method is called on serialization.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Mass", Mass, typeof(float));
            info.AddValue("Shape", Shape, typeof(GDD_Shape));
            info.AddValue("Location", Location, typeof(GDD_Point2F));
            info.AddValue("Rotation", Rotation, typeof(GDD_Vector2F));
            info.AddValue("GravityType", GravityType, typeof(GDD_GravityType));
            info.AddValue("CanLeaveScene", CanLeaveScene, typeof(bool));
            info.AddValue("Velocity", Velocity, typeof(GDD_Point2F));
        }
    }

    public enum GDD_GravityType
    {
        Static,
        Normal,
        Still
    }

    public delegate void CollisionHandler(object sender, CollisionEventArgs e);
    public delegate void OutOfSceneHandler(object sender);

    public class CollisionEventArgs : EventArgs
    {
        public GDD_CollisionInfo CollsionInfo;
    }
}
