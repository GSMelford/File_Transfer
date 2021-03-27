using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class MainForm : Form
    {
        private Point mousePoint;
        private bool isServer = false;
        private bool ShowLog = true;
        private TableControl tableControl;
        public delegate void FileTransferFormHandler(string message);
        private event FileTransferFormHandler Notify;
        public MainForm()
        {
            InitializeComponent();
            
            tableControl = new TableControl(TopTable, Table, СontextMenuTable);

            LogPanel.Size = new Size(0, 32);
            EventsLog.Size = new Size();
            MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 32);
            Notify += AddLog;
            NetworkConnection.Notify += AddLog;
            NetworkConnection.ReceiveNotify += AddReceiveFile;
            FileHandler.DowloadPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            NetworkConnection.DownloadOrLoadStatistics += UpdateTableHandler;
        }
        private void UpdateTableHandler(NetworkConnectionArgs args)
        {
            Invoke((Action)(() => { tableControl.UpdateTable(args); }));
        }
        public void AddLog(string message)
        {
            try
            {
                Invoke((Action)(() => { EventsLog.Text += $"[{DateTime.Now.ToShortTimeString()}] {message}\r\n"; }));
            }
            catch (Exception)
            {
                return;
            }
        }
        private void HostButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            isServer = true;
            WindowLabel.Text = "Ctreate host:";

            string attentionText = "Attention! To create a server you must have:" +
                "\n1) Static IP Address." +
                "\n2) The port passed through the router(if you use it)." +
                "\n3) Your computer must be connected to the network via a cable." +
                "\n\nIf all these rules are sub-ice, enter the port to connect.";

            Button connectButton = FormStyles.InitializeButton("Create", "serverButton", new Point(19, 148), new Size(154, 32));
            connectButton.Click += new System.EventHandler(StartServerButton_Click);

            MainPanel.Controls.AddRange(new Control[] 
            { 
                connectButton,
                FormStyles.InitializeTextBox("1234", "portBox", new Point(20, 102), new Size(154, 32), FormStyles.SetFont(12),false,HorizontalAlignment.Center,6),
                FormStyles.InitializeTextBox(new WebClient().DownloadString("https://api.ipify.org"), "ipAdressBox", new Point(20, 40),
                new Size(154, 32), FormStyles.SetFont(12), true, HorizontalAlignment.Center, 39),
                FormStyles.InitializeLabel("Enter the port:", "portLabel", new Point(10, 74)),
                FormStyles.InitializeLabel("Here is your IP address:", "ipLabel", new Point(10, 10)),
                FormStyles.InitializeLabel(attentionText, "attentionLabel", new Point(0,0),ContentAlignment.MiddleLeft, true, null, FormStyles.SetFont(12), Color.Red, null, DockStyle.Bottom)
            });
        }
        private void ClientButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            isServer = false;
            WindowLabel.Text = "Connection to the host:";

            string attentionText = "You have to ask a friend in advance for which ip and port :)";

            Button connectButton = FormStyles.InitializeButton("Connect", "connectButton", new Point(19, 148), new Size(154, 32));
            connectButton.Click += new System.EventHandler(ConnectButton_Click);

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
        private void SetButtonsEnabled(bool hostButton, bool clientButton, bool disconnectButton)
        {
            Invoke((Action)(() => {
                HostButton.Enabled = hostButton;
                ClientButton.Enabled = clientButton;
                DisconnectButton.Enabled = disconnectButton;
            }));
        }
        private async void StartServerButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false, false, false);
            MainPanel.Controls["serverButton"].Enabled = false;

            await Task.Run(() =>
            {
                if (!int.TryParse(MainPanel.Controls["portBox"].Text, out int port))
                {
                    ShowLog = true;
                    ShowEventsButton_Click(null, null);
                    Notify?.Invoke("Invalid value in the port field.");

                    SetButtonsEnabled(true, true, false);
                    MainPanel.Controls["serverButton"].Enabled = true;

                    return;
                }

                if (!NetworkConnection.StartServer(port) || !NetworkConnection.AcceptClient())
                {
                    SetButtonsEnabled(true, true, false);
                    MainPanel.Controls["serverButton"].Enabled = true;
                    return;
                }

                CreateTables();
                SetButtonsEnabled(false, false, true);
                Invoke((Action)(() => { WindowLabel.Text = "Received files:"; }));
            });
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false, false, false);
            MainPanel.Controls["connectButton"].Enabled = false;

            if (!int.TryParse(MainPanel.Controls["portBox"].Text, out int port))
            {
                ShowLog = true;
                ShowEventsButton_Click(null, null);
                Notify?.Invoke("Invalid value in the port field.");

                SetButtonsEnabled(true, true, false);
                MainPanel.Controls["connectButton"].Enabled = true;

                return;
            }

            if (!NetworkConnection.ConnectToServer(MainPanel.Controls["ipAdressBox"].Text, port))
            {
                SetButtonsEnabled(true, true, false);
                MainPanel.Controls["connectButton"].Enabled = true;
                return;
            }
            CreateTables();
            SetButtonsEnabled(false, false, true);
            Invoke((Action)(() => { WindowLabel.Text = "Files sent:"; }));
        }
        private void CreateTables()
        {
            Invoke((Action)(() =>
            {
                MainPanel.Controls.Clear();
                MainPanel.Controls.AddRange(new Control[] { tableControl.GetTable(), tableControl.GetTopTable() });
                tableControl.FillTopTable();
                if (!isServer)
                {
                    AddFilesButton.Enabled = true;
                    SendButton.Enabled = true;
                    ClearButton.Enabled = true;
                }
            }));
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            NetworkConnection.Disconnect();
            MainPanel.Controls.Clear();
            SetButtonsEnabled(true, true, true);
            AddFilesButton.Enabled = false;
            SendButton.Enabled = false;
            ClearButton.Enabled = false;
        }
        //Управление панелью 
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }
        private void ProgramName_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void ProgramName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }
        private void ShowEventsButton_Click(object sender, EventArgs e)
        {
            Invoke((Action)(() =>
            {
                if (!ShowLog)
                {
                    LogPanel.Size = new Size(0, 32);
                    EventsLog.Size = new Size();
                    MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 32);
                    ShowLog = true;
                }
                else
                {
                    LogPanel.Size = new Size(0, 120);
                    EventsLog.Size = new Size(0, 88);
                    MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 120);
                    ShowLog = false;
                }
            }));
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (!ShowLog)
            {
                MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 120);
            }
            else
            {
                MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 32);
            }
        }
        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Title = "Select file:";
            file.InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            if (file.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in file.FileNames)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                    FileHandler.AddFilePath(fileInfo.Name, path);
                    tableControl.AddRow(fileInfo.Name, fileInfo.Length);
                }
            }
        }
        private async void SendButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (var path in FileHandler.GetFilePaths())
                {
                    NetworkConnection.SendFiles(path.Value);
                }
                FileHandler.GetFilePaths().Clear();
            });
        }
        private void AddReceiveFile(string fileName)
        {
            Invoke((Action)(() => { tableControl.AddRow(fileName, 0); }));
        }
        private void DownloadLabel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                FileHandler.DowloadPath = folderBrowser.SelectedPath;
            }
        }
    }
}
