using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library.LevelDesign
{
    /// <summary>
    /// This class will create a GDD_HeaderInfo object, which holds info used for creating levels.
    /// </summary>
    public class GDD_HeaderInfo
    {
        /// <summary>
        /// Creates a constructor.
        /// </summary>
        public GDD_HeaderInfo()
        {
            //Default index of the ball in the list of objects.
            Index_Ball = 0;

            //Default index of the bucket in the list of objects.
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

        /// <summary>
        /// The highscore
        /// </summary>
        public int Highscore { get; set; }

        /// <summary>
        /// The location of the level.
        /// </summary>
        public String FileLocation { get; set; }

        /// <summary>
        /// And int array to indicate which medal is won
        /// </summary>
        public int[] Medals { get; set; }

        /// <summary>
        /// The amount of medals in the medal array
        /// </summary>
        public int MedalsAmount { get; set; }

        /// <summary>
        /// The amount for medals achieved in the level.
        /// </summary>
        public int MedalsAchieved { get; set; }
    }
}
