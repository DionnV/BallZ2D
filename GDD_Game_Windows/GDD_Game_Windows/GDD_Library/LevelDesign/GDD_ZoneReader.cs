using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.LevelDesign
{
    public class GDD_ZoneReader
    {
        public Bitmap NoDrawZone;
        public Bitmap NoGravityZone;

        public void Read(string filename)
        {
            Bitmap bmp = new Bitmap(filename);
            for(int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x, y) == Color.FromArgb(255, 100, 100))
                    {
                    }
                }
            }
        }
    }
}
