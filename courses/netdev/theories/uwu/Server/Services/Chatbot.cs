using System.Net.Sockets;
using System.Text;
using uwu.Library;

namespace uwu.Server;

internal static class NetworkServiceLogEvents
{
    internal static EventId Listen = new(1000, nameof(Listen));
    internal static EventId Stop = new(0111, nameof(Stop));
    internal static EventId Receive = new(1001, nameof(Receive));
    internal static EventId Send = new(1002, nameof(Send));
}

public class ChatbotService : BackgroundService
{
    private readonly ILogger<ChatbotService> _logger;
    private readonly UdpClient _socket;

    public ChatbotService(ILogger<ChatbotService> logger, UdpClient socket)
    {
        _logger = logger;
        _socket = socket;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(NetworkServiceLogEvents.Listen, "{Service} is listening", nameof(ChatbotService));
        while (!stoppingToken.IsCancellationRequested)
        {
            var receivedResult = await _socket.ReceiveAsync(stoppingToken);
            var receivedBytes = receivedResult.Buffer;
            var destination = receivedResult.RemoteEndPoint;
            var rawMessage = Encoding.UTF8.GetString(receivedBytes);
            var reply = Reply(rawMessage);

            _logger.LogInformation(NetworkServiceLogEvents.Receive, "Received a message from {Destination}", destination);
            
            await _socket.SendAsync(Encoding.UTF8.GetBytes($"{reply}"), destination, stoppingToken);
            
            _logger.LogInformation(NetworkServiceLogEvents.Send, "Sent a reply to {Destination}", destination);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.Run(() => {
            _logger.LogInformation(NetworkServiceLogEvents.Stop, "{Service} is stopping...", nameof(ChatbotService));
            _socket.Close();
        }, cancellationToken);
    }

    public static string TryExecuteCommand(Message message)
    {
        try
        {
            var command = MessageUtils.Commands.Where(c => c.Command == message.Command).FirstOrDefault(new MessageCommand());
            if (string.IsNullOrEmpty(command.Command) && !string.IsNullOrEmpty(message.Command))
            {
                return "Oops. We don't have that command.";
            }
            return command.Execute(message);
        }
        catch (Exception e)
        {
            return $"Error while processing message content. Full stack trace: {e}";
        }
    }

    public static Message Reply(string s)
    {
        var isValidMessage = Message.TryParse(s, out Message message);

        var reply = new Message();

        if (isValidMessage)
        {
            reply.Content = TryExecuteCommand(message);
        }
        else
        {
            reply.Content = "Invalid message format!";
        }

        return reply;
    }
}
