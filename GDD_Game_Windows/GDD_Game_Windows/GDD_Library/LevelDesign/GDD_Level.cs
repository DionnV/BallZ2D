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
        public Bitmap NoDrawZone { get; set; }

        /// <summary>
        /// Loads a no draw zone from file
        /// </summary>
        /// <param name="url"></param>
        public void LoadNoDraw(String url)
        {
            NoDrawZone = new Bitmap(url);
        }

        /// <summary>
        /// Checks if a cirtain pixels is no draw zone
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsNoDrawZone(int x, int y)
        {
            //Getting color
            Color p = NoDrawZone.GetPixel(x, y);

            //max 10 pixel diff
            int Diff = Math.Abs(255 - p.R) + Math.Abs(100 - p.G) + Math.Abs(100 - p.B);

            if (Diff < 10)
            {
                return true;
            }
            return false;

        }


    }
}
