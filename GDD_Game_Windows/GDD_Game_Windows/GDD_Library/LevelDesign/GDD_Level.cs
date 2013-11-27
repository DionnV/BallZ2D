using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

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
        /// This method will create a GDD_Level given a folder. This folder should contain
        /// at least two files called Objects.bin and LevelData.bin. It may also contain a .jpeg-file
        /// called background.jpeg.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns>A GDD_Level object.</returns>
        public static GDD_Level LoadFromFolder(string folder)
        {
            //Run a check whether the folder exists
            if (!Directory.Exists(folder))
            {
                throw new IncorrectFolderException();
            }
            //Create an empty level.
            GDD_Level lev = new GDD_Level();

            //Fill the leveldata using deserialization and reading the binary file.
            //Read the serialized file.
            lev.Objects = GDD_IO.Deserialize(folder + "/Objects.bin");

            //Read the binary file.
            lev.info = GDD_IO.ReadFromFile(folder + "/LevelData.bin");

            //Return the result.
            return lev;
        }
    }
}
