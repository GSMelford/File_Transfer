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
        public static FileStream _fileStream;
        //private static List<string> FilePaths = new List<string>();
        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>();
        public static void AddFilePath(string name,string path)
        {
            FilePaths.Add(name,path);
        }
        public static Dictionary<string, string> GetFilePaths() => FilePaths;
        public static void WriteFile(byte[] file, string fileName)
        {
            using (FileStream fileStream = new FileStream($@"{_downloadPath}\{fileName}",FileMode.Append))
            {
                fileStream.Write(file, 0, file.Length);
            }
        }
        public static byte[] ReadFile(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            _fileStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
