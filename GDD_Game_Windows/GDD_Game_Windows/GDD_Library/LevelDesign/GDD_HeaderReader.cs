using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GDD_Library.LevelDesign
{
    class GDD_HeaderReader
    {
        public GDD_HeaderInfo ReadFromFile(String url)
        {
            GDD_HeaderInfo info = new GDD_HeaderInfo();
            MemoryStream MS = new MemoryStream();
            BinaryReader Reader = new BinaryReader(MS);

            //Every version higher or equal to should contain this info
            info.VersionNumber = Reader.ReadInt32();
            info.LevelVersionNumber = Reader.ReadInt32();
            info.Level_Width = Reader.ReadInt32();
            info.Level_Height = Reader.ReadInt32();
            info.MaxLineLenght = Reader.ReadInt32();
            info.Index_Ball = Reader.ReadInt32();
            info.Index_Bucket = Reader.ReadInt32();
            info.LevelName = Reader.ReadString();
            info.BackgroundName = Reader.ReadString();
            info.CreatorName = Reader.ReadString();

            //Higher versions might contain more info
            if (info.VersionNumber > 1)
            {
                //We don't have a higher version yet
            }
           
            return info;

        }
    }
}
