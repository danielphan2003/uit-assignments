using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace winforms_intro
{
    partial class Lab01_Bai02
    {
        private TableLayoutPanel panel;
        private DoubleTextBox firstNumber;
        private DoubleTextBox secondNumber;
        private DoubleTextBox thirdNumber;
        private DoubleTextBox maxNumber;
        private DoubleTextBox minNumber;

        private void InitializeComponent()
        {
            panel = new() {
                Dock = DockStyle.Fill,
                ColumnCount = 8,
                RowCount = 3,
            };

            
            Controls.Add(panel);

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));



            panel.Controls.Add(new Label {
                Left = 10,
                Top = 80,
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
            
            panel.Controls.Add(firstNumber);



            panel.Controls.Add(new Label {
                Left = 10,
                Top = 80,
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
            
            panel.Controls.Add(secondNumber);
            panel.SetColumnSpan(secondNumber, 2);



            panel.Controls.Add(new Label {
                Left = 10,
                Top = 80,
                Text = "Số thứ ba",
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 7, 10, 0),
            });

            thirdNumber = new() {
                Name = "thirdNumber",
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
                Height = 10,
            };
            
            panel.Controls.Add(thirdNumber);



            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });



            var find = new Button
            {
                Text = "Tìm",
                Height = 45,
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 15, 0, 15),
            };

            find.Click += new EventHandler(FindClick);

            panel.Controls.Add(find);
            panel.SetColumnSpan(find, 3);


            var clear = new Button
            {
                Height = 45,
                Width = 100,
                Text = "Xoá",
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 15, 0, 15),
            };

            clear.Click += new EventHandler(ClearClick);

            panel.Controls.Add(clear);
            panel.SetColumnSpan(clear, 4);



            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });



            var maxNumberLabel = new Label {
                Left = 10,
                Top = 80,
                Text = "Số lớn nhất",
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 7, 10, 0),
            };

            panel.Controls.Add(maxNumberLabel);

            maxNumber = new() {
                Name = "maxNumber",
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
                Height = 10,
            };
            
            panel.Controls.Add(maxNumber);
            panel.SetColumnSpan(maxNumber, 2);



            var minNumberLabel = new Label {
                Left = 10,
                Top = 80,
                Text = "Số nhỏ nhất",
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 7, 10, 0),
            };

            panel.Controls.Add(minNumberLabel);

            minNumber = new() {
                Name = "minNumber",
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 6, 5, 5),
                Height = 10,
            };
            
            panel.Controls.Add(minNumber);
            panel.SetColumnSpan(minNumber, 3);



            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            // var bottomRow = new Control {
            //     Dock = DockStyle.Fill,
            // };
            
            // panel.Controls.Add(bottomRow);
            // panel.SetColumnSpan(bottomRow, 7);
        }
    }
}
