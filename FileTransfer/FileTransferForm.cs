using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTransferForm : Form
    {
        public FileTransferForm()
        {
            InitializeComponent();
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
    }
}
