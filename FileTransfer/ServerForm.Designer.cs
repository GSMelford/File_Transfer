
namespace FileTransfer
{
    partial class ServerForm
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
            this.ServerlLbel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerlLbel
            // 
            this.ServerlLbel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ServerlLbel.Font = new System.Drawing.Font("Open Sans SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerlLbel.Location = new System.Drawing.Point(0, 0);
            this.ServerlLbel.Name = "ServerlLbel";
            this.ServerlLbel.Size = new System.Drawing.Size(256, 49);
            this.ServerlLbel.TabIndex = 4;
            this.ServerlLbel.Text = "Host start:";
            this.ServerlLbel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Your port must be routed through a router!";
            // 
            // PortBox
            // 
            this.PortBox.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortBox.Location = new System.Drawing.Point(32, 77);
            this.PortBox.MaxLength = 6;
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(192, 29);
            this.PortBox.TabIndex = 7;
            this.PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Open Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortLabel.Location = new System.Drawing.Point(32, 52);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(47, 22);
            this.PortLabel.TabIndex = 8;
            this.PortLabel.Text = "Port:";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Open Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(32, 157);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(192, 48);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ServerForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 217);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ServerlLbel);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ServerForm";
            this.Text = "Host setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerlLbel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button StartButton;
    }
}