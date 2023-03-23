using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace winforms_intro
{
    partial class Lab01_Bai05
    {
        private TableLayoutPanel controlPanel;
        private RangeTextBox<Int128> firstNumber;
        private RangeTextBox<Int128> secondNumber;
        private TableLayoutPanel resultPanel;
        private Label factorialFirstNumberLabel;
        private Label factorialSecondNumberLabel;
        private Label sumFirstLabel;
        private Label sumSecondLabel;
        private Label sumThirdLabel;

        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
            AutoSize = true;

            controlPanel = new()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                RowCount = 4,
            };
            
            Controls.Add(controlPanel);

            controlPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 10));
            controlPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 10));
            controlPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 50));
            controlPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 20));
            controlPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 10));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            controlPanel.Controls.Add(new Label {
                Text = "Nhập A",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0),
            });

            firstNumber = new()
            {
                Dock = DockStyle.Fill,
            };

            controlPanel.Controls.Add(firstNumber);
            controlPanel.SetColumnSpan(firstNumber, 2);

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            controlPanel.Controls.Add(new Label {
                Text = "Nhập B",
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0),
            });

            secondNumber = new()
            {
                Dock = DockStyle.Fill,
            };

            controlPanel.Controls.Add(secondNumber);
            controlPanel.SetColumnSpan(secondNumber, 2);

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            var calculateButton = new Button()
            {
                Text = "Tính các giá trị",
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            calculateButton.Click += new EventHandler(OnCalculateButtonClick);

            controlPanel.Controls.Add(calculateButton);
            controlPanel.SetColumnSpan(calculateButton, 2);

            var clearButton = new Button()
            {
                Text = "Xoá",
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            clearButton.Click += new EventHandler(OnClearButtonClick);

            controlPanel.Controls.Add(clearButton);

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            var resultGroupBox = new GroupBox()
            {
                Text = "Kết quả",
                Dock = DockStyle.Fill,
            };

            resultPanel = new()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
            };

            resultGroupBox.Controls.Add(resultPanel);

            resultPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 50));
            resultPanel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 50));
            resultPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            resultPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            resultPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            resultPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            factorialFirstNumberLabel = new()
            {
                Name = "A",
                Text = FormatFactorial("A", 0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 5, 0, 5),
                AutoSize = true,
                ForeColor = Color.Blue,
            };

            resultPanel.Controls.Add(factorialFirstNumberLabel);

            factorialSecondNumberLabel = new()
            {
                Name = "B",
                Text = FormatFactorial("B", 0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 5, 0, 5),
                AutoSize = true,
                ForeColor = Color.Blue,
            };

            resultPanel.Controls.Add(factorialSecondNumberLabel);

            sumFirstLabel = new()
            {
                Name = "A",
                Text = FormatTriangularSum("A", 0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 5, 0, 5),
                AutoSize = true,
                ForeColor = Color.Blue,
            };

            resultPanel.Controls.Add(sumFirstLabel);
            resultPanel.SetColumnSpan(sumFirstLabel, 2);

            sumSecondLabel = new()
            {
                Name = "B",
                Text = FormatTriangularSum("B", 0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 5, 0, 5),
                AutoSize = true,
                ForeColor = Color.Blue,
            };

            resultPanel.Controls.Add(sumSecondLabel);
            resultPanel.SetColumnSpan(sumSecondLabel, 2);

            sumThirdLabel = new()
            {
                Text = FormatThirdSum<int, double>(0, 0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(5, 5, 0, 5),
                AutoSize = true,
                ForeColor = Color.Blue,
            };

            resultPanel.Controls.Add(sumThirdLabel);
            resultPanel.SetColumnSpan(sumThirdLabel, 2);

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            controlPanel.Controls.Add(resultGroupBox);
            controlPanel.SetColumnSpan(resultGroupBox, 3);

            controlPanel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });
        }
    }
}
