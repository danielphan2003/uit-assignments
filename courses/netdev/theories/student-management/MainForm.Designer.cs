using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Modern.Forms;
using SkiaSharp;

namespace student_management
{
    partial class MainForm
    {
        private Label label;
        private TreeView student_list;
        private Panel student_info_pane;
        private TabControl menus;

        private void InitializeComponent()
        {
            Text = "University of Information Technology - Student Management";

            student_info_pane = Controls.Add (new StudentInfoPane { Dock = DockStyle.Fill });
            student_info_pane.Style.BackgroundColor = SKColors.White;

            student_list = Controls.Add (new TreeView { Dock = DockStyle.Left, Width = 325, DrawMode = TreeViewDrawMode.OwnerDrawContent });
            student_list.Style.Border.Left.Width = 0;
            student_list.Style.Border.Top.Width = 0;
            student_list.Style.Border.Bottom.Width = 0;
            student_list.Style.BackgroundColor = SKColors.White;
            student_list.ItemSelected += (o, e) => {
                State.Set("selected_student_id", student_list.SelectedItem.Text);
            };

            menus = Controls.Add (new TabControl { Dock = DockStyle.Top, Height = 71 });

            var home_tab = menus.TabPages.Add ("Home");

            var home_toolbar = home_tab.Controls.Add (new ToolBar { Height = 40 });

            home_toolbar.Items.Add ("Refresh").Click += (o, e) => {
                PopulateEmailList();
                student_list.SelectedItem = student_list.Items.Where(
                    i => i.Text == State.Get("selected_student_id"))
                    .FirstOrDefault();
            };

            home_toolbar.Items.Add (new MenuSeparatorItem ());
            home_toolbar.Items.Add ("New Student");
            home_toolbar.Items.Add (new MenuSeparatorItem ());
            home_toolbar.Items.Add ("Save");
            home_toolbar.Items.Add ("Delete", ImageLoader.Get ("delete.png"));
        }
    }
}
