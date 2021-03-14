using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTransferForm : Form
    {
        private Point LastPoint;
        public FileTransferForm()
        {
            InitializeComponent();
        }

        /*private void ButtonMove_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Aqua, 5);
            Graphics g = DropPanel.CreateGraphics();
            g.DrawRectangle(pen,0,0,DropPanel.Width-1,DropLabel.Height-1 );
            
        }

        private void DropPanel_DragDrop(object sender, DragEventArgs e)
        {
            DropLabel.Text = "Кидай, я поймаю!";
            List<string> paths = new List<string>();
            foreach (var obj in (string[]) e.Data.GetData(DataFormats.FileDrop))
            {
                if(Directory.Exists(obj))
                    paths.AddRange(Directory.GetFiles(obj,"*.*",SearchOption.AllDirectories));
                else
                    paths.Add(obj);
                FilePathLabel.Text = string.Join("\r\n", paths);
            }
                
        }

        private void DropPanel_DragLeave(object sender, EventArgs e)
        {
            DropLabel.Text = "Кидай, я поймаю!";
        }

        private void DropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DropLabel.Text = "Кидай!";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DropLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Укажите папку";
            file.InitialDirectory = @"C:\Users\Max\Desktop";
            if(file.ShowDialog() == DialogResult.OK)
            {
                FilePathLabel.Text = file.FileName;
            }
        }*/
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            
        }

        private void NameLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void NameLabel_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }
    }
}
