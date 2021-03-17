using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class FileTransferEventArgs
    {
        public string Message { get; set; }

        public FileTransferEventArgs(string message)
        {
            Message = message;
        }
    }
}
