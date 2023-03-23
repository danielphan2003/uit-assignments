using System.Windows.Forms;

namespace winforms_intro;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private static TabPage CreateTabPageAndAdd(ref TabControl tc, string? text)
    {
        var tabPage = new TabPage(text);
        tc.TabPages.Add(tabPage);
        return tabPage;
    }
}
