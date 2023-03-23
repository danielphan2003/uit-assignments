using System.Drawing;
using System.Windows.Forms;

namespace winforms_intro;

partial class MainForm
{
    private void InitializeComponent()
    {
        Text = "Winforms Introduction";

        AutoScaleMode = AutoScaleMode.Font;

        MinimumSize = new Size(1100, 600);

        var tc = new TabControl {
            Dock = DockStyle.Fill,
        };

        Controls.Add(tc);

        var lab01_bai01 = CreateTabPageAndAdd(ref tc, "Bài 1");
        var lab01_bai02 = CreateTabPageAndAdd(ref tc, "Bài 2");
        var lab01_bai03 = CreateTabPageAndAdd(ref tc, "Bài 3");
        var lab01_bai03_1 = CreateTabPageAndAdd(ref tc, "Bài 3.1");
        var lab01_bai04 = CreateTabPageAndAdd(ref tc, "Bài 4");
        var lab01_bai05 = CreateTabPageAndAdd(ref tc, "Bài 5");

        lab01_bai01.Controls.Add(new Lab01_Bai01 {
            Height = 100,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
        });

        lab01_bai02.Controls.Add(new Lab01_Bai02 {
            Height = 400,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
        });
        
        lab01_bai03.Controls.Add(new Lab01_Bai03 {
            Height = 200,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
        });

        lab01_bai03_1.Controls.Add(new Lab01_Bai03_1 {
            Height = 200,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
        });
        
        lab01_bai04.Controls.Add(new Lab01_Bai04 {
            Height = 200,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
        });
        
        lab01_bai05.Controls.Add(new Lab01_Bai05 {
            Height = 300,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
        });
    }
}
