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
        //Number //File Name //ProgressBar //Precent //Speed //Size //Time
        private Point mousePoint;
        private bool isServer = false;
        private bool ShowLog = false;
        public delegate void FileTransferFormHandler(string message);
        private event FileTransferFormHandler Notify;

        public MainForm()
        {
            InitializeComponent();

            Table.Visible = false;
            TopTable.Visible = false;
            LogPanel.Size = new Size(0, 32);
            EventsLog.Size = new Size();
            MainPanel.Size = new Size(0, this.ClientSize.Height - 39 - 32);
            Notify += AddLog;
            NetworkConnection.Notify += AddLog;
        }

        public void AddLog(string message)
        {
            Invoke((Action)(() => { EventsLog.Text += $"[{DateTime.Now.ToShortTimeString()}] {message}\r\n"; }));
        }

        private T InitializeControl<T>(string text, string name, Point location, Size size, 
            Font font, Color forceColor, Color backColor, DockStyle style) where T : Control, new()
        {
            T control = new T
            {
                Text = text,
                Name = name,
                Location = location,
                Size = size,
                Font = font,
                ForeColor = forceColor,
                BackColor = backColor,
                Dock = style
            };

            return control;
        }

        private Label InitializeLabel(string text,string name, Point location, bool autoSize = true, Size? size = null,
            Font font = null, Color? forceColor = null, Color? backColor = null, DockStyle style = DockStyle.None)
        {
            Label label = InitializeControl<Label>(text, name, location, size??new Size(0,0), font ?? SetFont(), 
                forceColor ?? Color.White, backColor ?? Color.Transparent, style);
            label.AutoSize = autoSize;
            return label;
        }

        private TextBox InitializeTextBox(string text, string name, Point location, Size size, Font font = null, bool readOnly = false, 
            HorizontalAlignment? alignment = null, int maxLength = 32767, Color? forceColor = null, Color? backColor = null,DockStyle style = DockStyle.None)
        {
            TextBox textBox = InitializeControl<TextBox>(text, name, location, size, font ?? SetFont(), forceColor ?? Color.Black, backColor ?? Color.White, style);
            textBox.ReadOnly = readOnly;
            textBox.TextAlign = alignment ?? HorizontalAlignment.Left;
            textBox.MaxLength = maxLength;
            return textBox;
        }

        private Button InitializeButton(string text, string name, Point location, Size size, Color? mouseOverBackColor = null,
            Font font = null, Color? forceColor = null, Color? backColor = null, DockStyle style = DockStyle.None)
        {
            Button button = InitializeControl<Button>(text, name, location, size, font ?? SetFont(), forceColor ?? Color.White, 
                backColor ?? Color.FromArgb(13, 17, 23),style);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = true;
            button.FlatAppearance.MouseOverBackColor = mouseOverBackColor ?? Color.FromArgb(41, 50, 64);
            return button;
        }

        private Font SetFont(float size = 10, FontStyle style = FontStyle.Regular) => new Font("Calibri", size, style, GraphicsUnit.Point, ((byte)(0)));

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

            Button connectButton = InitializeButton("Create", "serverButton", new Point(19, 148), new Size(154, 32));
            connectButton.Click += new System.EventHandler(StartServerButton_Click);

            MainPanel.Controls.AddRange(new Control[] 
            { 
                connectButton,
                InitializeTextBox("1234", "portBox", new Point(20, 102), new Size(154, 32), SetFont(12),false,HorizontalAlignment.Center,6),
                InitializeTextBox(new WebClient().DownloadString("https://api.ipify.org"), "ipAdressBox", new Point(20, 40),
                new Size(154, 32), SetFont(12), true, HorizontalAlignment.Center, 39),
                InitializeLabel("Enter the port:", "portLabel", new Point(10, 74)),
                InitializeLabel("Here is your IP address:", "ipLabel", new Point(10, 10)),
                InitializeLabel(attentionText, "attentionLabel", new Point(0,0), true, null, SetFont(12), Color.Red, null, DockStyle.Bottom)
            });
        }
        private void ClientButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            isServer = false;
            WindowLabel.Text = "Connection to the host:";

            string attentionText = "You have to ask a friend in advance for which ip and port :)";

            Button connectButton = InitializeButton("Connect", "connectButton", new Point(19, 148), new Size(154, 32));
            connectButton.Click += new System.EventHandler(ConnectButton_Click);

            MainPanel.Controls.AddRange(new Control[]
            {
                connectButton,
                InitializeTextBox("", "portBox", new Point(20, 102), new Size(154, 32), SetFont(12),false,HorizontalAlignment.Center,6),
                InitializeTextBox("", "ipAdressBox", new Point(20, 40),
                new Size(154, 32), SetFont(12), false, HorizontalAlignment.Center, 39),
                InitializeLabel("Enter the port:", "portLabel", new Point(10, 74)),
                InitializeLabel("Here is your IP address:", "ipLabel", new Point(10, 10)),
                InitializeLabel(attentionText, "attentionLabel", new Point(0,0), true, null, SetFont(12), Color.LightGray, null, DockStyle.Bottom)
            });
        }

        private async void StartServerButton_Click(object sender, EventArgs e)
        {
            HostButton.Enabled = false;
            ClientButton.Enabled = false;
            DisconnectButton.Enabled = false;
            MainPanel.Controls["serverButton"].Enabled = false;

            await Task.Run(() =>
            {
                if (!int.TryParse(MainPanel.Controls["portBox"].Text, out int port))
                {
                    ShowLog = true;
                    ShowEventsButton_Click(null, null);
                    Notify?.Invoke("Invalid value in the port field.");

                    HostButton.Enabled = true;
                    ClientButton.Enabled = true;
                    DisconnectButton.Enabled = true;
                    MainPanel.Controls["serverButton"].Enabled = true;

                    return;
                }

                if (!NetworkConnection.StartServer(port) || !NetworkConnection.AcceptClient())
                {
                    HostButton.Enabled = true;
                    ClientButton.Enabled = true;
                    DisconnectButton.Enabled = true;
                    MainPanel.Controls["serverButton"].Enabled = true;
                    return;
                }
            });
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

        }



        private void DisconnectButton_Click(object sender, EventArgs e)
        {

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
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
