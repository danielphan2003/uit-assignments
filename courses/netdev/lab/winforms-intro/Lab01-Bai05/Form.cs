using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_intro
{
    public partial class Lab01_Bai05 : Panel
    {
        public Lab01_Bai05()
        {
            InitializeComponent();
        }

        public static void WaitCalculate(Control control, string name, Func<string> func)
        {
            var task = Task.Run(func);
            if (task.Wait(TimeSpan.FromSeconds(5)))
            {
                control.Text = task.Result;
            }
            else
            {
                control.Text = $"Hết thời gian chờ kết quả {name}.";
            }
        }

        public void OnCalculateButtonClick(object sender, EventArgs _)
        {
            var validFirstNum = Int128.TryParse(firstNumber.Text, out Int128 maybeFirstNum);
            var validSecondNum = Int128.TryParse(secondNumber.Text, out Int128 maybeSecondNum);

            if (validFirstNum && validSecondNum)
            {
                factorialFirstNumberLabel.Text = FormatFactorial(factorialFirstNumberLabel.Name, maybeFirstNum);
                
                factorialSecondNumberLabel.Text = FormatFactorial(factorialSecondNumberLabel.Name, maybeSecondNum);

                sumFirstLabel.Text = "Đang tính S1...";
                sumSecondLabel.Text = "Đang tính S2...";
                sumThirdLabel.Text = "Đang tính S3...";

                WaitCalculate(sumFirstLabel, "S1", () => FormatTriangularSum(sumFirstLabel.Name, maybeFirstNum));

                WaitCalculate(sumSecondLabel, "S2", () => FormatTriangularSum(sumSecondLabel.Name, maybeSecondNum));

                try
                {
                    WaitCalculate(sumThirdLabel, "S3", () => FormatThirdSum<Int128, double>(maybeFirstNum, maybeSecondNum));
                }
                catch (Exception e)
                {
                    sumThirdLabel.Text = "Lỗi khi tính S3.";
                    MessageBox.Show(e.ToString());
                }
            }
            else
            {
                var text = $"A và/hoặc B không hợp lệ ({nameof(Int128)}).";
                SetText(factorialFirstNumberLabel, text);
                SetText(factorialSecondNumberLabel, text);
                SetText(sumFirstLabel, text);
                SetText(sumSecondLabel, text);
                SetText(sumThirdLabel, text);
            }
        }

        public static void SetText(Control control, string text)
            => control.Text = text;

        public void OnClearButtonClick(object sender, EventArgs e)
        {
            firstNumber.Text = "";
            secondNumber.Text = "";
            factorialFirstNumberLabel.Text = FormatFactorial(factorialFirstNumberLabel.Name, 0);
            factorialSecondNumberLabel.Text = FormatFactorial(factorialSecondNumberLabel.Name, 0);
            sumFirstLabel.Text = FormatTriangularSum(sumFirstLabel.Name, 0);
            sumSecondLabel.Text = FormatTriangularSum(sumSecondLabel.Name, 0);
            sumThirdLabel.Text = FormatThirdSum<Int128, double>(0, 0);
        }

        private static string FormatFactorial<T>(string name, T n)
            where T : IBinaryInteger<T>, IMinMaxValue<T>
        {
            if (n > T.CreateChecked(30))
            {
                return $"{name}! = Vượt quá giới hạn cho phép.";
            }

            var zero = T.CreateChecked(0);
            if (n < zero)
            {
                return $"Không thể tính {name}! vì {name} là số âm";
            }

            var one = T.CreateChecked(1);
            var factorial = one;
            for (var step = one + one; step <= n; step++)
            {
                factorial *= step;
            }

            return $"{name}! = {factorial}";
        }

        private static string FormatTriangularSum<T>(string name, T n)
            where T : IBinaryInteger<T>, IMinMaxValue<T>
        {
            var zero = T.CreateChecked(0);
            var one = T.CreateChecked(1);
            var sum = zero;
            for (var step = one; step <= n; step++)
            {
                sum += step;
            }
            return $"S{(name == "A" ? 1 : 2)} = 1 + 2 + 3 + 4 + ... + {name} = {sum}";
        }

        private static TResult? Pow<T, TResult>(T first, T second)
            where T : IBinaryInteger<T>, IMinMaxValue<T>
            where TResult : INumber<TResult>
        {
            var zeroT = T.CreateChecked(0);
            var zeroTResult = TResult.CreateChecked(0);
            var oneTResult = TResult.CreateChecked(1);
            var oneT = T.CreateChecked(1);
            var negOneT = T.CreateChecked(-1);
 
            if (first == zeroT && second == zeroT)
            {
                return default;
            }

            if (first == zeroT)
            {
                return zeroTResult;
            }

            if (first == oneT || second == zeroT)
            {
                return oneTResult;
            }

            var firstTResult = TResult.CreateChecked(first);

            if (second == oneT)
            {
                return firstTResult;
            }
 
            if (second < zeroT)
            {
                return oneTResult / (firstTResult * (Pow<T, TResult>(first, second * negOneT - oneT) ?? oneTResult)); 
            }

            return firstTResult * (Pow<T, TResult>(first, second - oneT) ?? oneTResult);
        }

        private static T Min<T>(T first, T second)
            where T : IBinaryInteger<T>, IMinMaxValue<T>
            => first < second ? first : second;
        
        private static T Max<T>(T first, T second)
            where T : IBinaryInteger<T>, IMinMaxValue<T>
            => first > second ? first : second;

        private string FormatThirdSum<T, TResult>(T first, T second)
            where T : IBinaryInteger<T>, IMinMaxValue<T>
            where TResult : INumber<TResult>
        {
            var checkedFirst = Int128.CreateChecked(first);
            var checkedSecond = Int128.CreateChecked(second);
            var checkedMax = Max(checkedFirst, checkedSecond);
            var checkedMin = Min(checkedFirst, checkedSecond);

            if (checkedMax > short.MaxValue || checkedMin < short.MinValue)
            {
                return "Vượt quá phạm vi cho phép";
            }

            var zeroT = T.CreateChecked(0);
            if (first == zeroT && second == zeroT)
            {
                return "Không thể tính S3 vì 0^0 là phép tính không hợp lệ.";
            }

            var zeroTResult = TResult.CreateChecked(0);
            var firstT = T.CreateChecked(1);
            var sum = zeroTResult;
            for (var step = firstT; step <= second; step++)
            {
                sum += Pow<T, TResult>(first, step);
            }

            return $"S3 = A^1 + A^2 + A^3 + A^4 + ... + A^B = {sum}";
        }
    }
}
