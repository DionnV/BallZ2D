using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library.LevelDesign
{
    public class GDD_HeaderInfo
    {
        /// <summary>
        /// Creates a constructor.
        /// </summary>
        public GDD_HeaderInfo()
        {
            Index_Ball = 0;
            Index_Bucket = 1;
        }
        /// <summary>
        /// The version number of the game.
        /// </summary>
        public int VersionNumber { get; set; }

        /// <summary>
        /// The version number of the level.
        /// </summary>
        public int LevelVersionNumber { get; set; }

        /// <summary>
        /// The name of the level.
        /// </summary>
        public String LevelName { get; set; }

        /// <summary>
        /// The width of the level.
        /// </summary>
        public int Level_Width { get; set; }

        /// <summary>
        /// The height of the level.
        /// </summary>
        public int Level_Height { get; set; }

        /// <summary>
        /// The maximum lenght of the lines drawed. Will be -1 if infinity.
        /// </summary>
        public int MaxLineLenght { get; set; }

        /// <summary>
        /// The index of the ball in the list of objects.
        /// </summary>
        public int Index_Ball { get; set; }

        /// <summary>
        /// The index of the bucket in the list of objects.
        /// </summary>
        public int Index_Bucket { get; set; }

        /// <summary>
        /// The name of the creator.
        /// </summary>
        public String CreatorName { get; set; }
    }
}
