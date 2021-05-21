using System;

namespace FileTransfer.FileWorker
{
    [Serializable]
    internal class FileInfo
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Length { get; set; }
    }
}
