using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GDD_Library.LevelDesign
{
    class GDD_HeaderWriter
    {
        
        /// <summary>
        /// This method will write level info to a binary form.
        /// </summary>
        /// <param name="url"></param>
        public void WriteToFile(String url, GDD_HeaderInfo info)
        {
            //
            MemoryStream MS = new MemoryStream();
            BinaryWriter Writer = new BinaryWriter(MS);

            //Writing Verison Number
            Writer.Write(info.VersionNumber);
            Writer.Write(info.LevelVersionNumber);           
            Writer.Write(info.Level_Width);
            Writer.Write(info.Level_Height);
            Writer.Write(info.MaxLineLenght);
            Writer.Write(info.Index_Ball);
            Writer.Write(info.Index_Bucket);
            Writer.Write(info.LevelName);
            Writer.Write(info.BackgroundName);
            Writer.Write(info.CreatorName);

            //Converting memory stream
            using (FileStream file = new FileStream(url, FileMode.Create, System.IO.FileAccess.Write))
            {
                MS.WriteTo(file);
            }
        }
    }
}
