using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDD_Library.LevelDesign
{
    public class GDD_Level
    {
       
        public List<GDD_Object> Objects;
        public GDD_HeaderInfo info;
        public string Background { get; set; }
        private string progpath = "./Progress";
        
        /// <summary>
        /// Creates a .zip-file containing all the necessary files used for level design.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="loo"></param>
        /// <param name="info"></param>
        /// <param name="background"></param>
        public void WriteToZipFile()
        {
            bool background_exists = GDD_IO.FileExists(Background);
            //Serialize the List of GDD_Object to a binary file called Objects.bin
            GDD_IO.Serialize(progpath + "/Objects.bin", Objects);

            //Write the GDD_HeaderInfo to a binary file called LevelData.bin
            GDD_IO.WriteToFile(progpath + "/LevelData.bin", info);
           
            //Move the background picture to the folder we will zip
            //Only if we have a background, ofcourse
            if(background_exists) 
            {
                GDD_IO.FileMove(Background, progpath); 
            }

            //All the needed data is in the right folder now, let's zip it for distribution
            GDD_IO.Compress(progpath, "./Levels/Custom/" + info.LevelName + ".zip");

            //Delete the other files because they are now zipped
            GDD_IO.FileDelete(progpath + "/Objects.bin");
            GDD_IO.FileDelete(progpath + "/LevelData.bin");
        }       
    }
}
