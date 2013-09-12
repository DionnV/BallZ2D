using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library
{
    public abstract class GDD_Shape
    {
       public abstract void Draw(Graphics G);

        /// <summary>
        /// The size of this Square
        /// </summary>
        public float Size { get { return _Size; } set { this._Size = value; } }
        private float _Size = 1f;

        /// <summary>
        /// The Owner of this shape
        /// </summary>
        public GDD_Object Owner { get { return _Owner; } set { this._Owner = value; } }
        private GDD_Object _Owner;
    }
}
