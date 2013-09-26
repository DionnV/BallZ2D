using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

namespace GDD_Library.Shapes
{
    [Serializable]
    public class GDD_Zone : ISerializable
    {
        /// <summary>
        /// The type of the zone
        /// </summary>
        public GDD_ZoneType ZoneType { get; set; }

        /// <summary>
        /// The location of the zone
        /// </summary>
        public GDD_Point2F Location { get; set; }

        /// <summary>
        /// Considering the zone is a square, for now, the width of the zone
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Considering the zone is a square, for now, the height of the zone
        /// </summary>
        public float Height { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("Location", Location, typeof(GDD_Point2F));
            info.AddValue("Width", Width, typeof(float));
            info.AddValue("Height", Height, typeof(float));
        }

        public GDD_Zone(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            Location = (GDD_Point2F) info.GetValue("Location", typeof(GDD_Point2F));
            Width = (float)info.GetValue("Width", typeof(float));
            Height = (float)info.GetValue("Height", typeof(float));

        }

        public GDD_Zone() { }
    }

    public enum GDD_ZoneType
    {
        NoDraw,
        NoGravity,
        Normal
    }
}
