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
    class TableControl
    {
        //Number //File Name //ProgressBar //Precent //Speed //Size //Time
        TableLayoutPanel TopTable;
        TableLayoutPanel Table;
        ContextMenuStrip menu;
        private int HeightRow = 50;
        private int NowLoad = 1;
        public TableControl(TableLayoutPanel topTable, TableLayoutPanel table, ContextMenuStrip contextMenu)
        {
            TopTable = topTable;
            Table = table;
            menu = contextMenu;
        }
        private void RemoveItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem label = sender as ToolStripMenuItem;
            int index = label.Name.LastIndexOf('_');
            string number = string.Empty;
            for (int i = index+1; i < label.Name.Length; i++)
                number += label.Name[i];
            if (int.TryParse(number, out int num))
            {

            }
        }
        public TableLayoutPanel GetTopTable() => TopTable;
        public TableLayoutPanel GetTable() => Table;
        public void FillTopTable()
        {
            TopTable.Controls.AddRange(new Control[]
            {
               FormStyles.InitializeLabel("№", "numberLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("File Name", "fileNameLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("Load", "progressBarLable", new Point(0, 0)),
               FormStyles.InitializeLabel("%", "precentLable", new Point(0, 0)),
               FormStyles.InitializeLabel("Speed", "speedLable", new Point(0, 0)),
               FormStyles.InitializeLabel("Size", "sizeLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("Time", "timeLabel", new Point(0, 0))
            });
            
        }
        public void AddRow(string fileName, long size)
        {
            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = $"progressBar_{Table.RowCount}";
            progressBar.Dock = DockStyle.Top;
            progressBar.Size = new Size(0, 16);

            Table.Controls.AddRange(new Control[]
            {
               FormStyles.InitializeLabel(Table.RowCount.ToString(), $"number_{Table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel(fileName, $"fileName_{Table.RowCount}", new Point(0, 0)),
               progressBar,
               FormStyles.InitializeLabel("0%", $"precent_{Table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel("0 Mb/s", $"speed_{Table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel(String.Format("0.0 KB/ {0:f2} KB",size/1000), $"size_{Table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel("00:00:00.00", $"time_{Table.RowCount}", new Point(0, 0))
            });

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem removeItem = new ToolStripMenuItem("Remove");
            removeItem.Name = $"remove_{Table.RowCount}";
            menu.Items.Add(removeItem);
            removeItem.Click += RemoveItem_Click;

            Table.Controls[$"fileName_{Table.RowCount}"].ContextMenuStrip = menu;
            
            Table.RowCount++;
            Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            Table.Size = new Size(0, HeightRow * Table.RowCount);
        }
        public void UpdateTable(NetworkConnectionArgs args)
        {
            ProgressBar progressBar = (ProgressBar)Table.Controls[$"progressBar_{NowLoad}"];
            progressBar.Value = (int)((args.СurrentLength * 100) / args.FileLength);
            Table.Controls[$"precent_{NowLoad}"].Text = String.Format($"{(int)((args.СurrentLength * 100) / args.FileLength)} %");
            Table.Controls[$"speed_{NowLoad}"].Text = String.Format("{0:F2} MB/s", args.Speed / 1000000);
            Table.Controls[$"size_{NowLoad}"].Text = String.Format("{0:f2} KB/ {1:f2} KB", args.СurrentLength / 1000, args.FileLength / 1000);
            Table.Controls[$"time_{NowLoad}"].Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        args.Time.Hours, args.Time.Minutes, args.Time.Seconds,
                        args.Time.Milliseconds / 10);

            if ((int)((args.СurrentLength * 100) / args.FileLength) == 100)
                NowLoad++;
        }
    }
}
