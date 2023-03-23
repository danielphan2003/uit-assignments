using System;
using System.Drawing;
using System.Windows.Forms;

namespace winforms_intro
{
    partial class Lab01_Bai01
    {
        private TableLayoutPanel panel;
        private IntegerTextBox firstNumber;
        private IntegerTextBox secondNumber;
        private IntegerTextBox result;

        private void InitializeComponent()
        {
            panel = new() {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
            };
            
            Controls.Add(panel);

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            panel.Controls.Add(new Label {
                Text = "Số thứ nhất",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0),
            });

            firstNumber = new() {
                Name = "firstNumber",
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
                Height = 10,
            };

            firstNumber.TextChanged += new EventHandler(OnNumberChanged);
            
            panel.Controls.Add(firstNumber);

            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            panel.Controls.Add(new Label {
                Text = "Số thứ hai",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0),
            });

            secondNumber = new() {
                Name = "secondNumber",
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
                Height = 10,
            };

            secondNumber.TextChanged += new EventHandler(OnNumberChanged);
            
            panel.Controls.Add(secondNumber);

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
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
            };
            
            panel.Controls.Add(result);

            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });
        }
    }
}
