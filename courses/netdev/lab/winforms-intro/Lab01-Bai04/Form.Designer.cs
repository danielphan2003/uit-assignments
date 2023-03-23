using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace winforms_intro
{
    partial class Lab01_Bai04
    {
        private TableLayoutPanel panel;
        private ComboBox comboBox;
        private BindingSource bindingSource;
        private FlowLayoutPanel gasPanel;
        private Label kmLabel;
        private Label priceLabel;

        private void InitializeComponent()
        {
            panel = new() {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
            };
            
            Controls.Add(panel);

            panel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 70));
            panel.ColumnStyles.Add(new ColumnStyle (SizeType.Percent, 10));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            panel.Controls.Add(new Label {
                Text = "Chọn loại xe",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 10, 0),
            });

            comboBox = new()
            {
                Name = "comboBox",
                Dock = DockStyle.Fill,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems,
                Height = 10,
            };

            comboBox.SelectedIndexChanged += new EventHandler(OnComboBoxChange);

            panel.Controls.Add(comboBox);

            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            panel.Controls.Add(new Label {
                Text = "Chọn loại xăng",
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 10, 10, 0),
            });

            gasPanel = new()
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(0, 2, 0, 0),
            };

            foreach (var entry in GasType.All)
            {
                var radioButton = new RadioButton
                {
                    Name = entry.Key,
                    Text = entry.Value.Text,
                    AutoSize = true,
                };
                radioButton.CheckedChanged += new EventHandler(OnGasTypeChanged);
                gasPanel.Controls.Add(radioButton);
            }

            panel.Controls.Add(gasPanel);

            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            kmLabel = new()
            {
                Text = FormatKm(0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0, 5, 0, 5),
                AutoSize = true,
            };

            panel.Controls.Add(kmLabel);
            panel.SetColumnSpan(kmLabel, 2);
            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });

            priceLabel = new()
            {
                Text = FormatPrice(0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(0, 5, 0, 0),
                AutoSize = true,
            };

            panel.Controls.Add(priceLabel);
            panel.SetColumnSpan(priceLabel, 2);
            panel.Controls.Add(new Control {
                Dock = DockStyle.Fill,
            });
        }
    }
}
