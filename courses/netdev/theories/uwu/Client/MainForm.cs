using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using uwu.Library;

namespace uwu.Client;

public partial class MainForm : Form
{
    private readonly Socket socket;
    private static readonly IPAddress localhost = IPAddress.Parse("127.0.0.1");

    public MainForm()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        {
            ReceiveTimeout = 200,
        };

        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        socket.Close();
    }

    private IPEndPoint? GetRemoteEndpoint()
    {
        var port = NetworkConfiguration.DEFAULT_PORT;

        if (externalServerInput.Enabled)
        {
            string? error = null;

            if (string.IsNullOrWhiteSpace(externalServerInput.Text))
            {
                error = "Domain name or IP address cannot be empty!";
            }

            // handle IP addresses, optionally with port number
            var validEndPoint = IPEndPoint.TryParse(externalServerInput.Text, out IPEndPoint? ipEndPoint);

            if (validEndPoint && ipEndPoint != null)
            {
                if (ipEndPoint.Port == 0)
                {
                    ipEndPoint.Port = port;
                }
                return ipEndPoint;
            }

            var domainPortMatches = externalServerInput.Text.Split(':');
            var domainIpAddresses = Array.Empty<IPAddress?>();
            var validDomain = false;

            try
            {
                domainIpAddresses = Dns.GetHostAddresses(domainPortMatches[0]);
                validDomain = domainIpAddresses.Any();
            }
            catch (Exception)
            {
                error = "Invalid IP address or domain name not found.";
            }

            var validNoPort = domainPortMatches.Length == 1;
            var validMaybePort = int.TryParse(domainPortMatches[^1], out var maybePort);
            var validPort = validMaybePort && maybePort >= IPEndPoint.MinPort && maybePort <= IPEndPoint.MaxPort;

            if (validDomain && (validNoPort || validPort))
            {
                port = validNoPort ? port : maybePort;

                var ipv4Address = domainIpAddresses
                    .FirstOrDefault(ip => ip?.AddressFamily == AddressFamily.InterNetwork, null);
                var ipv6Address = domainIpAddresses
                    .FirstOrDefault(ip => ip?.AddressFamily == AddressFamily.InterNetworkV6, null);
                
                var ipAddress = ipv4Address ?? ipv6Address ?? localhost;

                return new IPEndPoint(ipAddress, port);
            }

            if (!validNoPort && !validPort)
            {
                error = "Invalid port number";
            }

            MessageBox.Show(error ?? "Unknown error", "Invalid external server");
            return null;
        }

        return new IPEndPoint(localhost, NetworkConfiguration.DEFAULT_PORT);
    }

    private void AppendChatView(string whom, Library.Message msg)
    {
        // Linux servers uses '\n' instead of '\r\n' (Environment.NewLine)
        var msgText = msg.Format((t) => $"{t.AddHours(7):yyyy/MM/dd HH:mm:ss}").ReplaceLineEndings();
        chatView.AppendText($"{(chatView.Text == "" ? "" : Environment.NewLine)}{whom}{msgText}");
    }

    private async void OnSendMessageClick(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(chatInput.Text))
        {
            MessageBox.Show("Please enter a message.", "Empty message");
            return;
        }

        var remoteEndPoint = GetRemoteEndpoint();
        if (remoteEndPoint != null)
        {
            try
            {
                var _ = Library.Message.TryParse($"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}: {chatInput.Text}", out Library.Message message);

                AppendChatView("Me at ", message);

                await socket.SendToAsync(Encoding.UTF8.GetBytes($"{message}"), SocketFlags.None, remoteEndPoint);

                Memory<byte> recvBuffer = new byte[1024];
                int bytesRead = (await socket.ReceiveFromAsync(recvBuffer, SocketFlags.None, remoteEndPoint)).ReceivedBytes;
                    
                // Handle received data
                var actualReceived = recvBuffer[..bytesRead];

                var rawReply = Encoding.UTF8.GetString(actualReceived.Span);
                _ = Library.Message.TryParse(rawReply, out Library.Message reply); 
                
                AppendChatView("uwu at ", reply);

                chatView.AppendText($"{Environment.NewLine}-------------------");

                chatInput.Clear();

                return;
            }
            catch
            {
                MessageBox.Show("Cannot send to nor receive from external server. Server might be down.", "Failed connection");        
            }

        }
    }
}
