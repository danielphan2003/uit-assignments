using System;
using System.Numerics;
using System.Windows.Forms;

namespace winforms_intro
{
    public partial class Lab01_Bai03_1 : Panel
    {
        public Lab01_Bai03_1()
        {
            InitializeComponent();
            OnInitLoad();
        }

        public void ReadClick(object sender, EventArgs e)
        {
            result.Text = number.GetReadableText() ?? "Số vừa nhập bị lỗi!";
        }

        public void ClearClick(object sender, EventArgs e)
        {
            number.Text = "";
            OnInitLoad();
        }

        public void OnInitLoad()
        {
            result.Text = $"Hãy nhập một số nguyên từ {number.LowerBound} đến {number.UpperBound}.";
        }
    }
}
