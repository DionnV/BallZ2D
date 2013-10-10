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

        /// <summary>
        /// The path to the progressing map. This should be left unchanged.
        /// </summary>
        private string progpath = "./Progress";
            
        /// <summary>
        /// Creates a .zip-file containing all the necessary files used for level design.
        /// </summary>
        public void WriteToZipFile()
        {
            //Serialize the List of GDD_Object to a binary file called Objects.bin
            GDD_IO.Serialize(progpath + "/Objects.bin", this.Objects);

            //Write the GDD_HeaderInfo to a binary file called LevelData.bin
            GDD_IO.WriteToFile(progpath + "/LevelData.bin", this.info);

            //All the needed data is in the right folder now, let's zip it for distribution
            GDD_IO.Compress(progpath, "./Saved levels/Custom/" + info.LevelName + ".zip");
        }
    }
}
