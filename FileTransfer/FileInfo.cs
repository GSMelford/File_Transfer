using System;

namespace FileTransfer
{
    [Serializable]
    class FileInfo
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Length { get; set; }
    }
}
