using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileTransfer
{
    class NetworkConnection
    {
        private static string IP;
        private static string IPServer = "178.150.32.105";
        private static int Port;
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

                //Запуск потока для получения файлов
                Task receiveFiles = new Task(ReceiveFiles);
                receiveFiles.Start();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ConnectToServer(int  port)
        {
            try
            {
                Port = port;
                Client = new TcpClient();
                Client.Connect(IPServer, Port);
                Stream = Client.GetStream();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static void ReceiveFiles()
        {
            while (true)
            {
                int bytes = 0;
                byte[] buffer = new byte[64];
                StringBuilder json = new StringBuilder();

                do
                {
                    bytes = Stream.Read(buffer, 0, buffer.Length);
                    json.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                }
                while (Stream.DataAvailable);

                FileTransfer.FileInfo fileInfo = JsonSerializer.Deserialize<FileTransfer.FileInfo>(json.ToString());

                int bufferSize = 10000; // Скорость отправки

                for (int i = 0; i < fileInfo.Length; i+= bufferSize)
                {
                    if (fileInfo.Length - i - bufferSize < 0)
                        bufferSize = fileInfo.Length - i;
                    buffer = new byte[bufferSize];

                    Stream.Read(buffer, 0, buffer.Length);


                }
            }
        }
    }
}
