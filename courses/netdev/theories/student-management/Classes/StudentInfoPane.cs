using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern.Forms;
using SkiaSharp;

namespace student_management
{
    internal class StudentInfoPane : Panel
    {
        // private SKBitmap image;
        private string message = "Add a new Student.";
        private Student student;

        public string Message
        {
            get => message;
            set => message = value;
        }

        public StudentInfoPane ()
        {
            // Controls.Add(new Label {
            //     Text = message,
            //     Width = 300,
            //     Dock = DockStyle.Fill,
            //     TextAlign = ContentAlignment.MiddleCenter,
            // });

            Controls.Add(new AddStudentPane {
                Height = 100,
                Width = 550,
                Margin = new Padding(50),
                Padding = new Padding(200),
                // Dock = DockStyle.Bottom,
            });
        }
    }
}