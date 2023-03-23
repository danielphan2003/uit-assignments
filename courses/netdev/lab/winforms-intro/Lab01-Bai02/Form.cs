using System;
using System.Windows.Forms;

namespace winforms_intro
{
    public partial class Lab01_Bai02 : Panel
    {
        public Lab01_Bai02()
        {
            InitializeComponent();
            OnInitLoad();
        }

        private static double Min(double a, double b)
            => a < b ? a : b;

        private static double Max(double a, double b)
            => a > b ? a : b;

        public void OnInitLoad()
        {
            var text = "Hãy nhập đủ 3 số thực.";
            minNumber.Text = text;
            maxNumber.Text = text;
        }

        public void FindClick(object sender, EventArgs e)
        {
            var validFirstNum = double.TryParse(firstNumber.Text, out double maybeFirstNum);
            var validSecondNum = double.TryParse(secondNumber.Text, out double maybeSecondNum);
            var validThirdNum = double.TryParse(thirdNumber.Text, out double maybeThirdNum);

            if (validFirstNum && validSecondNum && validThirdNum)
            {
                minNumber.Text = $"{Min(maybeFirstNum, Min(maybeSecondNum, maybeThirdNum))}";
                maxNumber.Text = $"{Max(maybeFirstNum, Max(maybeSecondNum, maybeThirdNum))}";
            }
            else
            {
                var text = "Có một vài số thực bị lỗi!";
                minNumber.Text = text;
                maxNumber.Text = text;
            }
        }

        public void ClearClick(object sender, EventArgs e)
        {
            firstNumber.Text = "";
            secondNumber.Text = "";
            thirdNumber.Text = "";
            OnInitLoad();
        }
    }
}
