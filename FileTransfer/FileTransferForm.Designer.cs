
using System.Windows.Forms;

namespace FileTransfer
{
    partial class FileTransferForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopPanel = new System.Windows.Forms.Panel();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ClientButton = new System.Windows.Forms.Button();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ServerButton = new System.Windows.Forms.Button();
            this.SendList = new System.Windows.Forms.CheckedListBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SendListLabel = new System.Windows.Forms.Label();
            this.ReceiveListLabel = new System.Windows.Forms.Label();
            this.ReceiveList = new System.Windows.Forms.CheckedListBox();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.IPAdressLabel = new System.Windows.Forms.Label();
            this.IPAdressBox = new System.Windows.Forms.TextBox();
            this.StatusBox = new System.Windows.Forms.RichTextBox();
            this.LoadBar = new System.Windows.Forms.ProgressBar();
            this.LoadBarLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadPathButton = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Black;
            this.TopPanel.Controls.Add(this.MaximizeButton);
            this.TopPanel.Controls.Add(this.MinimizeButton);
            this.TopPanel.Controls.Add(this.ExitButton);
            this.TopPanel.Controls.Add(this.NameLabel);
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(900, 32);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.BackColor = System.Drawing.Color.Black;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.MaximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeButton.ForeColor = System.Drawing.Color.White;
            this.MaximizeButton.Location = new System.Drawing.Point(836, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(32, 32);
            this.MaximizeButton.TabIndex = 4;
            this.MaximizeButton.Text = "[ ]";
            this.MaximizeButton.UseVisualStyleBackColor = false;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.Black;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("Open Sans ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.Location = new System.Drawing.Point(804, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(32, 32);
            this.MinimizeButton.TabIndex = 3;
            this.MinimizeButton.Text = "__";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(868, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(100, 32);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "File Transfer";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientButton
            // 
            this.ClientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientButton.ForeColor = System.Drawing.Color.White;
            this.ClientButton.Location = new System.Drawing.Point(467, 40);
            this.ClientButton.Name = "ClientButton";
            this.ClientButton.Size = new System.Drawing.Size(115, 25);
            this.ClientButton.TabIndex = 1;
            this.ClientButton.Text = "Відправник";
            this.ClientButton.UseVisualStyleBackColor = false;
            this.ClientButton.Click += new System.EventHandler(this.ClientButton_Click);
            // 
            // PortLabel
            // 
            this.PortLabel.ForeColor = System.Drawing.Color.White;
            this.PortLabel.Location = new System.Drawing.Point(222, 40);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(48, 24);
            this.PortLabel.TabIndex = 4;
            this.PortLabel.Text = "Порт:";
            this.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortBox
            // 
            this.PortBox.BackColor = System.Drawing.Color.White;
            this.PortBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortBox.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortBox.Location = new System.Drawing.Point(276, 40);
            this.PortBox.MaxLength = 5;
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(64, 25);
            this.PortBox.TabIndex = 5;
            this.PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DisconnectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisconnectButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DisconnectButton.ForeColor = System.Drawing.Color.White;
            this.DisconnectButton.Location = new System.Drawing.Point(588, 40);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(115, 25);
            this.DisconnectButton.TabIndex = 7;
            this.DisconnectButton.Text = "Відключитися";
            this.DisconnectButton.UseVisualStyleBackColor = false;
            // 
            // ServerButton
            // 
            this.ServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ServerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerButton.ForeColor = System.Drawing.Color.White;
            this.ServerButton.Location = new System.Drawing.Point(346, 40);
            this.ServerButton.Name = "ServerButton";
            this.ServerButton.Size = new System.Drawing.Size(115, 25);
            this.ServerButton.TabIndex = 13;
            this.ServerButton.Text = "Отримувач";
            this.ServerButton.UseVisualStyleBackColor = false;
            this.ServerButton.Click += new System.EventHandler(this.ServerButton_Click);
            // 
            // SendList
            // 
            this.SendList.FormattingEnabled = true;
            this.SendList.Location = new System.Drawing.Point(140, 95);
            this.SendList.Name = "SendList";
            this.SendList.ScrollAlwaysVisible = true;
            this.SendList.Size = new System.Drawing.Size(225, 264);
            this.SendList.TabIndex = 14;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.ForeColor = System.Drawing.Color.White;
            this.SendButton.Location = new System.Drawing.Point(13, 95);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(115, 25);
            this.SendButton.TabIndex = 17;
            this.SendButton.Text = "Відправити";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RemoveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveButton.ForeColor = System.Drawing.Color.White;
            this.RemoveButton.Location = new System.Drawing.Point(13, 157);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(115, 25);
            this.RemoveButton.TabIndex = 18;
            this.RemoveButton.Text = "Видалити";
            this.RemoveButton.UseVisualStyleBackColor = false;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(13, 188);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(115, 25);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Очистити";
            this.ClearButton.UseVisualStyleBackColor = false;
            // 
            // SendListLabel
            // 
            this.SendListLabel.BackColor = System.Drawing.Color.Transparent;
            this.SendListLabel.ForeColor = System.Drawing.Color.White;
            this.SendListLabel.Location = new System.Drawing.Point(10, 68);
            this.SendListLabel.Name = "SendListLabel";
            this.SendListLabel.Size = new System.Drawing.Size(184, 24);
            this.SendListLabel.TabIndex = 20;
            this.SendListLabel.Text = "Файли для відправки:";
            this.SendListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReceiveListLabel
            // 
            this.ReceiveListLabel.BackColor = System.Drawing.Color.Transparent;
            this.ReceiveListLabel.ForeColor = System.Drawing.Color.White;
            this.ReceiveListLabel.Location = new System.Drawing.Point(368, 68);
            this.ReceiveListLabel.Name = "ReceiveListLabel";
            this.ReceiveListLabel.Size = new System.Drawing.Size(184, 24);
            this.ReceiveListLabel.TabIndex = 21;
            this.ReceiveListLabel.Text = "Отримані файли:";
            this.ReceiveListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReceiveList
            // 
            this.ReceiveList.FormattingEnabled = true;
            this.ReceiveList.Location = new System.Drawing.Point(371, 95);
            this.ReceiveList.Name = "ReceiveList";
            this.ReceiveList.ScrollAlwaysVisible = true;
            this.ReceiveList.Size = new System.Drawing.Size(225, 264);
            this.ReceiveList.TabIndex = 22;
            // 
            // AddFileButton
            // 
            this.AddFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFileButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFileButton.ForeColor = System.Drawing.Color.White;
            this.AddFileButton.Location = new System.Drawing.Point(13, 126);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(115, 25);
            this.AddFileButton.TabIndex = 24;
            this.AddFileButton.Text = "Додати файл";
            this.AddFileButton.UseVisualStyleBackColor = false;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // IPAdressLabel
            // 
            this.IPAdressLabel.ForeColor = System.Drawing.Color.White;
            this.IPAdressLabel.Location = new System.Drawing.Point(10, 40);
            this.IPAdressLabel.Name = "IPAdressLabel";
            this.IPAdressLabel.Size = new System.Drawing.Size(75, 24);
            this.IPAdressLabel.TabIndex = 25;
            this.IPAdressLabel.Text = "IP Адреса:";
            this.IPAdressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPAdressBox
            // 
            this.IPAdressBox.BackColor = System.Drawing.Color.White;
            this.IPAdressBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPAdressBox.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPAdressBox.Location = new System.Drawing.Point(90, 40);
            this.IPAdressBox.MaxLength = 5;
            this.IPAdressBox.Name = "IPAdressBox";
            this.IPAdressBox.Size = new System.Drawing.Size(125, 25);
            this.IPAdressBox.TabIndex = 26;
            this.IPAdressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusBox
            // 
            this.StatusBox.Location = new System.Drawing.Point(603, 95);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(285, 264);
            this.StatusBox.TabIndex = 27;
            this.StatusBox.Text = "";
            // 
            // LoadBar
            // 
            this.LoadBar.Location = new System.Drawing.Point(13, 387);
            this.LoadBar.Name = "LoadBar";
            this.LoadBar.Size = new System.Drawing.Size(875, 23);
            this.LoadBar.TabIndex = 28;
            // 
            // LoadBarLabel
            // 
            this.LoadBarLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoadBarLabel.ForeColor = System.Drawing.Color.White;
            this.LoadBarLabel.Location = new System.Drawing.Point(10, 360);
            this.LoadBarLabel.Name = "LoadBarLabel";
            this.LoadBarLabel.Size = new System.Drawing.Size(878, 24);
            this.LoadBarLabel.TabIndex = 29;
            this.LoadBarLabel.Text = "Ім\'я файлу. (Байтів з байтів)";
            this.LoadBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(600, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Події:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DownloadPathButton
            // 
            this.DownloadPathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DownloadPathButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DownloadPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadPathButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadPathButton.ForeColor = System.Drawing.Color.White;
            this.DownloadPathButton.Location = new System.Drawing.Point(13, 332);
            this.DownloadPathButton.Name = "DownloadPathButton";
            this.DownloadPathButton.Size = new System.Drawing.Size(115, 25);
            this.DownloadPathButton.TabIndex = 31;
            this.DownloadPathButton.Text = "Завантаження";
            this.DownloadPathButton.UseVisualStyleBackColor = false;
            // 
            // FileTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(900, 422);
            this.Controls.Add(this.DownloadPathButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoadBarLabel);
            this.Controls.Add(this.LoadBar);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ServerButton);
            this.Controls.Add(this.ClientButton);
            this.Controls.Add(this.IPAdressBox);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.IPAdressLabel);
            this.Controls.Add(this.AddFileButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ReceiveList);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ReceiveListLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SendListLabel);
            this.Controls.Add(this.SendList);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileTransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button ServerButton;

        private System.Windows.Forms.Button DisconnectButton;

        private System.Windows.Forms.TextBox PortBox;

        private System.Windows.Forms.Label PortLabel;

        private System.Windows.Forms.Button ClientButton;

        private System.Windows.Forms.Button MaximizeButton;

        private System.Windows.Forms.Button Minimi;
        private System.Windows.Forms.Button MinimizeButton;

        private System.Windows.Forms.Button ExitButton;

        private System.Windows.Forms.Label NameLabel;

        private System.Windows.Forms.Panel TopPanel;

        private System.Windows.Forms.Button ButtonMove;

        #endregion

        private CheckedListBox SendList;
        private Button SendButton;
        private Button RemoveButton;
        private Button ClearButton;
        private Label SendListLabel;
        private Label ReceiveListLabel;
        private CheckedListBox ReceiveList;
        private Button AddFileButton;
        private Label IPAdressLabel;
        private TextBox IPAdressBox;
        private RichTextBox StatusBox;
        private ProgressBar LoadBar;
        private Label LoadBarLabel;
        private Label label2;
        private Button DownloadPathButton;
    }
}

