using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTransferForm : Form
    {
        public delegate void FileTransferFormHandler(string message);
        private event FileTransferFormHandler Notify;
        private bool isServer = false;
        public FileTransferForm()
        {
            InitializeComponent();

            Notify += AddStatus;
            NetworkConnection.Notify += AddStatus;
            NetworkConnection.DownloadOrLoad += UpdateLoadBar;
            NetworkConnection.DownloadOrLoadStatistics += UpdateLoadStatus;

            FileHandler.DowloadPath = @"C:\Users\Max\Desktop\R\";
            DownloadPathBox.Text = FileHandler.DowloadPath;
            SetButtonsEnabled(false, false, false, false);

        }
        private void SetButtonsEnabled (bool sendButton, bool addFileButton, bool removeButton, bool clearButton)
        {
            SendButton.Enabled = sendButton;
            AddFileButton.Enabled = addFileButton;
            RemoveButton.Enabled = removeButton;
            ClearButton.Enabled = clearButton;
        }
        private void AddFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Title = "Виберіть файл:";
            file.InitialDirectory = @"C:\Users\Max\Desktop\S\";
            if (file.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in file.FileNames)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                    FileHandler.AddFilePath(fileInfo.Name, path);
                    AddFileToList(path);
                }
            }
        }
        private void AddFileToList(string path)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
            SendList.Items.Add(fileInfo.Name, false);
        }
        private async void SendButton_Click(object sender, EventArgs e)
        {
            SendButton.Enabled = false;
            await Task.Run(()=> 
            {
                foreach (var path in FileHandler.GetFilePaths())
                {
                    NetworkConnection.SendFiles(path.Value);
                }
                FileHandler.GetFilePaths().Clear();
            });
            SendButton.Enabled = true;
        }
        public void AddStatus(string message)
        {
            DateTime time = DateTime.Now;
            Invoke((Action)(() =>
            {
                StatusBox.Text += $"[{time.ToLongTimeString()}] " + message + "\r\n";
                StatusBox.SelectionStart = StatusBox.Text.Length;
                StatusBox.ScrollToCaret();
            }));
        }
        private void UpdateLoadBar(long size, long value)
        {
            Invoke((Action)(() =>
            {
                LoadProgressBar.Value = (int)(value*100/ size);
            }));
        }
        private void UpdateLoadStatus(NetworkConnectionArgs e)
        {
            Invoke((Action)(() =>
            {
                FileNameStatus.Text = $"File Name: {e.FileName}";
                LoadInPercent.Text = $"{e.СurrentLength * 100 / e.FileLength} %";
                SpeedStatus.Text = String.Format("{0:f2} Mb/s",e.Speed/1000000);
                ByteStatus.Text = String.Format("{0}Mb/{1}Mb",(e.СurrentLength/1000000),(e.FileLength/1000000));
                TimeLoadStatus.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        e.Time.Hours, e.Time.Minutes, e.Time.Seconds,
                        e.Time.Milliseconds / 10);
            }));
        }
        private void UpdateReceiveOrSendList(string fileName)
        {
            Invoke((Action)(() =>
            {
                if (isServer)
                    ReceiveList.Items.Add(fileName, true);
                else
                    SendList.Items.Remove(fileName);
            }));
        }
        private void DownloadPathBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                FileHandler.DowloadPath = folderBrowser.SelectedPath;
                DownloadPathBox.Text = folderBrowser.SelectedPath;
            }
        }
        private async void Host_Click(object sender, EventArgs e)
        {
            ServerForm serverForm = new ServerForm();
            serverForm.ShowDialog(this);
            if (!serverForm.Start)
                return;

            if (!NetworkConnection.StartServer(serverForm.Port))
            {
                Notify?.Invoke("An error occurred while creating the server.");
                return;
            }
            else
                Notify?.Invoke("The server was successfully created.");

            await Task.Run(() =>
            {
                Notify?.Invoke("Waiting for user ...");
                if (!NetworkConnection.AcceptClient())
                {
                    Notify?.Invoke("Failed to wait for user.");
                    return;
                }
                else
                    Notify?.Invoke("The user has connected.");
            });
            isServer = true;
            serverForm.Dispose();
        }
        private async void ConnectToServer_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog(this);
            if (!clientForm.Start)
                return;

            Notify?.Invoke("Connecting to Server ...");
            SetButtonsEnabled(false, true, true, true);
            await Task.Run(() =>
            {
                if (!NetworkConnection.ConnectToServer(clientForm.IP,clientForm.Port))
                {
                    Notify?.Invoke("Failed to connect to server.");
                    SetButtonsEnabled(false, false, false, false);
                    return;
                }
                else
                    Notify?.Invoke("The connection was successful.");
            });
            SetButtonsEnabled(true, true, true, true);
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            NetworkConnection.Disconnect();
            if(isServer)
                Notify?.Invoke("Server disabled.");
            else
                Notify?.Invoke("The connection to the server was interrupted.");
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (var item in SendList.CheckedItems.OfType<string>().ToList())
            {
                SendList.Items.Remove(item);
                FileHandler.GetFilePaths().Remove(item);
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {

        }
    }
}
