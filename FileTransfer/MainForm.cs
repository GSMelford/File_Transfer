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
        public MainForm()
        {
            InitializeComponent();

            Table.Visible = false;
            TopTable.Visible = false;
        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            WindowLabel.Text = "Ctreate host:";

            Label label1 = new Label();
            label1.Text = "Attention! To create a server you must have:" +
                "\n1) Static IP Address." +
                "\n2) The port passed through the router(if you use it)." +
                "\n3) Your computer must be connected to the network via a cable." +
                "\n\nIf all these rules are sub-ice, enter the port to connect.";
            label1.Dock = DockStyle.Bottom;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;

            Label label2 = new Label();
            label2.Text = "Here is your IP address:";
            label2.Location = new Point(10, 10);
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.AutoSize = true;
            label2.ForeColor = Color.White;

            TextBox ipAdressBox = new TextBox();
            ipAdressBox.ReadOnly = true;
            ipAdressBox.Location = new Point(20, 40);
            ipAdressBox.Text = new WebClient().DownloadString("https://api.ipify.org");
            ipAdressBox.Size = new Size(154, 32);
            ipAdressBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ipAdressBox.TextAlign = HorizontalAlignment.Center;
            ipAdressBox.MaxLength = 39;

            Label label3 = new Label();
            label3.Text = "Enter the port:";
            label3.Location = new Point(10, 74);
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.AutoSize = true;
            label3.ForeColor = Color.White;

            TextBox portBox = new TextBox();
            portBox.Location = new Point(20, 102);
            portBox.Size = new Size(154, 32);
            portBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            portBox.TextAlign = HorizontalAlignment.Center;
            portBox.MaxLength = 6;

            Button button = new Button();
            button.Location = new Point(19, 148);
            button.Size = new Size(154, 48);
            button.BackColor = Color.FromArgb(22, 27, 34);
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(50)))), ((int)(((byte)(64)))));
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.Name = "CreateButton";
            button.Size = new System.Drawing.Size(157, 32);
            button.TabIndex = 6;
            button.Text = "Create";
            button.UseVisualStyleBackColor = true;

            this.AcceptButton = button;

            MainPanel.Controls.AddRange(new Control[] { button,portBox, label3, ipAdressBox, label2, label1 });



        }

        private void ClientButton_Click(object sender, EventArgs e)
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

        
    }
}
