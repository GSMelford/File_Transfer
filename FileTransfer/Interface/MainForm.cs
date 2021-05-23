using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileTransfer.FileWorker;
using FileTransfer.Interface.Settings;
using FileTransfer.Network;
using FileInfo = System.IO.FileInfo;

namespace FileTransfer.Interface
{
    public partial class MainForm : Form
    {
        private Point _mousePoint;
        
        private bool _showLog = true;

        private bool _dropEnabled;
        
        private readonly TableControl _tableControl;

        private delegate void FileTransferFormHandler(string message);
        
        private event FileTransferFormHandler Notify;
        
        public MainForm()
        {
            InitializeComponent();
            
            _tableControl = new TableControl(TopTable, Table, СontextMenuTable);

            LogPanel.Size = new Size(0, 32);
            EventsLog.Size = new Size();
            MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 32);
            Notify += AddLog;
            NetworkConnection.Notify += AddLog;
            NetworkConnection.ReceiveNotify += AddReceiveFile;
            FileHandler.DownloadPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            NetworkConnection.DownloadOrLoadStatistics += UpdateTableHandler;
        }
        
        private void UpdateTableHandler(NetworkConnectionArgs args)
        {
            Invoke((Action)(() =>
            {
                _tableControl.UpdateTable(args);
            }));
        }

        private void AddLog(string message)
        {
            try
            {
                Invoke((Action)(() =>
                {
                    EventsLog.Text += $"[{DateTime.Now.ToShortTimeString()}] {message}\r\n";
                }));
            }
            catch
            {
                // ignored
            }
        }
        
        private void HostButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            WindowLabel.Text = @"Create host:";

            const string attentionText = "To create a server you must have:" +
                                         "\n1) Static IP Address." +
                                         "\n2) The port passed through the router(if you use it)." +
                                         "\n3) Your computer must be connected to the network via a cable." +
                                         "\n\nIf all these rules are sub-ice, enter the port to connect.";

            Button connectButton = FormStyles.InitializeButton("Create", "serverButton", new Point(19, 148), new Size(154, 32));
            connectButton.Click += StartServerButton_Click;

            MainPanel.Controls.AddRange(new Control[] 
            { 
                connectButton,
                FormStyles.InitializeTextBox("1234", "portBox", new Point(20, 102), new Size(154, 32), FormStyles.SetFont(12),false,HorizontalAlignment.Center,6),
                FormStyles.InitializeTextBox(new WebClient().DownloadString("https://api.ipify.org"), "ipAddressBox", new Point(20, 40),
                    new Size(154, 32), FormStyles.SetFont(12), true, HorizontalAlignment.Center, 39),
                FormStyles.InitializeLabel("Enter the port:", "portLabel", new Point(10, 74)),
                FormStyles.InitializeLabel("Here is your IP address:", "ipLabel", new Point(10, 10))
            });

            MessageBox.Show(attentionText, "Attention!");
        }
        
        private void ClientButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            WindowLabel.Text = @"Connection to the host:";

            string attentionText = "Tip for you: You have to ask a friend in advance for which ip and port :)";

            Button connectButton = FormStyles.InitializeButton("Connect", "connectButton", new Point(19, 148), new Size(154, 32));
            connectButton.Click += ConnectButton_Click;

            MainPanel.Controls.AddRange(new Control[]
            {
                connectButton,
                FormStyles.InitializeTextBox("", "portBox", new Point(20, 102), new Size(154, 32), FormStyles.SetFont(12),false,HorizontalAlignment.Center,6),
                FormStyles.InitializeTextBox("", "ipAdressBox", new Point(20, 40),
                new Size(154, 32), FormStyles.SetFont(12), false, HorizontalAlignment.Center, 39),
                FormStyles.InitializeLabel("Enter the port:", "portLabel", new Point(10, 74)),
                FormStyles.InitializeLabel("Here is your IP address:", "ipLabel", new Point(10, 10)),
                FormStyles.InitializeLabel(attentionText, "attentionLabel", new Point(0,0),ContentAlignment.MiddleLeft, true, null, FormStyles.SetFont(12), Color.LightGray, null, DockStyle.Bottom)
            });
        }  
        
        private void SetButtonsEnabled(
            bool hostButton = false, 
            bool clientButton = false, 
            bool disconnectButton = false,
            bool addFilesButton = false,
            bool downloadButton = false,
            bool sendButton = false)
        {
            Invoke((Action)(() => {
                HostButton.Enabled = hostButton;
                ClientButton.Enabled = clientButton;
                DisconnectButton.Enabled = disconnectButton;
                AddFilesButton.Enabled = addFilesButton;
                DownloadButton.Enabled = downloadButton;
                SendButton.Enabled = sendButton;
            }));
        }
        
        private async void StartServerButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled();
            if (MainPanel.Controls["serverButton"] != null)
            {
                MainPanel.Controls["serverButton"].Enabled = false;
            }

            await Task.Run(() =>
            {
                if (!int.TryParse(MainPanel.Controls["portBox"].Text, out int port))
                {
                    _showLog = true;
                    ShowEventsButton_Click(null, null);
                    Notify?.Invoke("Invalid value in the port field.");

                    SetButtonsEnabled(true, true);
                    MainPanel.Controls["serverButton"].Enabled = true;

                    return;
                }

                if (!NetworkConnection.StartServer(port) || !NetworkConnection.AcceptClient())
                {
                    SetButtonsEnabled(true, true);
                    MainPanel.Controls["serverButton"].Enabled = true;
                    return;
                }

                new Task(ReceiveFiles).Start();
                
                CreateTables();
                
                Invoke((Action)(() => { WindowLabel.Text = "Received files:"; }));
                
                SetButtonsEnabled(
                    false, false,
                    true,false,
                    true);
            });
        }
        
        private void ReceiveFiles()
        {
            while (true)
            {
                if (!NetworkConnection.ReceiveFiles())
                {
                    NetworkConnection.Disconnect();
                    MessageBox.Show("We have lost the connection with the client. Restart the program and try again.",
                        "Oops...");
                    Environment.Exit(0);
                }

                _tableControl.NowLoad++;
            }
        }
        
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled();
            MainPanel.Controls["connectButton"].Enabled = false;

            if (!int.TryParse(MainPanel.Controls["portBox"].Text, out int port))
            {
                _showLog = true;
                ShowEventsButton_Click(null, null);
                Notify?.Invoke("Invalid value in the port field.");

                SetButtonsEnabled(true, true);
                MainPanel.Controls["connectButton"].Enabled = true;

                return;
            }

            if (!NetworkConnection.ConnectToServer(MainPanel.Controls["ipAdressBox"].Text, port))
            {
                SetButtonsEnabled(true, true);
                MainPanel.Controls["connectButton"].Enabled = true;
                return;
            }
            
            CreateTables();
            
            Invoke((Action)(() => { WindowLabel.Text = "Files sent:"; }));
            
            SetButtonsEnabled(
                false, false, 
                true,true, 
                false, true);
            _dropEnabled = true;
        }
        
        private void CreateTables()
        {
            Invoke((Action)(() =>
            {
                MainPanel.Controls.Clear();
                MainPanel.Controls.AddRange(new Control[] { _tableControl.GetTable(), _tableControl.GetTopTable() });
                _tableControl.FillTopTable();
            }));
        }
        
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            NetworkConnection.Disconnect();
            Environment.Exit(0);
        }
        
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = new Point(e.X, e.Y);
        }
        
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - _mousePoint.X;
            Top += e.Y - _mousePoint.Y;
        }
        
        private void ProgramName_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = new Point(e.X, e.Y);
        }
        
        private void ProgramName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - _mousePoint.X;
            Top += e.Y - _mousePoint.Y;
        }
        
        private void ShowEventsButton_Click(object sender, EventArgs e)
        {
            Invoke((Action)(() =>
            {
                if (!_showLog)
                {
                    LogPanel.Size = new Size(0, 32);
                    EventsLog.Size = new Size();
                    MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 32);
                    _showLog = true;
                }
                else
                {
                    LogPanel.Size = new Size(0, 120);
                    EventsLog.Size = new Size(0, 88);
                    MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 120);
                    _showLog = false;
                }
            }));
        }
        
        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainPanel.Size = !_showLog 
                ? new Size(0, this.ClientSize.Height - 39 - 120) 
                : new Size(0, this.ClientSize.Height - 39 - 32);
        }
        
        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select file:",
                InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}"
            };
            if (file.ShowDialog() != DialogResult.OK) return;
            foreach (var path in file.FileNames)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                FileHandler.AddFilePath(fileInfo.Name, path);
                _tableControl.AddRow(fileInfo.Name, fileInfo.Length);
            }
        }
        
        private async void SendButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false,false,true);
            await Task.Run(() =>
            {
                foreach (KeyValuePair<string,string> path in FileHandler.GetFilePaths())
                {
                    StartPosition:
                    if (!NetworkConnection.SendFiles(path.Value))
                    {
                        MessageBox.Show("We have lost contact with the client. We are waiting for reconnection.",
                            "Oops...");
                        NetworkConnection.TryConnectToServer();
                        goto StartPosition;
                    }
                    _tableControl.NowLoad++;
                }
                FileHandler.GetFilePaths().Clear();
            });
            SetButtonsEnabled(false,false,
                true, true,
                false,true);
        }
        
        private void AddReceiveFile(string fileName)
        {
            Invoke((Action)(() => { _tableControl.AddRow(fileName, 0); }));
        }
        
        private void DownloadLabel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                FileHandler.DownloadPath = folderBrowser.SelectedPath;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (_dropEnabled)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    BackColor = Color.Coral;
                    e.Effect = DragDropEffects.Copy;
                }
            }
                
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (_dropEnabled)
            {
                foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (Directory.Exists(obj))
                    {
                        foreach (var path in Directory.GetFiles(obj,".",SearchOption.AllDirectories))
                        {
                            FileInfo fileInfo = new FileInfo(path);
                            FileHandler.AddFilePath(fileInfo.Name, path);
                            _tableControl.AddRow(fileInfo.Name, fileInfo.Length);
                        }
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(obj);
                        FileHandler.AddFilePath(fileInfo.Name, obj);
                        _tableControl.AddRow(fileInfo.Name, fileInfo.Length);
                    }
                }
                BackColor = Color.FromArgb(108, 99, 150);
            }
        }

        private void MainForm_DragLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(108, 99, 150);
        }

    }
}
