﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GDD_Library.Shapes
{
    /// <summary>
    /// This class hold the intelligence to create a circle.
    /// </summary>
    [Serializable]
    public class GDD_Circle : GDD_Shape, ISerializable
    {
        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        { 
            //A few constants that we calculate with
            float Rad2Deg = 0.0174532925f;
            float LongSize = (float)(Math.Sqrt(2d) * this.Size);
            float Rotation = -Owner.Rotation.Direction + 180f;

            //Draw a circle
            G.FillEllipse(DrawingColor, Owner.Location.x - Size / 2f, Owner.Location.y - Size / 2f, Size, Size);
            G.DrawEllipse(Owner.FrontPen, Owner.Location.x - Size/2f, Owner.Location.y - Size/2f, Size, Size);
            
            //Calculating the end point for our direction line
            GDD_Point2F end = new GDD_Point2F(Math.Sin(Rotation * Rad2Deg) * this.Size/2f, Math.Cos(Rotation * Rad2Deg) * Size/2f);

            //Drawing a line to get its rotation better
            //G.DrawLine(Owner.FrontPen, Owner.Location.x, Owner.Location.y, Owner.Location.x + end.x, Owner.Location.y + end.y);
        }

        /// <summary>
        /// This method will run a check if a given point is in the circle.
        /// </summary>
        /// <param name="p">The point to check.</param>
        /// <returns>Whether the point is in the circle.</returns>
        public override bool ContainsPoint(GDD_Point2F p)
        {
            if ((p.x >= Owner.Location.x - (Size / 2f)) &&
                (p.x <= Owner.Location.x + (Size / 2f)) &&
                (p.y >= Owner.Location.y - (Size / 2f)) &&
                (p.y <= Owner.Location.y + (Size / 2f)))
            {
                //We are near the circle
                //Checking if we are in in
                float dx = Owner.Location.x - p.x;
                float dy = Owner.Location.y - p.y;
                dx *= dx;
                dy *= dy;
                float dist = dx + dy;
                float r = (Size / 2f) * (Size / 2f);
                return dist <= r;
            }
            return false;
        }

        /// <summary>
        /// The bounce rate, 0.6 by default
        /// </summary>
        public float RestitutionRate { get { return this._RestitutionRate; } set { _RestitutionRate = value;  } }
        private float _RestitutionRate = 0.6f;

        /// <summary>
        /// This method will be called by a serialize-method.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Size", Size, typeof(float));
            info.AddValue("RestitutionRate", _RestitutionRate, typeof(float));
        }

        /// <summary>
        /// Constructor which is called by a deserialize-method.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public GDD_Circle(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Size = (float) info.GetValue("Size", typeof(float));
            _RestitutionRate = (float)info.GetValue("RestitutionRate", typeof(float));
        }

        /// <summary>
        /// An empty constructor.
        /// </summary>
        public GDD_Circle() { }
    }
}
