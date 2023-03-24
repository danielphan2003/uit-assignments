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
    private Socket socket;
    private static readonly Regex IPAddressPortSchema = _generateIPAddressPortSchema();

    [GeneratedRegex("(.*)((?::))((?:[0-9]+))")]
    private static partial Regex _generateIPAddressPortSchema();

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
        if (externalServerInput.Enabled)
        {
            if (string.IsNullOrWhiteSpace(externalServerInput.Text))
            {
                MessageBox.Show("External server host name or IP address cannot be empty!", "Invalid external server");
                return null;
            }

            var domainPortMatches = externalServerInput.Text.Split(':');

            if (domainPortMatches.Length > 0 && domainPortMatches.Length < 3)
            {
                var ipAddresses = Dns.GetHostAddresses(domainPortMatches[0]);

                if (ipAddresses.Length != 0)
                {
                    // prioritize IPv4, since Fly.io does not support UDP over IPv6 for now.
                    var ipv4Address = ipAddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).First();

                    var ipv6Address = ipAddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetworkV6).First();

                    var ipAddress = ipv4Address ?? ipv6Address;

                    switch (domainPortMatches.Length)
                    {
                        case 1:
                            return new IPEndPoint(ipAddress, NetworkConfiguration.DEFAULT_PORT);

                        case 2:
                            var validPort = short.TryParse(domainPortMatches[1], out short port);
                            if (validPort)
                            {
                                return new IPEndPoint(ipAddress, port);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            
            var ipAddressPortMatches = IPAddressPortSchema.Match(externalServerInput.Text);

            switch (ipAddressPortMatches.Length)
            {
                case 0:
                    var validIpAddress = IPAddress.TryParse(externalServerInput.Text, out IPAddress? ipAddress);
                    if (validIpAddress && ipAddress != null)
                    {
                        return new IPEndPoint(ipAddress, NetworkConfiguration.DEFAULT_PORT);
                    }
                    break;

                case 2:
                    validIpAddress = IPAddress.TryParse($"{ipAddressPortMatches.Groups[0]}", out ipAddress);
                    var validPort = short.TryParse($"{ipAddressPortMatches.Groups[1]}", out short port);
                    if (validIpAddress && validPort && ipAddress != null)
                    {
                        return new IPEndPoint(ipAddress, port);
                    }
                    break;

                default:
                    break;
            }

            MessageBox.Show("Invalid host name or IP address for external server.", "Invalid external server");
            return null;
        }
        return new IPEndPoint(IPAddress.Parse("127.0.0.1"), NetworkConfiguration.DEFAULT_PORT);
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

                return;
            }
            catch
            {
                MessageBox.Show("Cannot send to nor receive from external server. Server might be down.", "Failed connection");        
            }
            finally
            {
                chatInput.Clear();
            }
        }
    }
}
