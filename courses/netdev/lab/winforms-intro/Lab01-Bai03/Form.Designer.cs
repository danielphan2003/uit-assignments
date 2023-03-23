using System;
using System.Drawing;
using System.Windows.Forms;

namespace winforms_intro
{
    partial class Lab01_Bai03
    {
        private TableLayoutPanel panel;
        private RangeTextBox<ushort> number;
        private TextBox result;

        private void InitializeComponent()
        {
            panel = new() {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2,
            };
            
            Controls.Add(panel);

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            panel.Controls.Add(new Label {
                Text = "Nhập vào số nguyên dương từ 0 đến 9",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0),
            });

            number = new() {
                Name = "number",
                Dock = DockStyle.Fill,
                Height = 10,
                Padding = new Padding(10, 6, 5, 5),
                LowerBound = 0,
                UpperBound = 9,
            };
            
            panel.Controls.Add(number);

            var read = new Button
            {
                Text = "Đọc",
                Height = number.Height,
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            read.Click += new EventHandler(ReadClick);

            panel.Controls.Add(read);

            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            panel.Controls.Add(new Label {
                Text = "Kết quả",
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 7, 10, 0),
            });

            result = new() {
                Name = "result",
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
                Height = 10,
            };

            panel.Controls.Add(result);

            var clear = new Button
            {
                Text = "Xoá",
                Height = result.Height,
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            clear.Click += new EventHandler(ClearClick);

            panel.Controls.Add(clear);

            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });
        }
    }
}
