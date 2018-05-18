using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Client
{
    public static class FileHelper
    {
        private const string filename = "config.ini";
        private static string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\" + filename;

        static FileHelper()
        {
            Debug.WriteLine("Create configure file 'config.ini '");
            CreateFile(filePath);
        }

        public static void CreateFile(string path)
        {
            File.Create(path);
        }

        public static string ReadFile()
        {
            using (var fileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }

        public static void WriteFile(string text)
        {
            using (var fileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamWriter write = new StreamWriter(fileStream))
                {
                    write.WriteLine(text);
                    write.Flush();
                }
            }
        }
    }
}
