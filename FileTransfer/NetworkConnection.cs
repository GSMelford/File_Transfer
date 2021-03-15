using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public class NetworkConnection
    {
        public delegate void NetworkConnectionHandler(object sender, MyEventArgs e);

        public static event NetworkConnectionHandler Notify;

        private string IPServer = "178.150.32.105";     // IP удаленого сервера
        private int Port = 1234;                        // Port удаленого сервера
        private static TcpListener tcpListener { get; set; }
        private static string FriendName { get; set; }
        private static TcpClient tcpClient { get; set; }
        private static NetworkStream Stream { get; set; }


        public static bool ServerStart(int port)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Notify?.Invoke(null, new MyEventArgs("Сервер успішно створено."));
                return true;
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new MyEventArgs($"Помилка при створені серверу.", e.Message));
                return false;
            }
        }
        public static void AcceptClient()
        {
            try
            {
                Notify?.Invoke(null, new MyEventArgs("Очікуємо підключення..."));
                //Принимаем пользователя
                tcpClient = tcpListener.AcceptTcpClient();
                Stream = tcpClient.GetStream();
                //Получаем его имя
                FriendName = ReceiveMessage();
                Notify?.Invoke(null, new MyEventArgs(
                    $"До Вас приєднався користувач {FriendName}"));

                Task rf = new Task(ReceiveFile);
                rf.Start();
            }
            catch (Exception e)
            {
                Notify?.Invoke(null,
                    new MyEventArgs($"Помилка під час прийнятя користувача.",
                        e.Message));
            }
        }

        private static void ReceiveFile()
        {
            int counter = 0;
            MessageBox.Show("ReceiveFile() started.");
            while (true)
            {
                byte[] data = new byte[1000];
                try
                {
                    do
                    {
                        Stream.Read(data, 0, data.Length);
                        Notify?.Invoke(null, new MyEventArgs($"Файл отримується..."));
                    
                    } while (Stream.DataAvailable);
                    File.WriteAllBytes($@"C:\{counter}.txt",data);
                    Notify?.Invoke(null, new MyEventArgs($"Файл отримано."));
                    counter++;
                }
                catch (Exception e)
                {
                    Notify?.Invoke(null, new MyEventArgs($"Помилка при отримані файлу.", e.Message));
                    break;
                }
            }
        }

        public static void SendFiles()
        {
            try
            {
                foreach (var path in FileHandler.GetPaths())
                {
                    FileInfo fileInfo = new FileInfo(path);
                    byte[] info = ObjectToByteArray(fileInfo);
                    byte[] data = File.ReadAllBytes(path);
                    byte[] total = info.Concat(data).ToArray();
                    
                    
                    
                    
                    Stream.Write(total, 0, total.Length);
                    Notify?.Invoke(null, new MyEventArgs($"Відправлено файл: {path}"));
                }

                FileHandler.ClearFileList();
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new MyEventArgs("Не вдалося відправити файл."));
            }
        }
        public static void ServerStop()
        {
            try
            {
                tcpClient?.Close();
                Stream?.Close();
                tcpListener?.Stop();
                Notify?.Invoke(null, new MyEventArgs("Сервер успішно зупинено."));
            }
            catch (Exception e)
            {
                Notify?.Invoke(null,
                    new MyEventArgs($"Не вийшло завершити роботу сервера... " +
                                    $"Перезапуск програми.", e.Message));
                Thread.Sleep(1000);
                Process.Start("FileTreansfer.exe");
                Environment.Exit(0);
            }
        }
        public static bool ConnectToServer(string ip, int port)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);
                Stream = tcpClient.GetStream();
                Notify?.Invoke(null, new MyEventArgs($"Ви підключилися до " +
                                                     $"серверу: {ip}:{port}"));
                return true;
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new MyEventArgs($"Не вдалося підключитися до серверу: " +
                                                     $"{ip}:{port}", e.Message));
                return false;
            }
        }
        public static void DisconnectFromServer()
        {
            if (Stream != null)
                Stream.Close();
            if (tcpClient != null)
                tcpClient.Close();
            Notify?.Invoke(null, new MyEventArgs($"Ви відключилися від серверу."));
        }
        public static void SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                Stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new MyEventArgs($"Не вдалося відправити повідомлення: " +
                                                     $"\"{message}\"", e.Message));
            }
        }
        private static string ReceiveMessage()
        {
            byte[] data = new byte[64]; // Буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            try
            {
                do
                {
                    bytes = Stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                } while (Stream.DataAvailable);
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new MyEventArgs($"Помилка при отримані повідомлення.", e.Message));
            }

            return builder.ToString();
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
    }
}