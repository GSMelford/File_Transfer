
namespace FileTransfer
{
    partial class ClientForm
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
            this.IPAdressLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.IPAdressBox = new System.Windows.Forms.TextBox();
            this.HostlLbel = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IPAdressLabel
            // 
            this.IPAdressLabel.AutoSize = true;
            this.IPAdressLabel.Font = new System.Drawing.Font("Open Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPAdressLabel.Location = new System.Drawing.Point(32, 49);
            this.IPAdressLabel.Name = "IPAdressLabel";
            this.IPAdressLabel.Size = new System.Drawing.Size(86, 22);
            this.IPAdressLabel.TabIndex = 0;
            this.IPAdressLabel.Text = "IP Adress:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Open Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortLabel.Location = new System.Drawing.Point(32, 119);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(47, 22);
            this.PortLabel.TabIndex = 1;
            this.PortLabel.Text = "Port:";
            // 
            // IPAdressBox
            // 
            this.IPAdressBox.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPAdressBox.Location = new System.Drawing.Point(32, 76);
            this.IPAdressBox.MaxLength = 39;
            this.IPAdressBox.Name = "IPAdressBox";
            this.IPAdressBox.Size = new System.Drawing.Size(192, 29);
            this.IPAdressBox.TabIndex = 0;
            this.IPAdressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HostlLbel
            // 
            this.HostlLbel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HostlLbel.Font = new System.Drawing.Font("Open Sans SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HostlLbel.Location = new System.Drawing.Point(0, 0);
            this.HostlLbel.Name = "HostlLbel";
            this.HostlLbel.Size = new System.Drawing.Size(256, 49);
            this.HostlLbel.TabIndex = 3;
            this.HostlLbel.Text = "Connect To Server";
            this.HostlLbel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortBox
            // 
            this.PortBox.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortBox.Location = new System.Drawing.Point(32, 144);
            this.PortBox.MaxLength = 6;
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(192, 29);
            this.PortBox.TabIndex = 1;
            this.PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Open Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(32, 203);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(192, 48);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HostForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 281);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.HostlLbel);
            this.Controls.Add(this.IPAdressBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.IPAdressLabel);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "HostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IPAdressLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox IPAdressBox;
        private System.Windows.Forms.Label HostlLbel;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Button StartButton;
    }
}