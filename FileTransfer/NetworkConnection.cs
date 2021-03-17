using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    class NetworkConnection
    {
        private string IP;
        private static TcpListener Listener;
        private static TcpClient Client;
        private static NetworkStream Stream;
        private NetworkConnection()
        {
            IP = new WebClient().DownloadString("https://api.ipify.org");
        }

        public static bool StartServer()
        {
            try
            {
                Listener = new TcpListener(IPAddress.Any, 1234);
                Listener.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool AcceptClient()
        {
            try
            {
                Client = Listener.AcceptTcpClient();
                Stream = Client.GetStream();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
