using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern.Forms;

namespace student_management
{
    
    internal class StudentListItem : TreeViewItem
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }

        public StudentListItem (string id, string name, DateTime birth, string address)
        {
            Text = id;
            Name = name;
            Birth = birth;
            Address = address;
        }

        public override Size GetPreferredSize (Size proposedSize)
        {
            var height = LogicalToDeviceUnits (65);

            return new Size (0, height);
        }

        private int LogicalToDeviceUnits (int value) => TreeView?.LogicalToDeviceUnits (value) ?? value;
    }
}