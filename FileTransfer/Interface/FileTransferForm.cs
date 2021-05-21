using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileTransfer.FileWorker;
using FileTransfer.Network;

namespace FileTransfer.Interface
{
    public partial class FileTransferForm : Form
    {
        private delegate void FileTransferFormHandler(string message);
        
        private event FileTransferFormHandler Notify;
        
        private bool _isServer;
        
        public FileTransferForm()
        {
            InitializeComponent();

            Notify += AddStatus;
            NetworkConnection.Notify += AddStatus;
            NetworkConnection.DownloadOrLoad += UpdateLoadBar;
            NetworkConnection.DownloadOrLoadStatistics += UpdateLoadStatus;

            FileHandler.DownloadPath = @"C:\Users\Max\Desktop\R\";
            DownloadPathBox.Text = FileHandler.DownloadPath;
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

        private void AddStatus(string message)
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
                LoadInPercent.Text = $"{e.CurrentLength * 100 / e.FileLength} %";
                SpeedStatus.Text = $"{e.Speed / 1000000:f2} Mb/s";
                ByteStatus.Text = $"{e.CurrentLength / 1000000}Mb/{(e.FileLength / 1000000)}Mb";
                TimeLoadStatus.Text =
                    $"{e.Time.Hours:00}:{e.Time.Minutes:00}:{e.Time.Seconds:00}.{e.Time.Milliseconds / 10:00}";
            }));
        }
        
        private void UpdateReceiveOrSendList(string fileName)
        {
            Invoke((Action)(() =>
            {
                if (_isServer)
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
                FileHandler.DownloadPath = folderBrowser.SelectedPath;
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
            
            Notify?.Invoke("The server was successfully created.");

            await Task.Run(() =>
            {
                Notify?.Invoke("Waiting for user ...");
                if (!NetworkConnection.AcceptClient())
                {
                    Notify?.Invoke("Failed to wait for user.");
                    return;
                }
                
                Notify?.Invoke("The user has connected.");
            });
            _isServer = true;
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
                
                Notify?.Invoke("The connection was successful.");
            });
            SetButtonsEnabled(true, true, true, true);
        }
        
        private void Disconnect_Click(object sender, EventArgs e)
        {
            NetworkConnection.Disconnect();
            Notify?.Invoke(_isServer ? "Server disabled." : "The connection to the server was interrupted.");
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
