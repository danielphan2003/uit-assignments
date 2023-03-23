using System;
using System.Numerics;
using System.Windows.Forms;

namespace winforms_intro
{
    public partial class Lab01_Bai01 : Panel
    {
        public Lab01_Bai01()
        {
            InitializeComponent();
            OnInitLoad();
        }

        public void OnNumberChanged(object sender, EventArgs e)
        {
            result.Text = "Đang tính toán nè...";

            var textBox = sender as TextBoxBase;
            var otherTextBoxName = textBox.Name == "firstNumber" ? "secondNumber" : "firstNumber";
            var otherTextBox = panel.Controls.Find(otherTextBoxName, true)[0];
            var validFirstNum = BigInteger.TryParse(textBox.Text, out BigInteger maybeFirstNum);
            var validSecondNum = BigInteger.TryParse(otherTextBox.Text, out BigInteger maybeSecondNum);

            if (validFirstNum && validSecondNum)
            {
                result.Text = $"{maybeFirstNum + maybeSecondNum}";
            }
            else
            {
                OnInitLoad();    
            }
        }

        public void OnInitLoad()
        {
            result.Text = "Hãy nhập đủ hai số nguyên.";
        }
    }
}
