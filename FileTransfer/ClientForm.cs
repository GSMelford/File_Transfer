using System;
using System.Net;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class ClientForm : Form
    {
        public bool Start = false;
        public string IP;
        public int Port;
        public ClientForm()
        {
            InitializeComponent();
            IPAdressBox.Text = new WebClient().DownloadString("https://api.ipify.org");
            PortBox.Text = "1234";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(IPAdressBox.Text, out ip))
                IP = IPAdressBox.Text;
            else
                return;

            int port;
            if (int.TryParse(PortBox.Text, out port))
                Port = port;
            else
                return;

            Start = true;
            Close();
        }
    }
}
