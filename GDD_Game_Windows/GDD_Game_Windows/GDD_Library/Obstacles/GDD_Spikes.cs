using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDD_Library.Shapes;

namespace GDD_Library.Obstacles
{
    public class GDD_Spikes : GDD_Polygon
    {
        public GDD_Spikes()
        {
            this.PolygonPoints = new GDD_Point2F[10];
            this.PolygonPoints[0] = new GDD_Point2F(0, 0);
        }
    }
}
