using System.Numerics;
using System.Windows.Forms;

namespace winforms_intro
{
    public class IntegerTextBox : TextBox
    {
        private const int WM_PASTE = 0x0302;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE) { base.WndProc(ref m); }
            else
            {
                var text = SanitizeText(Clipboard.GetText());
                SelectedText = text;
            }
        }

        private static bool HasDashAtBegin(string? text) => text?.IndexOf('-') == 0;

        protected virtual string SanitizeText(string value)
        {
            // skip validation for empty clipboard
            if (value == "")
            {
                return SelectedText;
            }

            var hasDashAtBeginValue = HasDashAtBegin(value);

            var hasDashAtBeginTextBox = HasDashAtBegin(Text);

            var hasDashAtBeginSelection = HasDashAtBegin(SelectedText);

            var isInteger = BigInteger.TryParse(value, out BigInteger _);

            var isEmptySelection = SelectionLength == 0;

            var cursorPosition = SelectionStart;

            var toolTip = new ToolTip()
            {
                ToolTipTitle = "Nội dung dán không hợp lệ!",
            };

            string? toolTipText = null;

            if (isInteger)
            {
                if (isEmptySelection)
                {
                    if (hasDashAtBeginValue && hasDashAtBeginTextBox)
                    {
                        toolTipText = "Bạn không thể chèn số nguyên âm vào số nguyên âm hiện tại.";
                    }
                    if (!hasDashAtBeginValue && hasDashAtBeginTextBox && cursorPosition == 0)
                    {
                        toolTipText = "Bạn không thể chèn số nguyên dương vào đằng trước số nguyên âm hiện tại.";
                    }
                    if (hasDashAtBeginValue && !hasDashAtBeginTextBox && cursorPosition > 0)
                    {
                        toolTipText = "Bạn không thể chèn số nguyên âm vào số nguyên dương hiện tại.";
                    }
                }
                else
                {
                    if (hasDashAtBeginValue) {
                        if (hasDashAtBeginTextBox) {
                            if (!hasDashAtBeginSelection)
                            {
                                toolTipText = "Bạn không thể dán số nguyên âm vào vùng số nguyên âm đã chọn.";
                            }
                        }
                        else if (cursorPosition > 0)
                        {
                            toolTipText = "Bạn không thể dán số nguyên âm vào vùng số nguyên dương đã chọn.";
                        }
                    }
                }
            }
            else
            {
                toolTipText = "Bạn phải dán dãy số nguyên (từ 0-9) bất kỳ.";
            }

            if (toolTipText == null)
            {
                // then user can paste whatever integer they want
                return value;
            }

            // else show the tooltip and restore original text
            toolTip.Show(toolTipText, this, duration: 1000);
            return SelectedText;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            var toolTip = new ToolTip()
            {
                ToolTipTitle = "Ký tự vừa nhập không hợp lệ!",
            };

            string? toolTipText = null;

            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                toolTipText = "Bạn phải nhập ký tự số (từ 0-9) và/hoặc dấu trừ.";
            }

            if (e.KeyChar == '-' && (SelectionStart > 0 || Text.Contains('-')))
            {
                toolTipText = "Bạn chỉ được nhập dấu trừ ở vị trí đầu tiên của số.";
            }

            if (toolTipText != null)
            {
                // then don't allow it
                e.Handled = true;
                toolTip.Show(toolTipText, this, 1000);
            }

            base.OnKeyPress(e);
        }
    }
}
