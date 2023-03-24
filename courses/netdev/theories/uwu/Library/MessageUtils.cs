using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uwu.Library;

public class MessageUtils
{
    public static string Random()
    {
        var random = new Random();
        var messages = new List<string>
        {
            "UwU",
            "I luv you",
            "Hi there",
            "Whatyadoing?",
            "I'm very UwU",
            @"UwU
Hi, I'm very UwU.

Whatever you may throw at me, I will stay UwU. It's a state of mind that is very UwU in its true nature.

If you want to, I can UwU you as well ❤.

🔭 I’m currently working on: UwU, uWu, UWU (case insensitive)
🌱 I’m currently learning: uWU, Uwu
👯 I’m looking to collaborate on: UWUUWUUWU
🤔 I’m looking for help with UWUWUWUWUWU
💬 Ask me about UWU
📫 How to reach me: UWU@UWU.UWU
😄 Pronouns: ~UWU~ he/him
⚡ Fun fact: I'm very UwU",
            "Sometimes I stare at a door or a wall and I wonder what is this reality, why am I alive, and what is this all about?",
            "If my calculator had a history, it would be more embarrassing than my browser history.",
            "As she walked along the street and looked in the gutter, she realized facemasks had become the new cigarette butts.",
            "I'd rather be a bird than a fish.",
            "The fog was so dense even a laser decided it wasn't worth the effort.",
            "He told us a very exciting adventure story.",
            "He took one look at what was under the table and noped the hell out of there.",
            "The clock within this blog and the clock on my laptop are 1 hour different from each other.",
            "As he looked out the window, he saw a clown walk by.",
            "When nobody is around, the trees gossip about the people who have walked under them.",
        };
        return messages[random.Next(0, messages.Count)];
    }

    public static string Base64Encode(Message msg) 
    {
        var bytes = Encoding.UTF8.GetBytes(msg.Content);
        return Convert.ToBase64String(bytes);
    }

    public static string Base64Decode(Message msg) 
    {
        var bytes = Convert.FromBase64String(msg.Content);
        return Encoding.UTF8.GetString(bytes);
    }

    public static string ToBin(Message msg)
    {
        var bytes = Encoding.UTF8.GetBytes(msg.Content);
        return string.Join("", bytes.Select(b => Convert.ToString(b, 2)));
    }

    public static string ToHex(Message msg)
    {
        var bytes = Encoding.UTF8.GetBytes(msg.Content);
        return BitConverter.ToString(bytes).Replace("-", "");
    }

    public static string ListAllCommands()
    {
        var allCommands = string.Join(Environment.NewLine, Commands.Select(command => $"- {command}"));
        return $@"Here are all available commands for uwu:
{allCommands}";
    }

    public static string Echo(Message msg)
        => $"Echoing last message (incl. timestamp): {msg}";

    public static string UwUify(Message msg)
        => string.Join("uwu ", msg.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries));
    
    public static string Help()
        => "To get started, type /all for all available commands.";

    public static string About()
        => @"This is a project for my class assignment (NT106.N21.MMCL). I hope you like it.
For more information please contact danielphan.2003@gmail.com
Source code is available at https://github.com/danielphan2003/uit-assignments/courses/netdev/theories/uwu/";

    public static readonly List<MessageCommand> Commands = new()
    {
        new()
        {
            Command = "uwu",
            Synopsis = "uwu-ify any message.",
            CallbackFn = UwUify,
        },
        new()
        {
            Command = "uuid",
            Synopsis = "Generate a UUID (also called GUID).",
            CallbackFn = (_) => $"{Guid.NewGuid()}",
        },
        new()
        {
            Command = "base64e",
            Synopsis = "Convert message to base64.",
            RequireArguments = true,
            CallbackFn = Base64Encode,
        },
        new()
        {
            Command = "base64d",
            Synopsis = "Convert base64 message to UTF-8 text.",
            RequireArguments = true,
            CallbackFn = Base64Decode,
        },
        new()
        {
            Command = "echo",
            Synopsis = "Reply (a formatted message of) whatever message you send, incl. timestamp.",
            RequireArguments = true,
            CallbackFn = Echo,
        },
        new()
        {
            Command = "tohex",
            Synopsis = "Convert message to hex UTF-8 string.",
            RequireArguments = true,
            CallbackFn = ToHex,
        },
        new()
        {
            Command = "tobin",
            Synopsis = "Convert message to binary UTF-8 string.",
            RequireArguments = true,
            CallbackFn = ToBin,
        },
        new()
        {
            Command = "all",
            Synopsis = "List all commands.",
            CallbackFn = (_) => ListAllCommands(),
        },
        new()
        {
            Command = "random",
            Synopsis = "Send a random message.",
            CallbackFn = (_) => Random(),
        },
        new()
        {
            Command = "help",
            Synopsis = "Print out a help message.",
            CallbackFn = (_) => Help(),
        },
        new()
        {
            Command = "about",
            Synopsis = "Print out an about message.",
            CallbackFn = (_) => About(),
        },
    };
}
