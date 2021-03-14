
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.IPAdressBox = new System.Windows.Forms.TextBox();
            this.IPAdressLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.DragDropPanel = new System.Windows.Forms.Panel();
            this.DragDropLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.NameUser = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.DragDropPanel.SuspendLayout();
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
            this.TopPanel.Size = new System.Drawing.Size(659, 32);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.BackColor = System.Drawing.Color.Black;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.MaximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.MaximizeButton.ForeColor = System.Drawing.Color.White;
            this.MaximizeButton.Location = new System.Drawing.Point(586, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(32, 32);
            this.MaximizeButton.TabIndex = 4;
            this.MaximizeButton.Text = "[ ]";
            this.MaximizeButton.UseVisualStyleBackColor = false;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.Black;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("Open Sans ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.Location = new System.Drawing.Point(548, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(32, 32);
            this.MinimizeButton.TabIndex = 3;
            this.MinimizeButton.Text = "__";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (128)))), ((int) (((byte) (128)))));
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(624, 0);
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
            this.NameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NameLabel_MouseDown);
            this.NameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NameLabel_MouseMove);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ConnectButton.ForeColor = System.Drawing.Color.White;
            this.ConnectButton.Location = new System.Drawing.Point(188, 56);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(115, 25);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Підключитися";
            this.ConnectButton.UseVisualStyleBackColor = false;
            // 
            // IPAdressBox
            // 
            this.IPAdressBox.BackColor = System.Drawing.Color.White;
            this.IPAdressBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPAdressBox.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.IPAdressBox.Location = new System.Drawing.Point(10, 56);
            this.IPAdressBox.MaxLength = 15;
            this.IPAdressBox.Name = "IPAdressBox";
            this.IPAdressBox.Size = new System.Drawing.Size(114, 25);
            this.IPAdressBox.TabIndex = 2;
            this.IPAdressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPAdressLabel
            // 
            this.IPAdressLabel.ForeColor = System.Drawing.Color.White;
            this.IPAdressLabel.Location = new System.Drawing.Point(10, 32);
            this.IPAdressLabel.Name = "IPAdressLabel";
            this.IPAdressLabel.Size = new System.Drawing.Size(70, 24);
            this.IPAdressLabel.TabIndex = 3;
            this.IPAdressLabel.Text = "IP Adress:";
            this.IPAdressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortLabel
            // 
            this.PortLabel.ForeColor = System.Drawing.Color.White;
            this.PortLabel.Location = new System.Drawing.Point(130, 32);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(48, 24);
            this.PortLabel.TabIndex = 4;
            this.PortLabel.Text = "Port:";
            this.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortBox
            // 
            this.PortBox.BackColor = System.Drawing.Color.White;
            this.PortBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortBox.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.PortBox.Location = new System.Drawing.Point(130, 56);
            this.PortBox.MaxLength = 5;
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(52, 25);
            this.PortBox.TabIndex = 5;
            this.PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusBox
            // 
            this.StatusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusBox.Location = new System.Drawing.Point(10, 87);
            this.StatusBox.Multiline = true;
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ReadOnly = true;
            this.StatusBox.Size = new System.Drawing.Size(414, 253);
            this.StatusBox.TabIndex = 6;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.DisconnectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisconnectButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.DisconnectButton.ForeColor = System.Drawing.Color.White;
            this.DisconnectButton.Location = new System.Drawing.Point(309, 56);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(115, 25);
            this.DisconnectButton.TabIndex = 7;
            this.DisconnectButton.Text = "Відключитися";
            this.DisconnectButton.UseVisualStyleBackColor = false;
            // 
            // DragDropPanel
            // 
            this.DragDropPanel.AllowDrop = true;
            this.DragDropPanel.BackColor = System.Drawing.Color.Gray;
            this.DragDropPanel.Controls.Add(this.DragDropLabel);
            this.DragDropPanel.Location = new System.Drawing.Point(430, 87);
            this.DragDropPanel.Name = "DragDropPanel";
            this.DragDropPanel.Size = new System.Drawing.Size(214, 253);
            this.DragDropPanel.TabIndex = 9;
            // 
            // DragDropLabel
            // 
            this.DragDropLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DragDropLabel.ForeColor = System.Drawing.Color.White;
            this.DragDropLabel.Location = new System.Drawing.Point(0, 0);
            this.DragDropLabel.Name = "DragDropLabel";
            this.DragDropLabel.Size = new System.Drawing.Size(214, 253);
            this.DragDropLabel.TabIndex = 0;
            this.DragDropLabel.Text = "Кидай сюди, я піймаю!";
            this.DragDropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.White;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameBox.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.NameBox.Location = new System.Drawing.Point(430, 56);
            this.NameBox.MaxLength = 10;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(71, 25);
            this.NameBox.TabIndex = 10;
            this.NameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(507, 56);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(64, 25);
            this.LoginButton.TabIndex = 11;
            this.LoginButton.Text = "Увійти";
            this.LoginButton.UseVisualStyleBackColor = false;
            // 
            // NameUser
            // 
            this.NameUser.ForeColor = System.Drawing.Color.White;
            this.NameUser.Location = new System.Drawing.Point(430, 32);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(48, 24);
            this.NameUser.TabIndex = 12;
            this.NameUser.Text = "Ім\'я:";
            this.NameUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Open Sans SemiBold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(576, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 13;
            this.button1.Text = "Сервер";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FileTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(656, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NameUser);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.DragDropPanel);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.IPAdressBox);
            this.Controls.Add(this.IPAdressLabel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileTransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.TopPanel.ResumeLayout(false);
            this.DragDropPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label DragDropLabel;

        private System.Windows.Forms.Label NameUser;

        private System.Windows.Forms.Button LoginButton;

        private System.Windows.Forms.TextBox NameBox;

        private System.Windows.Forms.Panel DragDropPanel;

        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.TextBox StatusBox;

        private System.Windows.Forms.TextBox PortBox;

        private System.Windows.Forms.Label PortLabel;

        private System.Windows.Forms.Label IPAdressLabel;

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox IPAdressBox;

        private System.Windows.Forms.Button MaximizeButton;

        private System.Windows.Forms.Button Minimi;
        private System.Windows.Forms.Button MinimizeButton;

        private System.Windows.Forms.Button ExitButton;

        private System.Windows.Forms.Label NameLabel;

        private System.Windows.Forms.Panel TopPanel;

        private System.Windows.Forms.Button ButtonMove;

        #endregion
    }
}

