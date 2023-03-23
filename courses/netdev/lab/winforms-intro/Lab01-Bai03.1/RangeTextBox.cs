using System;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace winforms_intro
{
    public class RangeTextBox<T> : TextBox
        where T : IBinaryInteger<T>, IMinMaxValue<T>
    {
        private const int WM_PASTE = 0x0302;

        private static readonly T zero = T.CreateChecked(0);
        private static readonly T one = T.CreateChecked(1);
        private static readonly T ten = T.CreateChecked(10);
        private static readonly T hundred = T.CreateChecked(100);
        private static readonly T thousand = T.CreateChecked(1000);
        private static readonly T tenthousand = T.CreateChecked(10000);

        private T _lowerBound = T.MinValue + one;
        private T _upperBound = T.MaxValue - one;

        public T LowerBound
        {
            get => _lowerBound;
            set
            {
                if (_upperBound < _lowerBound)
                {
                    throw new ArgumentOutOfRangeException(nameof(LowerBound));
                }
                _lowerBound = value;
            }
        }

        public T UpperBound
        {
            get => _upperBound;
            set
            {
                if (_lowerBound > _upperBound)
                {
                    throw new ArgumentOutOfRangeException(nameof(UpperBound));
                }
                _upperBound = value;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE) { base.WndProc(ref m); }
            else
            {
                var text = SanitizeText(Clipboard.GetText());
                SelectedText = text;
            }
        }

        public T ToType()
            => T.Parse(Text, CultureInfo.InvariantCulture);

        private static string OptionalString(bool cond, string ifTrue, string ifFalse = "")
            => cond ? ifTrue : ifFalse;

        private static string DigitSeparator(short count)
            => count switch
            {
                0 => "",
                1 => "ngàn",
                2 => "triệu",
                3 => "tỷ",
                _ => throw new ArgumentOutOfRangeException(nameof(count)),
            };

        private static string DigitToText(ushort digit)
            => digit switch
            {
                0 => "không",
                1 => "một",
                2 => "hai",
                3 => "ba",
                4 => "bốn",
                5 => "năm",
                6 => "sáu",
                7 => "bảy",
                8 => "tám",
                9 => "chín",
                _ => throw new ArgumentOutOfRangeException(nameof(digit)),
            };
    
        private static string? TripleDigitToText(ushort hundredth, ushort tenth, ushort nth)
        {
            if (hundredth < 0 || hundredth > 9)
            {
                return null;
            }

            var doubleDigitText = DoubleDigitToText(hundredth, tenth, nth);
            var hundredText = hundredth switch
            {
                0 => null,
                _ => $"{DigitToText(hundredth)} trăm",
            };

            if (hundredth > 0 && tenth == 0 && nth > 0)
            {
                doubleDigitText = $"lẻ {doubleDigitText}";
            }

            return $"{hundredText}{OptionalString(!string.IsNullOrEmpty(hundredText) && !string.IsNullOrEmpty(doubleDigitText), " ")}{doubleDigitText}";
        }

        private static string DoubleDigitToText(ushort hundredth, ushort tenth, ushort nth)
        {
            var tenthText = tenth switch
            {
                0 => null,
                1 => "mười",
                _ => $"{DigitToText(tenth)} mươi",
            };

            var nthText = nth switch
            {
                0 => null,
                1 => tenth == 1 || (hundredth == 0 && tenth == 0) ? "một" : "mốt",
                5 => hundredth == 0 && tenth == 0 ? "năm" : "lăm",
                _ => $"{DigitToText(nth)}",
            };

            return $"{tenthText}{OptionalString(!string.IsNullOrEmpty(tenthText) && !string.IsNullOrEmpty(nthText), " ")}{nthText}";
        }

        public string? GetReadableText()
        {
            string? text = null;

            var isTSelf = T.TryParse(Text, CultureInfo.InvariantCulture, out T? maybeValue);

            maybeValue ??= zero;

            if (isTSelf)
            {
                text = "";

                var isNegative = maybeValue < zero;

                if (isNegative)
                {
                    maybeValue *= T.CreateChecked(-1);
                }

                if (maybeValue >= zero && maybeValue < ten)
                {
                    text = DigitToText(Convert.ToUInt16(maybeValue));
                }
                else
                {
                    ushort count = 0;
                    do
                    {
                        var nth = maybeValue % ten;
                        var tenth = (maybeValue % hundred - nth) / ten;
                        var hundredth = (maybeValue % thousand - tenth * ten - nth) / hundred;
                        var thousandth = (maybeValue % tenthousand - hundredth * hundred - tenth * ten - nth) / thousand;

                        var tripleDigitText = TripleDigitToText(Convert.ToUInt16(hundredth), Convert.ToUInt16(tenth), Convert.ToUInt16(nth));

                        if (maybeValue >= thousand && thousandth >= zero && hundredth == zero && (tenth != zero || nth != zero))
                        {
                            if (tenth == zero)
                            {
                                if (nth != zero)
                                {
                                    tripleDigitText = $"không trăm lẻ {tripleDigitText}";
                                }
                            }
                            else
                            {
                                tripleDigitText = $"không trăm {tripleDigitText}";
                            }
                        }

                        var digitSeparator = DigitSeparator((short) (count++ % 4));

                        // optional spacing for style
                        var spaceTripleDigitWithSeparator = OptionalString(!string.IsNullOrEmpty(tripleDigitText) && !string.IsNullOrEmpty(digitSeparator), " ");
                        var spaceTripleDigitWithText = OptionalString(!string.IsNullOrEmpty(tripleDigitText) && !string.IsNullOrEmpty(text), ", ");

                        text = $"{tripleDigitText}{spaceTripleDigitWithSeparator}{digitSeparator}{spaceTripleDigitWithText}{text}";

                        maybeValue /= thousand;
                    }
                    while (maybeValue > zero);
                }

                text = OptionalString(isNegative, $"Âm {text}", $"{char.ToUpper(text[0])}{text[1..]}");
            }

            return text;
        }

        protected virtual string SanitizeText(string value)
        {
            // skip validation for empty clipboard
            if (value == "")
            {
                return SelectedText;
            }

            var isTSelf = T.TryParse(value, CultureInfo.InvariantCulture, out T? maybeValue);

            maybeValue ??= T.CreateChecked(0);

            var toolTip = new ToolTip()
            {
                ToolTipTitle = "Nội dung dán không hợp lệ!",
            };

            string? toolTipText = null;

            if (isTSelf)
            {
                if (maybeValue < _lowerBound || maybeValue > _upperBound)
                {
                    toolTipText = $"Bạn chỉ được dán số từ {_lowerBound} đến {_upperBound}.";
                }

                if (Text != "" && SelectedText == "")
                {
                    toolTipText = $"Bạn không được dán vào đây. Giới hạn số được nhập vào là từ {_lowerBound} đến {_upperBound}.";
                }
            }
            else
            {
                toolTipText = $"Bạn chỉ được dán số từ {_lowerBound} đến {_upperBound}..";
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
                e.Handled = true;
                toolTipText = "Bạn phải nhập ký tự số (từ 0-9).";
            }

            if (char.IsDigit(e.KeyChar))
            {
                var maybeText = Text
                    .Remove(SelectionStart, SelectionLength)
                    .Insert(SelectionStart, $"{e.KeyChar}");

                var isTSelf = T.TryParse(maybeText, CultureInfo.InvariantCulture, out T? maybeValue);

                maybeValue ??= zero;

                if (isTSelf)
                {
                    if (maybeValue < _lowerBound || maybeValue > _upperBound)
                    {
                        toolTipText = $"Giá trị tiếp theo sẽ vượt quá giới hạn từ {_lowerBound} đến {_upperBound}";
                    }
                }
                else
                {
                    toolTipText = "Có lỗi trong quá trình xử lý ký tự vừa nhập";
                }
            }

            if (e.KeyChar == '-')
            {
                if (SelectionStart > 0 || Text.Contains('-'))
                {
                    toolTipText = "Bạn chỉ được nhập dấu trừ ở vị trí đầu tiên của số.";
                }
                if (_lowerBound >= zero && _upperBound >= zero)
                {
                    toolTipText = "Bạn không được thêm dấu trừ.";
                }
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
