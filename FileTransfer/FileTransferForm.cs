using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTransferForm : Form
    {
        Point _lastPoint;
        public FileTransferForm()
        {
            InitializeComponent();
            PortBox.Text = "1234";
        }

        private async void ServerButton_Click(object sender, EventArgs e)
        {
            if (!NetworkConnection.StartServer())
                return;
            else
                EventStatusLabel.Text = "Очікуємо підключення...";
            await Task.Run(()=> 
            {
                if (!NetworkConnection.AcceptClient())
                    return;
                else
                    EventStatusLabel.Text = "Клієнт приєднався.";
            });
        }

        private async void ClientButton_Click(object sender, EventArgs e)
        {
            int port;
            if(!int.TryParse(PortBox.Text, out port))
            {
                MessageBox.Show("Невірний порт.");
                return;
            }
            else
                EventStatusLabel.Text = "Очікуємо підключення...";
            await Task.Run(()=> 
            {
                if (NetworkConnection.ConnectToServer(port))
                    EventStatusLabel.Text = "Підключилися до серверу.";
                else
                {
                    EventStatusLabel.Text = "Сервер не відповідає.";
                    return;
                }
            });
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
