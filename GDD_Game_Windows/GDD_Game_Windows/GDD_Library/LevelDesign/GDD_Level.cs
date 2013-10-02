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
        public Bitmap Background { get; set; }

        /// <summary>
        /// Checks if a cirtain pixels is no draw zone
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsNoDrawZone(int x, int y)
        {
            //This needs a rework

            /*
            //Getting color
            Color p = NoDrawZone.GetPixel(x, y);

            //max 10 pixel diff
            int Diff = Math.Abs(255 - p.R) + Math.Abs(100 - p.G) + Math.Abs(100 - p.B);

            if (Diff < 10)
            {
                return true;
            }
            */
            return false;
            
        }

        public void CreateFromZipFile(string zipfile)
        {
            //Create a path to unpack the levels to
            string path = "./Level";

            //Unzip the zip file
            GDD_IO.Decompress(zipfile, path);

            //The unzipped folder should contain a serialized file called Objects.bin.
            //We can't really read serialized files, so;
            this.Objects = GDD_IO.Deserialize(path + "/Objects.bin");

            //There is also a file called LevelData.bin which holds info about the level.
            //Let's read that one too.
            this.info = GDD_IO.ReadFromFile(path + "/LevelData.bin");

            //Lastly, we need a sexy background, which happens to be in the zipfile too.
            //However, if there is no background, we will make a white one.
            if(GDD_IO.FileExists(path + "/background.jpeg"))
            {
                this.Background = new Bitmap(path + "/background.jpeg");
            } 
            else 
            {
                this.Background = new Bitmap(info.Level_Width, info.Level_Height);

                //Making a white background
                using (Graphics graph = Graphics.FromImage(this.Background))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, this.Background.Width, this.Background.Height);
                    graph.FillRectangle(Brushes.White, ImageSize);
                }
            }
        }
        
        /// <summary>
        /// Creates a .zip-file containing all the necessary files used for level design.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="loo"></param>
        /// <param name="info"></param>
        /// <param name="background"></param>
        public void WriteToZipFile(string path, List<GDD_Object> loo, GDD_HeaderInfo info, string background)
        {
            //Serialize the List of GDD_Object to a binary file called Objects.bin
            GDD_IO.Serialize(path + "Objects.bin", loo);

            //Write the GDD_HeaderInfo to a binary file called LevelData.bin
            GDD_IO.WriteToFile(path + "LevelData.bin", info);

            //Move the background picture to the folder we will zip
            //Only if we have a background, ofcourse
            if(GDD_IO.FileExists(background))
            {
                //GDD_IO.FileMove(background, path);
            }

            //All the needed data is in the right folder now, let's zip it for distribution
            GDD_IO.Compress(path, path + "/" + info.LevelName + ".zip");
        }
    }
}
