using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTransferForm : Form
    {
        private Point _lastPoint;
        private bool _isServer;
        public FileTransferForm()
        {
            InitializeComponent();
            DisconnectButton.Enabled = false;
            NetworkConnection.Notify += AddStatus;
            IPAdressBox.Text =new WebClient().DownloadString("https://api.ipify.org");
        }

        /*private void ButtonMove_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Aqua, 5);
            Graphics g = DropPanel.CreateGraphics();
            g.DrawRectangle(pen,0,0,DropPanel.Width-1,DropLabel.Height-1 );
            
        }

        private void DropPanel_DragDrop(object sender, DragEventArgs e)
        {
            DropLabel.Text = "Кидай, я поймаю!";
            List<string> paths = new List<string>();
            foreach (var obj in (string[]) e.Data.GetData(DataFormats.FileDrop))
            {
                if(Directory.Exists(obj))
                    paths.AddRange(Directory.GetFiles(obj,"*.*",SearchOption.AllDirectories));
                else
                    paths.Add(obj);
                FilePathLabel.Text = string.Join("\r\n", paths);
            }
                
        }

        private void DropPanel_DragLeave(object sender, EventArgs e)
        {
            DropLabel.Text = "Кидай, я поймаю!";
        }

        private void DropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DropLabel.Text = "Кидай!";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DropLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Укажите папку";
            file.InitialDirectory = @"C:\Users\Max\Desktop";
            if(file.ShowDialog() == DialogResult.OK)
            {
                FilePathLabel.Text = file.FileName;
            }
        }*/

        private void AddStatus(object sender, MyEventArgs e)
        {
            StatusBox.Text += $"[NetworkСonnection]: {e.Message}\r\n";
        }
        private void AddStatus(string message)
        {
            StatusBox.Text += $"{message}\r\n";
        }
        private void ShowFileList(List<string> paths)
        {
            foreach (var path in paths)
                AddStatus(path);
        }
        //Управление формой
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            
        }
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NameLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastPoint.X;
                this.Top += e.Y - _lastPoint.Y;
            }
        }
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastPoint.X;
                this.Top += e.Y - _lastPoint.Y;
            }
        }
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }
        private void NameLabel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }
        private void ServerStartButton_Click(object sender, EventArgs e)
        {
            int port;
            if (int.TryParse(PortBox.Text, out port) || !string.IsNullOrEmpty(PortBox.Text))
            {
                if (!NetworkConnection.ServerStart(port))
                    return;
            }
            else
            {
                MessageBox.Show("Некоректне значення порту.\nВведіть його у спеціальне вікно.",
                    "Некоректне значення порту",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = true;
            DisconnectButton.Text = "Зупинити";
            LoginButton.Enabled = false;
            ServerStartButton.Enabled = false;
            _isServer = true;
            NetworkConnection.AcceptClient();
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
            LoginButton.Enabled = true;
            ServerStartButton.Enabled = true;
            
            if (_isServer)
            {
                NetworkConnection.ServerStop();
                _isServer = false;
                DisconnectButton.Text = "Відключитися";
            }
            else
            {
                NetworkConnection.DisconnectFromServer();
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
                LoginButton.Enabled = true;
                ServerStartButton.Enabled = true;
            }
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Поле \"Ім'я\" повине бути заповнене..\nВведіть значення у спеціальне вікно.",
                    "Відсутнє ім'я користувача.",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            int port;
            if (int.TryParse(PortBox.Text, out port) || !string.IsNullOrEmpty(PortBox.Text))
            {
                if(!NetworkConnection.ConnectToServer(IPAdressBox.Text,port))
                    return;
            }
            else
                return;
            
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = true;
            LoginButton.Enabled = false;
            ServerStartButton.Enabled = false;
            
            NetworkConnection.SendMessage(NameBox.Text);
        }
        private void DragDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            DragDropLabel.Text = "Кидай сюди, я піймаю!";
            List<string> paths = new List<string>();
            foreach (var obj in (string[]) e.Data.GetData(DataFormats.FileDrop))
            {
                if(Directory.Exists(obj))
                    paths.AddRange(Directory.GetFiles(obj,"*.*",SearchOption.AllDirectories));
                else
                    paths.Add(obj);
            }
            FileHandler.AddPaths(paths);
            ShowFileList(paths);
        }
        private void DragDropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DragDropLabel.Text = "Кідай!";
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void DragDropPanel_DragLeave(object sender, EventArgs e)
        {
            DragDropLabel.Text = "Кидай сюди, я піймаю!";
        }
    }
}
