using System;
using System.IO;
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
                try
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

                    for (int i = 0; i < fileInfo.Length; i += bufferSize)
                    {
                        if (fileInfo.Length - i - bufferSize < 0)
                            bufferSize = (int)fileInfo.Length - i;
                        buffer = new byte[bufferSize];

                        Stream.Read(buffer, 0, buffer.Length);

                        FileHandler.WriteFile(buffer, fileInfo.Name);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private static void SendFiles()
        {
            try
            {
                foreach (var path in FileHandler.GetFilePaths())
                {
                    byte[] buffer;
                    System.IO.FileInfo file = new System.IO.FileInfo(path);
                    FileTransfer.FileInfo fileInfo = new FileTransfer.FileInfo() 
                    { 
                        Name = file.Name,
                        Extension = file.Extension,
                        Length = file.Length
                    };

                    string json = JsonSerializer.Serialize<FileTransfer.FileInfo>(fileInfo);
                    buffer = Encoding.UTF8.GetBytes(json);
                    Stream.Write(buffer, 0, buffer.Length);

                    int bufferSize = 10000; //Скорость получения

                    //Надо будет когда-то вынести в поток.
                    using (FileStream fileStream = File.OpenRead(path))
                    {

                        for (int i = 0; i < fileStream.Length; i += bufferSize)
                        {
                            if (fileStream.Length - i - bufferSize < 0)
                                bufferSize = (int)fileStream.Length - i;

                            buffer = new byte[bufferSize];
                            fileStream.Read(buffer, 0, buffer.Length);
                            Stream.Write(buffer, 0, buffer.Length);
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
