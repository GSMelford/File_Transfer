﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class ServerForm : Form
    {
        public bool Start;
        public int Port;
        public ServerForm()
        {
            InitializeComponent();
            PortBox.Text = "1234";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
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