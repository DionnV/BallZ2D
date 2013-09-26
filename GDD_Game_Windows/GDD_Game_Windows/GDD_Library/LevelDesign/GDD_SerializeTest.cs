using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDD_Library.Shapes;
using System.Windows.Forms;

namespace GDD_Library.LevelDesign
{
    class GDD_SerializeTest
    {
        public List<GDD_Object> loo = new List<GDD_Object>();

        public void run()
        {
            GDD_Object obj1 = new GDD_Object(new GDD_Circle());
            GDD_Object obj2 = new GDD_Object(new GDD_Bucket());
            GDD_Object obj3 = new GDD_Object(new GDD_Square());

            obj1.Location = new GDD_Point2F(0f, 100f);
            obj2.Location = new GDD_Point2F(100f, 0f);
            obj3.Location = new GDD_Point2F(100f, 100f);

            loo.Add(obj1);
            loo.Add(obj2);
            loo.Add(obj3);
            MessageBox.Show(obj1.ToString() + " " + obj2.ToString() + " " + obj3.ToString());

            GDD_Serialize.SerializeItem("loo.data", loo);
            MessageBox.Show("Serialized it all");

            List<GDD_Object> newloo = GDD_Serialize.DeserializeItem("loo.data");
            MessageBox.Show("Deserialized it all");


            foreach (GDD_Object obj in newloo)
            {
                MessageBox.Show(obj.ToString());
            }

        }
    }
}
