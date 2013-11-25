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
        /// <param name="fileName">The name of the file.</param>
        /// <param name="loo">The list of objects to serialize.</param>
        public static void Serialize(string fileName, List<GDD_Object> loo)
        {
            //Create a filesteam to write to.
            FileStream fs = new FileStream(fileName, FileMode.Create);

            // Create an instance of the type and serialize it.
            foreach (GDD_Object obj in loo)
            {
                formatter.Serialize(fs, obj);
            }

            //Close and dispose the stream.
            fs.Close();
            fs.Dispose();
        }

        /// <summary>
        /// This method will deserialize a given file to be used in the designing of a level
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns></returns>
        public static List<GDD_Object> Deserialize(string fileName)
        {
            //Run a check if the file exists.
            if (!File.Exists(fileName))
            {
                throw new IncorrectFileException();
            }

            //Open a filestream for reading.
            FileStream fs = new FileStream(fileName, FileMode.Open);

            //Create an empty list of objects to fill.
            List<GDD_Object> loo = new List<GDD_Object>();

            //Iterate through all objects, adding them to the empty list.
            while (fs.Length != fs.Position)
            {
                GDD_Object obj = (GDD_Object)formatter.Deserialize(fs);
                loo.Add(obj);
            }

            //Close and dispose the filestream.
            fs.Close();
            fs.Dispose();

            //Return the now filled list.
            return loo;
        }

        /// <summary>
        /// This method will read data from a deserialized file.
        /// </summary>
        /// <param name="url">The file to be deserialized.</param>
        /// <returns></returns>
        public static GDD_HeaderInfo ReadFromFile(String url)
        {
            //Run a check if the file exists.
            if (!File.Exists(url))
            {
                throw new IncorrectFileException();
            }
            //The info to be filled.
            GDD_HeaderInfo info = new GDD_HeaderInfo();

            //The reader that will be used to read the binary file.
            BinaryReader Reader = new BinaryReader(File.Open(url, FileMode.Open));

            //Every version higher or equal to should contain this info
            info.VersionNumber = Reader.ReadInt32();
            info.LevelVersionNumber = Reader.ReadInt32();
            info.Level_Width = Reader.ReadInt32();
            info.Level_Height = Reader.ReadInt32();
            info.MaxLineLenght = Reader.ReadInt32();
            info.Index_Ball = Reader.ReadInt32();
            info.Index_Bucket = Reader.ReadInt32();
            info.LevelName = Reader.ReadString();
            info.CreatorName = Reader.ReadString();           

            //Higher versions might contain more info
            if (info.VersionNumber > 1)
            {
                info.Highscore = Reader.ReadInt32();
            }
            
            //Close and dispose the reader
            Reader.Close();
            Reader.Dispose();

            //Return the HeaderInfo.
            return info;
        }

        /// <summary>
        /// This method will write level info to a binary form.
        /// </summary>
        /// <param name="url">The binary file that has to be created.</param>
        /// <param name="info">The info that should be written in the binary file.</param>
        public static void WriteToFile(String url, GDD_HeaderInfo info)
        {
            //The memorystream and binarywriter that are used to write the file.
            MemoryStream MS = new MemoryStream();
            BinaryWriter Writer = new BinaryWriter(MS);

            //Writing the info
            Writer.Write(info.VersionNumber);
            Writer.Write(info.LevelVersionNumber);
            Writer.Write(info.Level_Width);
            Writer.Write(info.Level_Height);
            Writer.Write(info.MaxLineLenght);
            Writer.Write(info.Index_Ball);
            Writer.Write(info.Index_Bucket);
            Writer.Write(info.LevelName);
            Writer.Write(info.CreatorName);
            Writer.Write(info.Highscore);

            //Converting memory stream
            using (FileStream file = new FileStream(url, FileMode.Create, System.IO.FileAccess.Write))
            {
                MS.WriteTo(file);
            }

            //Closing and disposing the streams.
            MS.Close();
            MS.Dispose();
            Writer.Close();
            Writer.Dispose();
        }

        /// <summary>
        /// This method will use the System.Windows.File class to check whether a file exists.
        /// </summary>
        /// <see cref="System.Windows.File.Exists(System.String)"/>
        /// <param name="filename">The filename that has to be checked.</param>
        /// <returns></returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        /// <summary>
        /// This method will use the System.Windows.File class to move a file.
        /// <see cref="System.Windows.File.Move(System.String)"/>
        /// </summary>
        /// <param name="src">The source of the file.</param>
        /// <param name="dest">The destination of the file.</param>
        public static void FileMove(string src, string dest)
        {
            File.Move(src, dest);
        }

        /// <summary>
        /// This method will use the System.Windows.File class to delete a file.
        /// <see cref="System.Windows.File.Delete(System.String)"/>
        /// </summary>
        /// <param name="filename">The file to be deleted.</param>
        public static void FileDelete(string filename)
        {
            File.Delete(filename);
        }
      
        /// <summary>
        /// This method will create a GDD_Level given a folder. This folder should contain
        /// at least two files called Objects.bin and LevelData.bin. It may also contain a .jpeg-file
        /// called background.jpeg.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns>A GDD_Level object.</returns>
        public static GDD_Level LoadFromFolder(string folder)
        {
            //Run a check whether the folder exists
            if (!Directory.Exists(folder))
            {
                throw new IncorrectFolderException();
            }
            //Create an empty level.
            GDD_Level lev = new GDD_Level();

            //Fill the leveldata using deserialization and reading the binary file.
            //Read the serialized file.
            lev.Objects = GDD_IO.Deserialize(folder + "/Objects.bin");

            //Read the binary file.
            lev.info = GDD_IO.ReadFromFile(folder + "/LevelData.bin");

            //Return the result.
            return lev;
        }
    }
}

/// <summary>
/// This class will hold a self-made exception, which will be throwed when a folder can't be found.
/// </summary>
public class IncorrectFolderException : Exception
{
    public IncorrectFolderException() : base() { }
    public IncorrectFolderException(string message) : base(message) { }
    public IncorrectFolderException(string message, Exception inner) : base(message, inner) { }

    public override string ToString()
    {
        return "The given folder was not found.";
    }
}

/// <summary>
/// This class will hold a self-made exception, which will be throwed when a file can't be found.
/// </summary>
public class IncorrectFileException : Exception
{
    public IncorrectFileException() : base() { }
    public IncorrectFileException(string message) : base(message) { }
    public IncorrectFileException(string message, Exception inner) : base(message, inner) { }

    public override string ToString()
    {
        return "The file was not found.";
    }
}
