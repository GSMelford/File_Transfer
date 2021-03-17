using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    class FileHandler
    {
        private static string _downloadPath;
        public static string DowloadPath 
        {
            get => _downloadPath;
            set { _downloadPath = value; }
        }
        private static List<string> FilePaths = new List<string>();
        public static void AddFilePath(string path)
        {
            FilePaths.Add(path);
        }
        public static List<string> GetFilePaths() => FilePaths;
        public static void WriteFile(byte[] file, string fileName)
        {
            using (FileStream fileStream = new FileStream($@"{_downloadPath}\{fileName}",FileMode.Append))
            {
                fileStream.Write(file, 0, file.Length);
            }
        }
    }
}
