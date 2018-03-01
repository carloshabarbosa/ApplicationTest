using System;
using System.IO;

namespace ApplicationTest.Data.Common
{
    /// <summary>
    /// Helper class reponsible for files
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Method reponsible for get a correct data path
        /// </summary>
        /// <returns>The correct path fot save data/returns>
        public static string GetDataPath()
        {
            var path =  Path.Combine(Environment.CurrentDirectory, "data");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// Method reponsible for get a correct log path
        /// </summary>
        /// <returns>The correct path fot save log/returns>
        public static string GetLogPath()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "log");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// Method responsible for validate if a file exists
        /// </summary>
        /// <param name="fileName">File path to validade</param>
        /// <returns>true if the file exists, false if the file not exists</returns>
        public static bool ValidateFile(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// Method responsible for create a file
        /// </summary>
        /// <param name="fileName">Path to create a file</param>
        public static void CreateFile(string fileName)
        {
            using (var file = File.CreateText(fileName))
            {
                file.Flush();
                file.Close();
            }
        }

        /// <summary>
        /// Method responsible to clean a file
        /// </summary>
        /// <param name="fileName">File path</param>
        public static void ResetFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}
