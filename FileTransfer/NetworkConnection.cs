using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

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
                Client.Connect(IPServer, Port);
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
                    //Передаем информацию о файле, который сейчас будет передавать
                    byte[] buffer = new byte[4];
                    Stream.Read(buffer, 0, buffer.Length);

                    //Запускаем счет времени
                    watch.Start();
                    //----------------------

                    buffer = new byte[BitConverter.ToInt32(buffer, 0)];
                    Stream.Read(buffer, 0, buffer.Length);
                    FileInfo fileInfo = (FileInfo)ByteArrayToObject(buffer);
                    Notify?.Invoke($"Waiting for file: {fileInfo.Name}. Size: {fileInfo.Length}.");

                    //Запускаем счета скорости
                    long speed = 0;
                    long byteLoad = 0;
                    new Task(()=> { Speedometer(fileInfo.Length, ref speed, ref byteLoad); }).Start();

                    //Переименовывает файлы, если такие уже существовали
                    fileInfo.Name = FileHandler.RenameExistsFile(fileInfo.Name, fileInfo.Extension);

                    //Получаем файл
                    long bufferSize;
                    FileHandler._fileStream = new FileStream($@"{FileHandler.DowloadPath}\{fileInfo.Name}", FileMode.Append);
                    for (long i = 0; i < fileInfo.Length; i += bufferSize)
                    {
                        bufferSize = Client.Available;

                        if (fileInfo.Length - i - bufferSize < 0)
                            bufferSize = fileInfo.Length - i;
                        else
                            buffer = new byte[bufferSize];

                        if (bufferSize != 0)
                        {
                            Stream.Read(buffer, 0, buffer.Length);
                            FileHandler.WriteFile(buffer, fileInfo.Name);
                        }

                        byteLoad += bufferSize;

                        DownloadOrLoad?.Invoke(fileInfo.Length, byteLoad);
                        DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name, 
                            fileInfo.Length, speed, byteLoad, watch.Elapsed));
                    }

                    //Закрываем потоки чтения файла 
                    FileHandler._fileStream.Close();
                    FileHandler._fileStream.Dispose();

                    //Останавливаем секундомер и выводим результат
                    watch.Reset();
                    Notify?.Invoke($"Received file: {fileInfo.Name}.");
                    ReceiveOrSendNotify?.Invoke(fileInfo.Name);
                }
                catch (Exception e)
                {
                    Stream.Write(BitConverter.GetBytes(0), 0, BitConverter.GetBytes(0).Length);

                    Notify?.Invoke($"Error retrieving file.");
                    Notify?.Invoke($"{e.Message}");
                    throw;
                }
            }
        }
        public static void SendFiles(string path)
        {
            try
            {
                //Запускаем счет времени
                Stopwatch watch = new Stopwatch();
                watch.Start();

                //Отправляем информацию про файл
                byte[] buffer;
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                FileTransfer.FileInfo fileInfo = new FileTransfer.FileInfo()
                {
                    Name = file.Name,
                    Extension = file.Extension,
                    Length = file.Length
                };
                Notify?.Invoke($"The file will be sent: {fileInfo.Name}.");

                buffer = ObjectToByteArray(fileInfo);

                byte[] objSize = BitConverter.GetBytes(buffer.Length);
                Stream.Write(objSize, 0, objSize.Length);
                Stream.Write(buffer, 0, buffer.Length);

                //Размер буфера отправки
                long bufferSize = 1000000;

                //Запускаем счета скорости
                long speed = 0;
                long byteLoad = 0;
                new Task(() => { Speedometer(fileInfo.Length, ref speed, ref byteLoad); }).Start();

                //Отправляем файл
                FileHandler._fileStream = File.OpenRead(path);
                for (long i = 0; i < FileHandler._fileStream.Length; i += bufferSize)
                {
                    if (FileHandler._fileStream.Length - i - bufferSize < 0)
                        bufferSize = FileHandler._fileStream.Length - i;

                    buffer = new byte[bufferSize];
                    buffer = FileHandler.ReadFile((int)bufferSize);
                    Stream.Write(buffer, 0, buffer.Length);
                    byteLoad += bufferSize;

                    DownloadOrLoad?.Invoke(fileInfo.Length, byteLoad);
                    DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name,
                            fileInfo.Length, speed, byteLoad, watch.Elapsed));
                }

                //Закрываем потоки чтения файла 
                FileHandler._fileStream.Dispose();
                FileHandler._fileStream.Close();

                //Уведомляем про успешное окончание операции
                Notify?.Invoke($"File sent: {fileInfo.Name}.");
                ReceiveOrSendNotify?.Invoke(fileInfo.Name);
                watch.Reset();
                /*
                 * Задержка отправки следующего файла.  
                 * Нужна по той причине что поток отправки преуспевает над потоком чтения и для избежания
                 * конфликта искуствено затормаживаеться на 1 секунду.
                 */
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Notify?.Invoke($"Failed to send file.");
            }
        }
        private static void Speedometer(long fileLength, ref long speed, ref long byteLoad)
        {
            long oldByte = 0;
            while (true)
            {
                Thread.Sleep(1000);
                speed = (byteLoad - oldByte);
                oldByte = byteLoad;
                if (byteLoad == fileLength)
                    break;
            }
        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
