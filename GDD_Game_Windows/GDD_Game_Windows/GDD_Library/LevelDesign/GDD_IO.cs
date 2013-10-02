using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.IO.Compression;

namespace GDD_Library.LevelDesign
{
    /// <summary>
    /// This class will hold methods for input and output.
    /// </summary>
    public class GDD_IO
    {
        //Create a formatter for serialization
        private static IFormatter formatter = new BinaryFormatter();

        /// <summary>
        /// This method will serialize a list of objects to be used in a self-made level
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="loo"></param>
        public static void Serialize(string fileName, List<GDD_Object> loo)
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

        /// <summary>
        /// This method will deserialize a given file to be used in the designing of a level
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<GDD_Object> Deserialize(string fileName)
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


        /// <summary>
        /// This method will compress a folder to a .zip-file to be used for level design
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public static void Compress(string from, string to)
        {
            ZipFile.CreateFromDirectory(from, to);           
        }

        /// <summary>
        /// This method will decompress a .zip-file to a folder to be used for level design
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public static void Decompress(string from, string to)
        {           
            ZipFile.ExtractToDirectory(from, to);
        }

        /// <summary>
        /// This method will read data from a deserialized file.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static GDD_HeaderInfo ReadFromFile(String url)
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

        /// <summary>
        /// This method will write level info to a binary form.
        /// </summary>
        /// <param name="url"></param>
        public static void WriteToFile(String url, GDD_HeaderInfo info)
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

        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public static void FileMove(string src, string dest)
        {
            File.Move(src, dest);
        }
    }
}
