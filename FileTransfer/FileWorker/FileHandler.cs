using System.Collections.Generic;
using System.IO;

namespace FileTransfer.FileWorker
{
    internal static class FileHandler
    {
        public static string DownloadPath { get; set; }

        public static FileStream FileStream;
        
        //private static List<string> FilePaths = new List<string>();
        
        private static readonly Dictionary<string, string> FilePaths = new Dictionary<string, string>();
        
        public static void AddFilePath(string name,string path)
        {
            FilePaths.Add(name,path);
        }
        
        public static Dictionary<string, string> GetFilePaths() => FilePaths;
        
        public static void WriteFile(byte[] file, string fileName)
        {
            FileStream.Write(file, 0, file.Length);
        }
        
        public static byte[] ReadFile(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            FileStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        
        private static bool Exists(string fileName) => new System.IO.FileInfo($@"{DownloadPath}\{fileName}").Exists;
        
        public static string RenameExistsFile(string fileName, string extension)
        {
            int number = 1;
            int index = fileName.LastIndexOf('.');
            string name = fileName.Substring(0, index);
            
            while (Exists(fileName))
            {
                if (index != -1)
                    fileName = name + $" ({number})" + extension;
                else
                    fileName += $" ({number})";
                number++;
            }
            
            return fileName;
        }
    }
}
