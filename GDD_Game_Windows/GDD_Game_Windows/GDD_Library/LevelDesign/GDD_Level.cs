using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.LevelDesign
{
    public class GDD_Level
    {
       
        public List<GDD_Object> Objects;
        public GDD_HeaderInfo info;
        public string Background { get; set; }
        public string progpath = "./Progress";
       
        
        /// <summary>
        /// Creates a .zip-file containing all the necessary files used for level design.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="loo"></param>
        /// <param name="info"></param>
        /// <param name="background"></param>
        public void WriteToZipFile()
        {
            //Serialize the List of GDD_Object to a binary file called Objects.bin
            GDD_IO.Serialize(progpath + "/Objects.bin", this.Objects);

            //Write the GDD_HeaderInfo to a binary file called LevelData.bin
            GDD_IO.WriteToFile(progpath + "/LevelData.bin", this.info);

            //Move the background picture to the folder we will zip
            //Only if we have a background, ofcourse
            if(GDD_IO.FileExists(this.Background))
            {
                GDD_IO.FileMove(this.Background, progpath);
            }

            //All the needed data is in the right folder now, let's zip it for distribution
            GDD_IO.Compress(progpath, "./Saved levels/Custom/" + info.LevelName + ".zip");
        }
    }
}
