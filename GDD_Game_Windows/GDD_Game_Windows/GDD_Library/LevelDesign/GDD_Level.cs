using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.LevelDesign
{
    /// <summary>
    /// This class will hold all the necessary items which are used to create a level.
    /// </summary>
    public class GDD_Level
    {
        /// <summary>
        /// The list of objects used for creating the level
        /// </summary>   
        public List<GDD_Object> Objects;

        /// <summary>
        /// The info used for creating the level.
        /// </summary>
        public GDD_HeaderInfo info;
      
    }
}
