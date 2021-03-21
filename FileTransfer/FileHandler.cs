using System.Collections.Generic;
using System.IO;

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
            _fileStream.Write(file, 0, file.Length);
        }
        public static byte[] ReadFile(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            _fileStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        public static bool Exists(string fileName) => new System.IO.FileInfo($@"{_downloadPath}\{fileName}").Exists;
        public static string RenameExistsFile(string fileName, string extension)
        {
            int number = 1;
            int index = fileName.LastIndexOf('.');
            string Name = fileName.Substring(0, index);
            while (FileHandler.Exists(fileName))
            {
                if (index != -1)
                    fileName = Name + $" ({number})" + extension;
                else
                    fileName += $" ({number})";
                number++;
            }
            return fileName;
        }
    }
}
