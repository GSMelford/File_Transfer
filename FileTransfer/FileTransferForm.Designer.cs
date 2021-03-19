
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
            this.SendList = new System.Windows.Forms.CheckedListBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SendListLabel = new System.Windows.Forms.Label();
            this.ReceiveListLabel = new System.Windows.Forms.Label();
            this.ReceiveList = new System.Windows.Forms.CheckedListBox();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.RichTextBox();
            this.EventsLabel = new System.Windows.Forms.Label();
            this.DownloadFolderlabel = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LoadProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.LoadInPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.SpeedStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ByteStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeLoadStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Host = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutFileTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadPathBox = new System.Windows.Forms.TextBox();
            this.FileNameStatus = new System.Windows.Forms.Label();
            this.StatusStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendList
            // 
            this.SendList.FormattingEnabled = true;
            this.SendList.Location = new System.Drawing.Point(12, 91);
            this.SendList.Name = "SendList";
            this.SendList.ScrollAlwaysVisible = true;
            this.SendList.Size = new System.Drawing.Size(255, 264);
            this.SendList.TabIndex = 14;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.DimGray;
            this.SendButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.ForeColor = System.Drawing.Color.White;
            this.SendButton.Location = new System.Drawing.Point(187, 64);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(80, 25);
            this.SendButton.TabIndex = 17;
            this.SendButton.Text = "Send =>";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.DimGray;
            this.RemoveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RemoveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.RemoveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveButton.ForeColor = System.Drawing.Color.White;
            this.RemoveButton.Location = new System.Drawing.Point(101, 361);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(80, 25);
            this.RemoveButton.TabIndex = 18;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.DimGray;
            this.ClearButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(187, 361);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(80, 25);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            // 
            // SendListLabel
            // 
            this.SendListLabel.BackColor = System.Drawing.Color.Transparent;
            this.SendListLabel.ForeColor = System.Drawing.Color.White;
            this.SendListLabel.Location = new System.Drawing.Point(10, 64);
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
            this.ReceiveListLabel.Location = new System.Drawing.Point(284, 65);
            this.ReceiveListLabel.Name = "ReceiveListLabel";
            this.ReceiveListLabel.Size = new System.Drawing.Size(184, 24);
            this.ReceiveListLabel.TabIndex = 21;
            this.ReceiveListLabel.Text = "Отримані файли:";
            this.ReceiveListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReceiveList
            // 
            this.ReceiveList.FormattingEnabled = true;
            this.ReceiveList.Location = new System.Drawing.Point(287, 91);
            this.ReceiveList.Name = "ReceiveList";
            this.ReceiveList.ScrollAlwaysVisible = true;
            this.ReceiveList.Size = new System.Drawing.Size(255, 264);
            this.ReceiveList.TabIndex = 22;
            // 
            // AddFileButton
            // 
            this.AddFileButton.BackColor = System.Drawing.Color.DimGray;
            this.AddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.AddFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFileButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFileButton.ForeColor = System.Drawing.Color.White;
            this.AddFileButton.Location = new System.Drawing.Point(15, 361);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(80, 25);
            this.AddFileButton.TabIndex = 24;
            this.AddFileButton.Text = "Add File";
            this.AddFileButton.UseVisualStyleBackColor = false;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Font = new System.Drawing.Font("Open Sans SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusBox.Location = new System.Drawing.Point(15, 416);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(527, 73);
            this.StatusBox.TabIndex = 27;
            this.StatusBox.Text = "";
            // 
            // EventsLabel
            // 
            this.EventsLabel.BackColor = System.Drawing.Color.Transparent;
            this.EventsLabel.ForeColor = System.Drawing.Color.White;
            this.EventsLabel.Location = new System.Drawing.Point(12, 389);
            this.EventsLabel.Name = "EventsLabel";
            this.EventsLabel.Size = new System.Drawing.Size(56, 24);
            this.EventsLabel.TabIndex = 30;
            this.EventsLabel.Text = "Events:";
            this.EventsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DownloadFolderlabel
            // 
            this.DownloadFolderlabel.BackColor = System.Drawing.Color.Transparent;
            this.DownloadFolderlabel.ForeColor = System.Drawing.Color.White;
            this.DownloadFolderlabel.Location = new System.Drawing.Point(12, 36);
            this.DownloadFolderlabel.Name = "DownloadFolderlabel";
            this.DownloadFolderlabel.Size = new System.Drawing.Size(133, 24);
            this.DownloadFolderlabel.TabIndex = 33;
            this.DownloadFolderlabel.Text = "Downloads folder:";
            this.DownloadFolderlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadProgressBar,
            this.LoadInPercent,
            this.SpeedStatus,
            this.ByteStatus,
            this.TimeLoadStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 497);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.ShowItemToolTips = true;
            this.StatusStrip.Size = new System.Drawing.Size(554, 27);
            this.StatusStrip.TabIndex = 34;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // LoadProgressBar
            // 
            this.LoadProgressBar.Name = "LoadProgressBar";
            this.LoadProgressBar.Size = new System.Drawing.Size(180, 21);
            // 
            // LoadInPercent
            // 
            this.LoadInPercent.AutoSize = false;
            this.LoadInPercent.BackColor = System.Drawing.Color.Gainsboro;
            this.LoadInPercent.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LoadInPercent.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LoadInPercent.Font = new System.Drawing.Font("Open Sans SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadInPercent.ForeColor = System.Drawing.Color.Black;
            this.LoadInPercent.Name = "LoadInPercent";
            this.LoadInPercent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoadInPercent.Size = new System.Drawing.Size(50, 22);
            this.LoadInPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SpeedStatus
            // 
            this.SpeedStatus.AutoSize = false;
            this.SpeedStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.SpeedStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.SpeedStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.SpeedStatus.Font = new System.Drawing.Font("Open Sans SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedStatus.Name = "SpeedStatus";
            this.SpeedStatus.Size = new System.Drawing.Size(72, 22);
            this.SpeedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ByteStatus
            // 
            this.ByteStatus.AutoSize = false;
            this.ByteStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.ByteStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ByteStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.ByteStatus.Font = new System.Drawing.Font("Open Sans SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ByteStatus.Name = "ByteStatus";
            this.ByteStatus.Size = new System.Drawing.Size(132, 22);
            this.ByteStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TimeLoadStatus
            // 
            this.TimeLoadStatus.AutoSize = false;
            this.TimeLoadStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.TimeLoadStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TimeLoadStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.TimeLoadStatus.Font = new System.Drawing.Font("Open Sans SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLoadStatus.Name = "TimeLoadStatus";
            this.TimeLoadStatus.Size = new System.Drawing.Size(100, 22);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(554, 24);
            this.MenuStrip.TabIndex = 35;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Host,
            this.ConnectToServer,
            this.Disconnect});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Host
            // 
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(180, 22);
            this.Host.Text = "Host";
            this.Host.Click += new System.EventHandler(this.Host_Click);
            // 
            // ConnectToServer
            // 
            this.ConnectToServer.Name = "ConnectToServer";
            this.ConnectToServer.Size = new System.Drawing.Size(180, 22);
            this.ConnectToServer.Text = "Connect to server";
            this.ConnectToServer.Click += new System.EventHandler(this.ConnectToServer_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(180, 22);
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutFileTransferToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutFileTransferToolStripMenuItem
            // 
            this.aboutFileTransferToolStripMenuItem.Name = "aboutFileTransferToolStripMenuItem";
            this.aboutFileTransferToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.aboutFileTransferToolStripMenuItem.Text = "About File Transfer";
            // 
            // DownloadPathBox
            // 
            this.DownloadPathBox.Location = new System.Drawing.Point(142, 36);
            this.DownloadPathBox.Name = "DownloadPathBox";
            this.DownloadPathBox.Size = new System.Drawing.Size(400, 25);
            this.DownloadPathBox.TabIndex = 32;
            this.DownloadPathBox.Click += new System.EventHandler(this.DownloadPathBox_Click);
            // 
            // FileNameStatus
            // 
            this.FileNameStatus.BackColor = System.Drawing.Color.Transparent;
            this.FileNameStatus.ForeColor = System.Drawing.Color.White;
            this.FileNameStatus.Location = new System.Drawing.Point(284, 362);
            this.FileNameStatus.Name = "FileNameStatus";
            this.FileNameStatus.Size = new System.Drawing.Size(258, 24);
            this.FileNameStatus.TabIndex = 36;
            this.FileNameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(554, 524);
            this.Controls.Add(this.FileNameStatus);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.DownloadFolderlabel);
            this.Controls.Add(this.DownloadPathBox);
            this.Controls.Add(this.EventsLabel);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.AddFileButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ReceiveList);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ReceiveListLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SendListLabel);
            this.Controls.Add(this.SendList);
            this.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FileTransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox SendList;
        private Button SendButton;
        private Button RemoveButton;
        private Button ClearButton;
        private Label SendListLabel;
        private Label ReceiveListLabel;
        private CheckedListBox ReceiveList;
        private Button AddFileButton;
        private RichTextBox StatusBox;
        private Label EventsLabel;
        private Label DownloadFolderlabel;
        private StatusStrip StatusStrip;
        private ToolStripProgressBar LoadProgressBar;
        private ToolStripStatusLabel SpeedStatus;
        private ToolStripStatusLabel ByteStatus;
        private ToolStripStatusLabel TimeLoadStatus;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutFileTransferToolStripMenuItem;
        private ToolStripMenuItem Host;
        private ToolStripMenuItem ConnectToServer;
        private ToolStripMenuItem Disconnect;
        private TextBox DownloadPathBox;
        private Label FileNameStatus;
        private ToolStripStatusLabel LoadInPercent;
    }
}

