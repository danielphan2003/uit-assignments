using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
// using System.Windows.Forms;
using Modern.Forms;
using Dapper;

namespace student_management
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;
        private readonly string connectionString = @"Server=.\SQLEXPRESS;Trusted_Connection=True;TrustServerCertificate=Yes";

        public MainForm()
        {
            InitializeComponent();
            SqlInitialization();
            PopulateEmailList();

            student_list.DrawNode += StudentListDrawNode;
            student_list.Style.SelectedItemBackgroundColor = Theme.DarkNeutralGray;
        }

        private void StudentListDrawNode (object? sender, TreeViewDrawEventArgs e)
        {
            var item = (StudentListItem) e.Item;

            var line1_bounds = new Rectangle (item.Bounds.Left + e.LogicalToDeviceUnits (12), item.Bounds.Top + e.LogicalToDeviceUnits (3), item.Bounds.Width - e.LogicalToDeviceUnits (80), e.LogicalToDeviceUnits (23));
            var line2_bounds = new Rectangle (item.Bounds.Left + e.LogicalToDeviceUnits (12), line1_bounds.Bottom - e.LogicalToDeviceUnits (3), item.Bounds.Width - e.LogicalToDeviceUnits (16), e.LogicalToDeviceUnits (20));
            var line3_bounds = new Rectangle (item.Bounds.Left + e.LogicalToDeviceUnits (12), line2_bounds.Bottom - e.LogicalToDeviceUnits (3), item.Bounds.Width - e.LogicalToDeviceUnits (16), e.LogicalToDeviceUnits (20));
            var line4_bounds = new Rectangle (item.Bounds.Left + e.LogicalToDeviceUnits (12), line3_bounds.Bottom - e.LogicalToDeviceUnits (3), item.Bounds.Width - e.LogicalToDeviceUnits (16), e.LogicalToDeviceUnits (20));

            e.Canvas.DrawText (item.Text, Theme.UIFont, e.LogicalToDeviceUnits (16), line1_bounds, Theme.PrimaryTextColor, Modern.Forms.ContentAlignment.MiddleLeft, maxLines: e.LogicalToDeviceUnits (1));
            e.Canvas.DrawText (item.Name, Theme.UIFont, e.LogicalToDeviceUnits (12), line2_bounds, CustomTheme.LighterGrayFont, Modern.Forms.ContentAlignment.MiddleLeft, maxLines: e.LogicalToDeviceUnits (1));
            e.Canvas.DrawText (FormatDateTime(item.Birth), Theme.UIFont, e.LogicalToDeviceUnits (12), line3_bounds, CustomTheme.LighterGrayFont, Modern.Forms.ContentAlignment.MiddleLeft, maxLines: e.LogicalToDeviceUnits (1));
            e.Canvas.DrawText (item.Address, Theme.UIFont, e.LogicalToDeviceUnits (12), line4_bounds, CustomTheme.LighterGrayFont, Modern.Forms.ContentAlignment.MiddleLeft, maxLines: e.LogicalToDeviceUnits (1));

            e.Canvas.DrawLine (item.Bounds.Left, item.Bounds.Bottom - e.LogicalToDeviceUnits (1), item.Bounds.Right, item.Bounds.Bottom - e.LogicalToDeviceUnits (1), Theme.NeutralGray, e.LogicalToDeviceUnits (1));
        }

        private static string FormatDateTime(DateTime date)
        {
            return date.ToString ("dd/MM/yyyy");
        }

        private void SqlInitialization()
        {
            try
            {
                connection = new()
                {
                    ConnectionString = connectionString,
                };
                if (!connection.Query("SELECT * FROM sys.databases WHERE name = 'StudentManagement'").Any())
                {
                    connection.Query("CREATE DATABASE StudentManagement");
                    connection.ConnectionString = $"{connectionString};Database=StudentManagement";
                }
                if (!connection.Query("SELECT * FROM sysobjects WHERE name='Student' and xtype='U'").Any())
                {
                    connection.Query(@"
                        CREATE TABLE Student (
                            Id char(16) PRIMARY KEY,
                            Name nvarchar(50),
                            Birth smalldatetime,
                            Address nvarchar(120),
                        )
                    ");
                }
            }
            catch (SqlException e)
            {
                // Console.WriteLine("warn: database StudentManagement may have been created");
                // Console.WriteLine($"stack trace: {e}");
                System.Windows.Forms.MessageBox.Show(e.ToString());
                connection.ConnectionString = $"{connectionString};Database=StudentManagement";
            }
        }

        private void PopulateEmailList()
        {
            try
            {
                var students = connection.Query<Student>("SELECT * FROM Student");

                student_list.Items.Clear();
                student_list.Items.AddRange(
                    students.Select(s =>
                        new StudentListItem(s.Id, s.Name, s.Birth, s.Address)).ToArray());
                
                if (students.Any())
                {
                    ((StudentInfoPane) student_info_pane).Message = "Select a student to view information";
                }
            }
            catch (SqlException e)
            {
                // Console.WriteLine($"warn: stack trace {e}");
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
