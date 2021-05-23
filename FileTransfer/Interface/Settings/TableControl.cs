using System;
using System.Drawing;
using System.Windows.Forms;
using FileTransfer.Network;

namespace FileTransfer.Interface.Settings
{
    internal class TableControl
    {
        //Number //File Name //ProgressBar //Percent //Speed //Size //Time
        
        private readonly TableLayoutPanel _topTable;
        private readonly TableLayoutPanel _table;
        private ContextMenuStrip _menu;
        private const int HeightRow = 50;
        private int _nowLoad = 1;
        
        public TableControl(TableLayoutPanel topTable, TableLayoutPanel table, ContextMenuStrip contextMenu)
        {
            _topTable = topTable;
            _table = table;
            _menu = contextMenu;
        }
        
        private static void RemoveItem_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem label)) return;
            
            int index = label.Name.LastIndexOf('_');
            
            string number = string.Empty;
            
            for (int i = index+1; i < label.Name.Length; i++)
                number += label.Name[i];
            
            if (int.TryParse(number, out int num))
            {
                //TODO Remove row
            }
        }
        
        public TableLayoutPanel GetTopTable() => _topTable;
        
        public TableLayoutPanel GetTable() => _table;
        
        public void FillTopTable()
        {
            _topTable.Controls.AddRange(new Control[]
            {
               FormStyles.InitializeLabel("№", "numberLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("File Name", "fileNameLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("Load", "progressBarLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("%", "percentLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("Speed", "speedLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("Size", "sizeLabel", new Point(0, 0)),
               FormStyles.InitializeLabel("Time", "timeLabel", new Point(0, 0))
            });
            
        }
        
        public void AddRow(string fileName, long size)
        {
            ProgressBar progressBar = new ProgressBar
            {
                Name = $"progressBar_{_table.RowCount}", Dock = DockStyle.Top, Size = new Size(0, 16)
            };

            _table.Controls.AddRange(new Control[]
            {
               FormStyles.InitializeLabel(_table.RowCount.ToString(), $"number_{_table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel(fileName, $"fileName_{_table.RowCount}", new Point(0, 0)), 
               progressBar,
               FormStyles.InitializeLabel("0%", $"percent_{_table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel("0 Mb/s", $"speed_{_table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel($"0.0 KB/ {size / 1000:f2} KB", $"size_{_table.RowCount}", new Point(0, 0)),
               FormStyles.InitializeLabel("00:00:00.00", $"time_{_table.RowCount}", new Point(0, 0))
            });

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem removeItem = new ToolStripMenuItem("Remove") {Name = $"remove_{_table.RowCount}"};
            menu.Items.Add(removeItem);
            removeItem.Click += RemoveItem_Click;

            _table.Controls[$"fileName_{_table.RowCount}"].ContextMenuStrip = menu;
            
            _table.RowCount++;
            _table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            _table.Size = new Size(0, HeightRow * _table.RowCount);
        }
        
        public void UpdateTable(NetworkConnectionArgs args)
        {
            ProgressBar progressBar = (ProgressBar)_table.Controls[$"progressBar_{_nowLoad}"];
            progressBar.Value = (int)((args.CurrentLength * 100) / args.FileLength);
            _table.Controls[$"percent_{_nowLoad}"].Text = string.Format($"{(int)((args.CurrentLength * 100) / args.FileLength)} %");
            _table.Controls[$"speed_{_nowLoad}"].Text = $@"{args.Speed / 1000000:F2} MB/s";
            _table.Controls[$"size_{_nowLoad}"].Text =
                $@"{args.CurrentLength / 1000:f2} KB/ {args.FileLength / 1000:f2} KB";
            _table.Controls[$"time_{_nowLoad}"].Text =
                $@"{args.Time.Hours:00}:{args.Time.Minutes:00}:{args.Time.Seconds:00}.{args.Time.Milliseconds / 10:00}";

            if ((int)(args.CurrentLength * 100 / args.FileLength) == 100)
                _nowLoad++;
        }
        
    }
}
