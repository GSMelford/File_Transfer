using System.Collections.Generic;

namespace FileTransfer
{
    public class FileHandler
    {
        public delegate void FileHandlerDelegate(object sender, MyEventArgs e);

        public static event FileHandlerDelegate Notify;
        
        private static List<string> FilePathsList;

        private FileHandler()
        {
            FilePathsList = new List<string>();
        }

        public static void AddPaths(List<string> paths)
        {
            FilePathsList = paths;
        }

        public static void ClearFileList()
        {
            FilePathsList.Clear();
        }
        public static List<string> GetPaths() => FilePathsList;

    }
}