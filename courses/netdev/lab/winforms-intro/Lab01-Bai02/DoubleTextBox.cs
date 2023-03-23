using System.Windows.Forms;

namespace winforms_intro
{
    public class DoubleTextBox : TextBox
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

        protected virtual string SanitizeText(string value)
        {
            // skip validation for empty clipboard
            if (value == "")
            {
                return SelectedText;
            }

            var maybeText = Text
                .Remove(SelectionStart, SelectionLength)
                .Insert(SelectionStart, value);

            var isDouble = double.TryParse(maybeText, out double _);

            if (isDouble)
            {
                // then user can paste whatever Double they want
                return value;
            }

            var toolTip = new ToolTip()
            {
                ToolTipTitle = "Nội dung dán không hợp lệ!",
            };

            toolTip.Show("Nội dung dán có thể khiến số thực trở nên không hợp lệ.", this, duration: 1000);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                toolTipText = "Bạn chỉ được phép nhập ký tự số (0-9) và/hoặc dấu trừ và/hoặc dấu chấm ở đây.";
            }

            if (e.KeyChar == '.' && Text.Contains('.'))
            {
                toolTipText = "Bạn không được phép nhập dấu chấm ở đây.";
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
