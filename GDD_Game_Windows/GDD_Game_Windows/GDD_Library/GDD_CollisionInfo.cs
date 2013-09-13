using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library
{
    public class GDD_CollisionInfo
    {
        public GDD_Object obj1 { get; set; }
        public float obj1_CollisionAngle { get; set; }
 
        public GDD_Object obj2 { get; set; }
        public float obj2_CollisionAngle { get; set; }

        public float BounceAngle { get { return _BounceAngle; } set { this._BounceAngle = value; this.BounceAngle_low = (value > 180f) ? value - 180f : value; } }
        private float _BounceAngle;
        public float BounceAngle_low { get; set; }

    }
}
