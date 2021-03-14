using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class NetworkConnection
    {
        public delegate void NetworkConnectionHandler(object sender, NetworkConnectionArgs e);
        public static event NetworkConnectionHandler Notify;
        
        private string IPServer = "178.150.32.105";
        private int Port = 1234;
        private static TcpListener tcpListener{ get; set; }
        private static string FriendName{ get; set; }
        private static TcpClient tcpClient{ get; set; }
        private static NetworkStream Stream { get; set; }

        //Запуск сервера
        public static bool ServerStart(int port)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Notify?.Invoke(null, new NetworkConnectionArgs("Сервер успішно створено."));
                return true;
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new NetworkConnectionArgs($"Помилка при створені серверу.", e.Message));
                return false;
            }
        }
        public static void AcceptClient()
        {
            try
            {
                Notify?.Invoke(null, new NetworkConnectionArgs("Очікуємо підключення..."));
                //Принимаем пользователя
                tcpClient = tcpListener.AcceptTcpClient();
                
                //Получаем его имя
                FriendName = GetStringMessage();
                Notify?.Invoke(null, new NetworkConnectionArgs(
                    $"До Вас приєднався користувач {FriendName}"));
            }
            catch (Exception e)
            {
                Notify?.Invoke(null,
                    new NetworkConnectionArgs($"Помилка під час прийнятя користувача.", 
                        e.Message));
            }
        }
        public static void ServerStop()
        {
            try
            {
                tcpClient?.Close();
                Stream?.Close();
                tcpListener?.Stop();
                Notify?.Invoke(null, new NetworkConnectionArgs("Сервер успішно зупинено."));
            }
            catch (Exception e)
            {
                Notify?.Invoke(null,
                    new NetworkConnectionArgs($"Не вийшло завершити роботу сервера... " +
                                              $"Перезапуск програми.", e.Message));
                Thread.Sleep(1000);
                Process.Start("FileTreansfer.exe");
                Environment.Exit(0);
            }
        }
        private static string GetStringMessage()
        {
            byte[] data = new byte[64]; // Буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            try
            {
                do
                {
                    bytes = Stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (Stream.DataAvailable);
            }
            catch (Exception e)
            {
                Notify?.Invoke(null, new NetworkConnectionArgs($"Помилка при отримані повідомлення.", e.Message));
            }
 
            return builder.ToString();
        }
    }
}