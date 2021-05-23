
namespace FileTransfer.Interface
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ClientButton = new System.Windows.Forms.Button();
            this.HostButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.TopTable = new System.Windows.Forms.TableLayoutPanel();
            this.ProgramName = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.WindowLabel = new System.Windows.Forms.Label();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.ShowEventsButton = new System.Windows.Forms.Button();
            this.EventsLog = new System.Windows.Forms.RichTextBox();
            this.СontextMenuTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(89)))), ((int)(((byte)(156)))));
            this.MenuPanel.Controls.Add(this.DownloadButton);
            this.MenuPanel.Controls.Add(this.SendButton);
            this.MenuPanel.Controls.Add(this.AddFilesButton);
            this.MenuPanel.Controls.Add(this.VersionLabel);
            this.MenuPanel.Controls.Add(this.DisconnectButton);
            this.MenuPanel.Controls.Add(this.ClientButton);
            this.MenuPanel.Controls.Add(this.HostButton);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 39);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(172, 529);
            this.MenuPanel.TabIndex = 1;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DownloadButton.FlatAppearance.BorderSize = 0;
            this.DownloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.DownloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(181)))));
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.DownloadButton.ForeColor = System.Drawing.Color.White;
            this.DownloadButton.Location = new System.Drawing.Point(0, 418);
            this.DownloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(172, 39);
            this.DownloadButton.TabIndex = 11;
            this.DownloadButton.Text = "Download Folder";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadLabel_Click);
            // 
            // SendButton
            // 
            this.SendButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SendButton.Enabled = false;
            this.SendButton.FlatAppearance.BorderSize = 0;
            this.SendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.SendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(181)))));
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.SendButton.ForeColor = System.Drawing.Color.White;
            this.SendButton.Location = new System.Drawing.Point(0, 457);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(172, 39);
            this.SendButton.TabIndex = 10;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddFilesButton.Enabled = false;
            this.AddFilesButton.FlatAppearance.BorderSize = 0;
            this.AddFilesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.AddFilesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(181)))));
            this.AddFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFilesButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.AddFilesButton.ForeColor = System.Drawing.Color.White;
            this.AddFilesButton.Location = new System.Drawing.Point(0, 117);
            this.AddFilesButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(172, 39);
            this.AddFilesButton.TabIndex = 8;
            this.AddFilesButton.Text = "AddFiles";
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.VersionLabel.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.VersionLabel.ForeColor = System.Drawing.Color.White;
            this.VersionLabel.Location = new System.Drawing.Point(0, 496);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(172, 33);
            this.VersionLabel.TabIndex = 7;
            this.VersionLabel.Text = "Version 1.0.1";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.FlatAppearance.BorderSize = 0;
            this.DisconnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.DisconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(181)))));
            this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisconnectButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.DisconnectButton.ForeColor = System.Drawing.Color.White;
            this.DisconnectButton.Location = new System.Drawing.Point(0, 78);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(172, 39);
            this.DisconnectButton.TabIndex = 6;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ClientButton
            // 
            this.ClientButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientButton.FlatAppearance.BorderSize = 0;
            this.ClientButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.ClientButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(181)))));
            this.ClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.ClientButton.ForeColor = System.Drawing.Color.White;
            this.ClientButton.Location = new System.Drawing.Point(0, 39);
            this.ClientButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClientButton.Name = "ClientButton";
            this.ClientButton.Size = new System.Drawing.Size(172, 39);
            this.ClientButton.TabIndex = 5;
            this.ClientButton.Text = "Sender";
            this.ClientButton.UseVisualStyleBackColor = true;
            this.ClientButton.Click += new System.EventHandler(this.ClientButton_Click);
            // 
            // HostButton
            // 
            this.HostButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(89)))), ((int)(((byte)(156)))));
            this.HostButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.HostButton.FlatAppearance.BorderSize = 0;
            this.HostButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.HostButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(114)))), ((int)(((byte)(181)))));
            this.HostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HostButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.HostButton.ForeColor = System.Drawing.Color.White;
            this.HostButton.Location = new System.Drawing.Point(0, 0);
            this.HostButton.Margin = new System.Windows.Forms.Padding(4);
            this.HostButton.Name = "HostButton";
            this.HostButton.Size = new System.Drawing.Size(172, 39);
            this.HostButton.TabIndex = 4;
            this.HostButton.Text = "Receiver";
            this.HostButton.UseVisualStyleBackColor = false;
            this.HostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.Table);
            this.MainPanel.Controls.Add(this.TopTable);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainPanel.ForeColor = System.Drawing.Color.White;
            this.MainPanel.Location = new System.Drawing.Point(172, 39);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(894, 142);
            this.MainPanel.TabIndex = 2;
            // 
            // Table
            // 
            this.Table.BackColor = System.Drawing.Color.Transparent;
            this.Table.ColumnCount = 7;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.Table.Cursor = System.Windows.Forms.Cursors.Default;
            this.Table.Dock = System.Windows.Forms.DockStyle.Top;
            this.Table.Location = new System.Drawing.Point(0, 39);
            this.Table.Margin = new System.Windows.Forms.Padding(4);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Table.Size = new System.Drawing.Size(894, 50);
            this.Table.TabIndex = 1;
            // 
            // TopTable
            // 
            this.TopTable.AutoScroll = true;
            this.TopTable.BackColor = System.Drawing.Color.Transparent;
            this.TopTable.ColumnCount = 7;
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TopTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TopTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopTable.Location = new System.Drawing.Point(0, 0);
            this.TopTable.Margin = new System.Windows.Forms.Padding(4);
            this.TopTable.Name = "TopTable";
            this.TopTable.RowCount = 1;
            this.TopTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.TopTable.Size = new System.Drawing.Size(894, 39);
            this.TopTable.TabIndex = 0;
            // 
            // ProgramName
            // 
            this.ProgramName.BackColor = System.Drawing.Color.Transparent;
            this.ProgramName.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProgramName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramName.ForeColor = System.Drawing.Color.White;
            this.ProgramName.Location = new System.Drawing.Point(0, 0);
            this.ProgramName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProgramName.Name = "ProgramName";
            this.ProgramName.Size = new System.Drawing.Size(172, 39);
            this.ProgramName.TabIndex = 1;
            this.ProgramName.Text = "Menu";
            this.ProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgramName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgramName_MouseDown);
            this.ProgramName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgramName_MouseMove);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(61)))), ((int)(((byte)(107)))));
            this.TopPanel.Controls.Add(this.WindowLabel);
            this.TopPanel.Controls.Add(this.ProgramName);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1066, 39);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            // 
            // WindowLabel
            // 
            this.WindowLabel.BackColor = System.Drawing.Color.Transparent;
            this.WindowLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowLabel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowLabel.ForeColor = System.Drawing.Color.White;
            this.WindowLabel.Location = new System.Drawing.Point(172, 0);
            this.WindowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WindowLabel.Name = "WindowLabel";
            this.WindowLabel.Size = new System.Drawing.Size(338, 39);
            this.WindowLabel.TabIndex = 2;
            this.WindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogPanel
            // 
            this.LogPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(61)))), ((int)(((byte)(107)))));
            this.LogPanel.Controls.Add(this.ShowEventsButton);
            this.LogPanel.Controls.Add(this.EventsLog);
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogPanel.Location = new System.Drawing.Point(172, 448);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(894, 120);
            this.LogPanel.TabIndex = 3;
            // 
            // ShowEventsButton
            // 
            this.ShowEventsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ShowEventsButton.FlatAppearance.BorderSize = 0;
            this.ShowEventsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(143)))), ((int)(((byte)(219)))));
            this.ShowEventsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(114)))), ((int)(((byte)(156)))));
            this.ShowEventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowEventsButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.ShowEventsButton.ForeColor = System.Drawing.Color.White;
            this.ShowEventsButton.Location = new System.Drawing.Point(0, 0);
            this.ShowEventsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ShowEventsButton.Name = "ShowEventsButton";
            this.ShowEventsButton.Size = new System.Drawing.Size(60, 32);
            this.ShowEventsButton.TabIndex = 8;
            this.ShowEventsButton.Text = "Events";
            this.ShowEventsButton.UseVisualStyleBackColor = true;
            this.ShowEventsButton.Click += new System.EventHandler(this.ShowEventsButton_Click);
            // 
            // EventsLog
            // 
            this.EventsLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(99)))), ((int)(((byte)(150)))));
            this.EventsLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EventsLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.EventsLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventsLog.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventsLog.ForeColor = System.Drawing.Color.White;
            this.EventsLog.Location = new System.Drawing.Point(0, 32);
            this.EventsLog.Name = "EventsLog";
            this.EventsLog.ReadOnly = true;
            this.EventsLog.Size = new System.Drawing.Size(894, 88);
            this.EventsLog.TabIndex = 0;
            this.EventsLog.Text = "";
            // 
            // СontextMenuTable
            // 
            this.СontextMenuTable.Name = "СontextMenuTable";
            this.СontextMenuTable.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(99)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(1066, 568);
            this.Controls.Add(this.LogPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragLeave += new System.EventHandler(this.MainForm_DragLeave);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MenuPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.LogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button DownloadButton;

        #endregion
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button HostButton;
        private System.Windows.Forms.Button ClientButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TableLayoutPanel TopTable;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.Label ProgramName;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label WindowLabel;
        private System.Windows.Forms.Panel LogPanel;
        private System.Windows.Forms.RichTextBox EventsLog;
        private System.Windows.Forms.Button ShowEventsButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.ContextMenuStrip СontextMenuTable;
    }
}