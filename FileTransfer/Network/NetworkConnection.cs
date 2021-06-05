using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using FileTransfer.FileWorker;
using FileInfo = FileTransfer.FileWorker.FileInfo;

namespace FileTransfer.Network
{
    internal static class NetworkConnection
    {
        public delegate void NetworkConnectionHandler(string message);
        public delegate void DownloadOrLoadStatisticsHandler(NetworkConnectionArgs e);
        public static event DownloadOrLoadStatisticsHandler DownloadOrLoadStatistics;
        public static event NetworkConnectionHandler Notify;
        public static event NetworkConnectionHandler ReceiveNotify;

        private static string _ipServer;
        private static int _port;
        private static TcpListener _listener;
        private static TcpClient _client;
        private static NetworkStream _stream;

        public static bool StartServer(int port)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();
                Notify?.Invoke("The server is running.");
                return true;
            }
            catch (Exception)
            {
                Notify?.Invoke("An error occurred while starting the server.");
                return false;
            }
        }
        
        public static bool AcceptClient()
        {
            try
            {
                Notify?.Invoke("Waiting for user connection...");

                _client = _listener.AcceptTcpClient();
                _stream = _client.GetStream();
                _client.ReceiveBufferSize = 1000000;
                _client.SendBufferSize = 1000000;
                
                Notify?.Invoke("The client connects.");
                return true;
            }
            catch (Exception)
            {
                Notify?.Invoke("An error occurred while connecting the client.");
                return false;
            }
        }
        
        public static bool ConnectToServer(string ip, int  port)
        {
            try
            {
                Notify?.Invoke("Connect to server ...");
                _ipServer = ip;
                _port = port;
                _client = new TcpClient();
                _client.Connect(_ipServer, _port);
                _stream = _client.GetStream();
                Notify?.Invoke("The connection to the server was successful.");
                return true;
            }
            catch (Exception)
            {
                Notify?.Invoke("An error occurred while connecting to the server.");
                return false;
            }
        }

        public static void TryConnectToServer()
        {
            while (!ConnectToServer(_ipServer, _port))
            {
            }
        }
        
        public static void Disconnect()
        {
            _listener?.Stop();
            _client?.Close();
            _stream?.Close();
        }
        
        public static bool ReceiveFiles()
        {
            Stopwatch watch = new Stopwatch();
            try
            {
                //Передаем информацию о файле, который сейчас будет передавать
                byte[] buffer = new byte[4];
                _stream.Read(buffer, 0, buffer.Length);

                //Запускаем счет времени
                watch.Start();
                //----------------------

                buffer = new byte[BitConverter.ToInt32(buffer, 0)];
                _stream.Read(buffer, 0, buffer.Length);
                FileInfo fileInfo = (FileInfo)ByteArrayToObject(buffer);
                Notify?.Invoke($"Waiting for file: {fileInfo.Name}. Size: {fileInfo.Length}.");
                ReceiveNotify?.Invoke(fileInfo.Name);

                //Запускаем счета скорости
                long speed = 0;
                long byteLoad = 0;
                new Task(()=> { Speedometer(fileInfo.Length, ref speed, ref byteLoad); }).Start();

                //Переименовывает файлы, если такие уже существовали
                fileInfo.Name = FileHandler.RenameExistsFile(fileInfo.Name, fileInfo.Extension);

                //Получаем файл
                long bufferSize;
                int updateTick = 1;
                FileHandler.FileStream = new FileStream($@"{FileHandler.DownloadPath}\{fileInfo.Name}", FileMode.Append);
                for (long i = 0; i < fileInfo.Length; i += bufferSize)
                {
                    bufferSize = _client.Available;

                    if (fileInfo.Length - i - bufferSize < 0)
                        bufferSize = fileInfo.Length - i;
                    else
                        buffer = new byte[bufferSize];

                    if (bufferSize != 0)
                    {
                        _stream.Read(buffer, 0, buffer.Length);
                        FileHandler.WriteFile(buffer, fileInfo.Name);
                    }

                    byteLoad += bufferSize;

                    if (watch.Elapsed.TotalSeconds >= updateTick)
                    {
                        updateTick++;
                        DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name, 
                            fileInfo.Length, speed, byteLoad, watch.Elapsed));
                    }
                }

                DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name, 
                    fileInfo.Length, speed, byteLoad, watch.Elapsed));
                    
                //Закрываем потоки чтения файла 
                FileHandler.FileStream.Close();
                FileHandler.FileStream.Dispose();

                //Останавливаем секундомер и выводим результат
                watch.Reset();
                Notify?.Invoke($"Received file: {fileInfo.Name}.");
                    
            }
            catch (Exception e)
            {
                Notify?.Invoke($"Error retrieving file.");
                Notify?.Invoke($"{e.Message}");
                return false;
            }

            return true;
        }
        
        public static bool SendFiles(string path)
        {
            try
            {
                //Запускаем счет времени
                Stopwatch watch = new Stopwatch();
                watch.Start();

                //Отправляем информацию про файл
                byte[] buffer;
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                FileInfo fileInfo = new FileInfo()
                {
                    Name = file.Name,
                    Extension = file.Extension,
                    Length = file.Length
                };
                Notify?.Invoke($"The file will be sent: {fileInfo.Name}.");

                buffer = ObjectToByteArray(fileInfo);

                byte[] objSize = BitConverter.GetBytes(buffer.Length);
                _stream.Write(objSize, 0, objSize.Length);
                _stream.Write(buffer, 0, buffer.Length);

                //Размер буфера отправки
                long bufferSize = 1000000;

                //Запускаем счета скорости
                long speed = 0;
                long byteLoad = 0;
                new Task(() => { Speedometer(fileInfo.Length, ref speed, ref byteLoad); }).Start();

                //Отправляем файл
                FileHandler.FileStream = System.IO.File.OpenRead(path);
                for (long i = 0; i < FileHandler.FileStream.Length; i += bufferSize)
                {
                    if (FileHandler.FileStream.Length - i - bufferSize < 0)
                        bufferSize = FileHandler.FileStream.Length - i;

                    buffer = new byte[bufferSize];
                    buffer = FileHandler.ReadFile((int)bufferSize);
                    _stream.Write(buffer, 0, buffer.Length);
                    byteLoad += bufferSize;

                    DownloadOrLoadStatistics?.Invoke(new NetworkConnectionArgs(fileInfo.Name,
                            fileInfo.Length, speed, byteLoad, watch.Elapsed));
                }

                //Закрываем потоки чтения файла 
                FileHandler.FileStream.Dispose();
                FileHandler.FileStream.Close();

                //Уведомляем про успешное окончание операции
                Notify?.Invoke($"File sent: {fileInfo.Name}.");
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
                return false;
            }
            return true;
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

        private static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private static object ByteArrayToObject(byte[] arrBytes)
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
