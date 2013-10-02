using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDD_Library.Shapes;
using System.Windows.Forms;

namespace GDD_Library.LevelDesign
{
    public class ZipTest
    {     

        public static void run()
        {
            List<GDD_Object> loo = new List<GDD_Object>();
            //string background = "bg.png";
            GDD_HeaderInfo info = new GDD_HeaderInfo();

            GDD_Object obj1 = new GDD_Object(new GDD_Square());
            GDD_Object obj2 = new GDD_Object(new GDD_Square());

            loo.Add(obj1);
            loo.Add(obj2);

            info.VersionNumber = 1;
            info.MaxLineLenght = 1;
            info.LevelName = "LevelName";
            info.LevelVersionNumber = 9000;
            info.Level_Width = 600;
            info.Level_Height = 600;
            info.BackgroundName = "idk lol";
            info.CreatorName = "Dion ofc";

            //We've done this, it works.
            /*
            GDD_Level lev1 = new GDD_Level();
            lev1.WriteToZipFile("./Levels/", loo, info, background);

            //The writing works - now unzip it
            GDD_Level lev2 = new GDD_Level();

            lev2.CreateFromZipFile("./Saved levels/Levelname.zip");
            MessageBox.Show(lev2.info.CreatorName);
            MessageBox.Show(lev2.Objects[0].Shape.ToString());
            */
        }

    }
}
