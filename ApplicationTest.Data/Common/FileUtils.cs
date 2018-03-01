using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Data.Common
{
    public static class FileUtils
    {
        public static string GetDataPath()
        {
            var path =  Path.Combine(Environment.CurrentDirectory, "data");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static bool ValidateFile(string fileName)
        {
            return File.Exists(fileName);
        }

        public static void CreateFile(string fileName)
        {
            using (var file = File.CreateText(fileName))
            {
                file.Flush();
                file.Close();
            }
        }

        public static void ResetFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}
