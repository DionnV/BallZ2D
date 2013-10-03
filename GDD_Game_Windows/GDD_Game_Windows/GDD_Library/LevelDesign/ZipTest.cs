using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDD_Library.Shapes;

namespace GDD_Library.LevelDesign
{
    public class ZipTest
    {     

        public static void run()
        {
            List<GDD_Object> loo = new List<GDD_Object>();
            string background = "bg.png";
            GDD_HeaderInfo info = new GDD_HeaderInfo();

            GDD_Object obj1 = new GDD_Object(new GDD_Square());
            GDD_Object obj2 = new GDD_Object(new GDD_Square());

            loo.Add(obj1);
            loo.Add(obj2);

            info.LevelName = "YOLOSWAG";
            info.LevelVersionNumber = 9000;
            info.Level_Width = 600;
            info.Level_Height = 600;
            info.BackgroundName = "idk lol";
            info.CreatorName = "Dion ofc";

            GDD_Level lev1 = new GDD_Level();
            lev1.WriteToZipFile("./Levels/", loo, info, background);


        }

    }
}
