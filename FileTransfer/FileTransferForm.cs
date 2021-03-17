using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTransferForm : Form
    {
        public delegate void FileTransferFormHandler(string message);
        private event FileTransferFormHandler Notify;
        Point _lastPoint;
        public FileTransferForm()
        {
            InitializeComponent();

            Notify += AddStatus;
            NetworkConnection.Notify += AddStatus;
            NetworkConnection.ReceiveNotify += AddFileToReceiveList;

            PortBox.Text = "1234";
            FileHandler.DowloadPath = @"C:\";
            SetButtonsEnabled(true, true, false, false, false, false, false);


        }

        private void SetButtonsEnabled(bool serverButton, bool clientButton, bool disconnectButton,
            bool sendButton, bool addFileButton, bool removeButton, bool clearButton)
        {
            ServerButton.Enabled = serverButton;
            ClientButton.Enabled = clientButton;
            DisconnectButton.Enabled = disconnectButton;
            SendButton.Enabled = sendButton;
            AddFileButton.Enabled = addFileButton;
            RemoveButton.Enabled = removeButton;
            ClearButton.Enabled = clearButton;
        }

        private async void ServerButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false, false, false, false, false, false, false);

            if (!NetworkConnection.StartServer())
            {
                Notify?.Invoke("Помилка при створені серверу.");
                SetButtonsEnabled(true, true, false, false, false, false, false);
            }
            else
                Notify?.Invoke("Сервер успішно створено.");

            await Task.Run(()=> 
            {
                Notify?.Invoke("Очікування користувача...");
                if (!NetworkConnection.AcceptClient())
                {
                    Notify?.Invoke("Збій в очікувані користувача.");
                    SetButtonsEnabled(true, true, false, false, false, false, false);
                }
                else
                    Notify?.Invoke("Користувач підключився.");
            });
        }
        private async void ClientButton_Click(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(PortBox.Text, out port))
            {
                MessageBox.Show("Невірний порт.");
                return;
            }
            Notify?.Invoke("Підключення до серверу...");
            SetButtonsEnabled(false, false, false, false, true, true, true);
            await Task.Run(()=> 
            {
                if (!NetworkConnection.ConnectToServer(port))
                {
                    Notify?.Invoke("Збій при підключені до серверу.");
                    return;
                }
                else
                    Notify?.Invoke("Підключення пройшло успішно.");
            });
            SetButtonsEnabled(true, true, false, true, true, true, true);
        }
        private void AddFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Виберіть файл:";
            file.InitialDirectory = @"C:\";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileHandler.AddFilePath(file.FileName);
                AddFileToList(file.FileName);
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
                    NetworkConnection.SendFiles(path);
                }
            });
            SendButton.Enabled = true;
        }
        public void AddStatus(string message)
        {
            Invoke((Action)(() =>
            {
                StatusBox.Text += message + "\r\n";
            }));
        }
        private void AddFileToReceiveList(string fileName)
        {
            ReceiveList.Items.Add(fileName, true);
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastPoint.X;
                this.Top += e.Y - _lastPoint.Y;
            }
        }
    }
}
