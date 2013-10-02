using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace GDD_Library.LevelDesign
{
    /// <summary>
    /// This class will hold methods for input and output.
    /// </summary>
    public class GDD_IO
    {
        //Create a formatter for serialization
        private static IFormatter formatter = new BinaryFormatter();

        /****************************************************************************************
         * These two methodes are used to serialize and deserialize binary files.        
         ****************************************************************************************/

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
            fs.Dispose();
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

            //Closing the filestream
            fs.Close();
            fs.Dispose();

            return loo;
        }

        /****************************************************************************************
         * These two methodes are used to compress and decompress files to and from .zip-files       
         ****************************************************************************************/

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

        /****************************************************************************************
         * These two methodes are used to read and write to self-made binary files.        
         ****************************************************************************************/

        /// <summary>
        /// This method will read data from a deserialized file.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static GDD_HeaderInfo ReadFromFile(String url)
        {
            GDD_HeaderInfo info = new GDD_HeaderInfo();
            BinaryReader Reader = new BinaryReader(File.Open(url, FileMode.Open));

            //Every version higher or equal to 1 should contain this info
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

            //Closing the memorystream and the binaryreader
            Reader.Close();
            Reader.Dispose();

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

            //Closing the IO
            Writer.Close();
            Writer.Dispose();
            MS.Close();
            MS.Dispose();
        }

        /****************************************************************************************
         * These three methodes are used to manege files. We wanted to keep these method in the
         * GDD_IO section, therefore we only override the existing methods from System.IO.File
         ****************************************************************************************/

        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public static void FileMove(string src, string dest)
        {
            File.Move(src, dest);
        }

        public static void FileDelete(string filename)
        {
            File.Delete(filename);
        }

        /****************************************************************************************
         * These two methods are used to load levels from .zip-files and from given folders. Both
         * will return a GDD_Level containing the needed data.
         ****************************************************************************************/

        /// <summary>
        /// Loads a level from a given .zip-file
        /// </summary>
        /// <param name="zipfile"></param>
        /// <returns></returns>
        public static GDD_Level LoadFromZipFile(string zipfile)
        {
            GDD_Level lev = new GDD_Level();
            //Create a path to unpack the levels to
            string path = "./Progress";

            //Unzip the zip file
            GDD_IO.Decompress(zipfile, path);

            //The unzipped folder should contain a serialized file called Objects.bin.
            //Read the serialized file.
            lev.Objects = GDD_IO.Deserialize(path + "/Objects.bin");

            //There is also a file called LevelData.bin which holds info about the level.
            //Let's read that one too.
            lev.info = GDD_IO.ReadFromFile(path + "/LevelData.bin");

            //Create a new directory for the unzipped file
            Directory.CreateDirectory("./Levels/Custom/" + lev.info.LevelName);
            //Now we move the files to their own folder, given by the levelname which we find
            //in the HeaderInfo

            GDD_IO.FileMove(path + "/Objects.bin", "./Levels/Custom/" + lev.info.LevelName + "/" + "Objects.bin");
            GDD_IO.FileMove(path + "/LevelData.bin", "./Levels/Custom/" + lev.info.LevelName + "/" + "LevelData.bin");

            //If there is a background, we move that too
            if (GDD_IO.FileExists(path + "/background.jpeg"))
            {
                lev.Background = path + "/background.jpeg";
                GDD_IO.FileMove(path + "/background.jpeg", "./Levels/Custom/" + lev.info.LevelName + "/");
            }
            return lev;
        }

        /// <summary>
        /// Loads a level from a given folder
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static GDD_Level LoadFromFolder(string path)
        {
            GDD_Level lev = new GDD_Level();

            //The unzipped folder should contain a serialized file called Objects.bin.
            //Read the serialized file.
            lev.Objects = GDD_IO.Deserialize(path + "/Objects.bin");

            //There is also a file called LevelData.bin which holds info about the level.
            //Let's read that one too.
            lev.info = GDD_IO.ReadFromFile(path + "/LevelData.bin");

            //Lastly, we need a sexy background, which happens to be in the zipfile too.
            //However, if there is no background, we will make a white one.
            if (GDD_IO.FileExists(path + "/background.jpeg"))
            {
                lev.Background = path + "/background.jpeg";
            }
            return lev;
        }
    }
}
