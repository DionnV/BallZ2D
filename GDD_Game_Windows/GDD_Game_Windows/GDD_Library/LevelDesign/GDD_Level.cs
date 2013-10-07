using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.LevelDesign
{
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
        /// The path to the background used for the level.
        /// </summary>
        public string Background { get; set; }

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

            //Move the background picture to the folder we will zip.
            //Only if a background exists.
            if(GDD_IO.FileExists(this.Background))
            {
                GDD_IO.FileMove(this.Background, progpath);
            }

            //All the needed data is in the right folder now, let's zip it for distribution
            GDD_IO.Compress(progpath, "./Saved levels/Custom/" + info.LevelName + ".zip");
        }
    }
}
