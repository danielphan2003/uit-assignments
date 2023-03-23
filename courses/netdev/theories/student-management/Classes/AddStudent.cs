using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern.Forms;
using SkiaSharp;

namespace student_management
{
    internal class AddStudentPane : TableLayoutPanel
    {
        private TextBox id;
        private TextBox name;
        private TextBox birth;
        private TextBox address;

        public AddStudentPane ()
        {
            ColumnCount = 2;
            RowCount = 4;

            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            RowStyles.Add (new RowStyle (SizeType.Percent, 25));
            RowStyles.Add (new RowStyle (SizeType.Percent, 25));
                RowStyles.Add (new RowStyle (SizeType.Percent, 25));
            RowStyles.Add (new RowStyle (SizeType.Percent, 25));

            id = new()
            {
                // Width = 150,
                Placeholder = "Leave blank for auto-generated ID",
                Dock = DockStyle.Fill,
            };

            Controls.Add(new Label {
                Text = "ID",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
            }, 0, 0);

            Controls.Add(id, 1, 0);

            name = new()
            {
                // Width = 150,
                Placeholder = "Student name",
                Dock = DockStyle.Fill,
            };

            Controls.Add(new Label {
                Text = "Name",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
            }, 0, 1);

            Controls.Add(name, 1, 1);

            birth = new()
            {
                Placeholder = "dd/MM/yyyy",
                Dock = DockStyle.Fill,
            };

            Controls.Add(new Label {
                Text = "Birth (dd/MM/yyyy)",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
            }, 0, 2);

            Controls.Add(birth, 1, 2);

            address = new()
            {
                Placeholder = "Student address",
                Dock = DockStyle.Fill,
                // Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };

            Controls.Add(new Label {
                Text = "Address",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
            }, 0, 3);

            Controls.Add(address, 1, 3);

            // Controls.Add(new )
        }
    }
}