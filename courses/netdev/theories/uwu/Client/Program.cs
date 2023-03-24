using System;
using System.Windows.Forms;

namespace uwu.Client;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }    
}
