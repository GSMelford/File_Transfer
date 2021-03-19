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
        public delegate void DownloadOrLoadHandler(long max, long value);
        public delegate void DownloadOrLoadStatisticsHandler(NetworkConnectionArgs e);
        public static event DownloadOrLoadStatisticsHandler DownloadOrLoadStatistics;
        public static event NetworkConnectionHandler Notify;
        public static event NetworkConnectionHandler ReceiveOrSendNotify;
        public static event DownloadOrLoadHandler DownloadOrLoad;

        private static string IPServer;
        private static int Port;
        private static TcpListener Listener;
        private static TcpClient Client;
        private static NetworkStream Stream;

        public static bool StartServer(int port)
        {
            try
            {
                Listener = new TcpListener(IPAddress.Any, port);
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
        public static bool ConnectToServer(string IP, int  port)
        {
            try
            {
                IPServer = IP;
                Port = port;
                Client = new TcpClient();
                Client.Connect(IP, Port);
                Stream = Client.GetStream();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void Disconnect()
        {
            Listener?.Stop();
            Client?.Close();
            Stream?.Close();
        }
        private static void ReceiveFiles()
        {
            Stopwatch watch = new Stopwatch();
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
                    watch.Start();
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
                        DownloadOrLoad?.Invoke(fileInfo.Length, receiveByte);
                        DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name, 
                            fileInfo.Length, v, receiveByte, watch.Elapsed));
                    }

                    //------------------------------------
                    watch.Stop();
                    watch.Reset();
                    Notify?.Invoke($"Отримано файл: {fileInfo.Name}.");
                    ReceiveOrSendNotify.Invoke(fileInfo.Name);
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
                Stopwatch watch = new Stopwatch();
                watch.Start();

                byte[] buffer;
                //Отправляем информацию о файле


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
                
                //---------------------------


                int bufferSize = 1000000; //Скорость буфера для отправки

                while (true) // Задержка 
                {
                    Thread.Sleep(1000);
                    if (Client.Available == 0)
                        break;
                }

                //Запускаем поток счета скорости

                long sendByte = 0;
                double v = 0;
                Task speedTest = new Task(() =>
                {
                    long oldsendByte = 0;
                    while (true)
                    {
                        Thread.Sleep(1000);
                        v = sendByte - oldsendByte;
                        oldsendByte = sendByte;
                        if (sendByte == fileInfo.Length)
                            break;
                    }
                });
                speedTest.Start();

                //------------------------------------


                FileHandler._fileStream = File.OpenRead(path);

                for (int i = 0; i < FileHandler._fileStream.Length; i += bufferSize)
                {
                    if (FileHandler._fileStream.Length - i - bufferSize < 0)
                        bufferSize = (int)FileHandler._fileStream.Length - i;

                    buffer = new byte[bufferSize];
                    buffer = FileHandler.ReadFile(bufferSize);
                    Stream.Write(buffer, 0, buffer.Length);
                    sendByte += bufferSize;

                    DownloadOrLoad?.Invoke(fileInfo.Length, sendByte);
                    DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name, 
                        fileInfo.Length, v, sendByte, watch.Elapsed));
                }

                FileHandler._fileStream.Dispose();
                FileHandler._fileStream.Close();

                Notify?.Invoke($"Відправлено файл: {fileInfo.Name}.");
                ReceiveOrSendNotify?.Invoke(fileInfo.Name);
                watch.Reset();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }
    }
}
