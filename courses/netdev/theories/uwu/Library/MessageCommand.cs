using System;
using System.Linq;

namespace uwu.Library;

public class MessageCommand
{
    public string Synopsis { get; set; } = "";
    public string Command { get; set; } = "";
    public bool RequireArguments { get; set; } = false;
    public Func<Message, string> CallbackFn { get; set; } = (_) => MessageUtils.Random();

    public string Execute(Message message)
    {
        if (message.Content.Trim() == "help")
        {
            return $"/{Command}: {Synopsis}";
        }

        if (RequireArguments && string.IsNullOrWhiteSpace(message.Content))
        {
            return $"/{Command} require at least one argument.";
        }

        return CallbackFn(message);
    }

    public override string ToString()
        => $"/{Command}: {Synopsis}";
}
