using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    class NetworkConnection
    {
        public delegate void NetworkConnectionHandler(string message);
        public delegate void DownloadHandler(long max, long value);
        public static event NetworkConnectionHandler Notify;
        public static event NetworkConnectionHandler ReceiveNotify;
        public static event NetworkConnectionHandler DownloadedNotify;
        public static event DownloadHandler Downloaded;
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
                Client.ReceiveBufferSize = 1000000;
                Client.SendBufferSize = 1000000;
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
                    //Получем информацию о файле

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

                    //------------------------------------

                    //Запускаем поток счета скорости
                    
                    long receiveByte = 0;
                    double v = 0;
                    Task speedTest = new Task(() =>
                    {
                        long oldReceiveByte = 0;
                        while (true)
                        {
                            Thread.Sleep(1000);
                            v = receiveByte - oldReceiveByte;
                            oldReceiveByte = receiveByte;
                            if (receiveByte == fileInfo.Length)
                                break;
                        }
                    });
                    speedTest.Start();

                    //------------------------------------

                    //Получем сам файл

                    int bufferSize;
                    for (int i = 0; i < fileInfo.Length; i += bufferSize)
                    {
                        bufferSize = Client.Available;

                        if (fileInfo.Length - i - bufferSize < 0)
                            bufferSize = (int)(fileInfo.Length - i);
                        else

                        buffer = new byte[bufferSize];

                        Stream.Read(buffer, 0, buffer.Length);

                        FileHandler.WriteFile(buffer, fileInfo.Name);
                        receiveByte += bufferSize;
                        Downloaded?.Invoke(fileInfo.Length, receiveByte);
                        DownloadedNotify?.Invoke($"Назва файлу: {fileInfo.Name} " +
                            $"Завантажено: {receiveByte} байтів з {fileInfo.Length} байтів. " +
                            $"Швидкість: {v / 1000000} Мб/с. ({(receiveByte * 100) / fileInfo.Length} %)");
                    }

                    //------------------------------------

                    Notify?.Invoke($"Отримано файл: {fileInfo.Name}.");
                    ReceiveNotify.Invoke(fileInfo.Name);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static void SendFiles(string path)
        {
            try
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
                
                int bufferSize = 1000000; //Скорость отправки
                Thread.Sleep(30);

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
            catch (Exception)
            {

            }
        }
    }
}
