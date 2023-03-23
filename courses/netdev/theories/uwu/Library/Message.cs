using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace uwu.Library;

public partial class Message
{
    public static readonly Regex MessagePattern = _messagePatternGenerator();

    public static readonly string TimestampFormat = "yyyy/MM/dd HH:mm:ss";

    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    public string Command { get; set; } = "";
    public string Content { get; set; } =  "";

    public override string ToString()
        => Format((t) => $"{t.ToUnixTimeMilliseconds()}");

    public string Format(Func<DateTimeOffset, string> fmt)
        => string.Join(
            " ",
            new List<string>()
                {
                    $"{fmt(Timestamp)}:",
                    Command.OptionalPrefix(!string.IsNullOrWhiteSpace(Command), "/"),
                    Content
                }
                .Where(s => !string.IsNullOrWhiteSpace(s))
        );

    public static bool TryParse(ReadOnlySpan<char> s, out Message message)
    {
        var match = MessagePattern.Match(s.ToString());
        var validLongTimestamp = long.TryParse(match.Groups["timestamp"].Value, out long longTimestamp);

        message = new()
        {
            Command = match.Groups["command"].Value,
            Content = match.Groups["content"].Value,
        };

        if (validLongTimestamp)
        {
            try
            {
                var timestamp = DateTimeOffset.FromUnixTimeMilliseconds(longTimestamp);
                message.Timestamp = timestamp;
            }
            catch (ArgumentOutOfRangeException)
            {
                validLongTimestamp = false;
            }
        }

        return validLongTimestamp && (!string.IsNullOrEmpty(message.Content) || !string.IsNullOrEmpty(message.Command));
    }

    [GeneratedRegex(@"(?<timestamp>\d+):(?:(?:\s+)?\/(?<command>\S+))?(?:\s+)?(?<content>(.|\n)*)", RegexOptions.Multiline)]
    private static partial Regex _messagePatternGenerator();
}
