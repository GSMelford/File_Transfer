using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class NetworkConnectionArgs
    {
        public string FileName { get; }
        public long FileLength { get; }
        public double Speed { get; }
        public long СurrentLength { get; }
        public TimeSpan Time { get; }

        public NetworkConnectionArgs(string fileName, long fileLength, double speed, long currentLength, TimeSpan time)
        {
            FileName = fileName;
            FileLength = fileLength;
            Speed = speed;
            СurrentLength = currentLength;
            Time = time;
        }
    }
}
