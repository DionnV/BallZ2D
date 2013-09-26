using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace GDD_Library.LevelDesign
{
    class GDD_Serialize
    {
        //Create a formatter to serialize
        private static IFormatter formatter = new BinaryFormatter();
       
        public static void SerializeItem(string fileName, List<GDD_Object> loo)
        {         

            //Create a filesteam to write to
            FileStream fs = new FileStream(fileName, FileMode.Create);

            // Create an instance of the type and serialize it.
            foreach (GDD_Object obj in loo)
            {
                formatter.Serialize(fs, obj);
            }
                  
            fs.Close();
        }


        public static List<GDD_Object> DeserializeItem(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            List<GDD_Object> loo = new List<GDD_Object>();
            while (fs.Length != fs.Position)
            {
                GDD_Object obj = (GDD_Object)formatter.Deserialize(fs);
                loo.Add(obj);              
            }

            return loo;
        }
    }
}
