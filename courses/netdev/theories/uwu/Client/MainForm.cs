using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using uwu.Library;

namespace uwu.Client;

public partial class MainForm : Form
{
    private Socket socket;

    public MainForm()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        {
            ReceiveTimeout = 200,
        };

        InitializeComponent();
    }

    private static IPAddress? NormalizeIP(string s)
    {
        var match = s.Split(':', StringSplitOptions.RemoveEmptyEntries);
        var rawIpAddress = match[0];

        var validIpAddress = IPAddress.TryParse(rawIpAddress, out IPAddress? ipAddress);

        if (validIpAddress && ipAddress != null)
        {
            return ipAddress;
        }

        try
        {
            ipAddress = Dns.GetHostAddresses(rawIpAddress)[0];
            return ipAddress;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static int? NormalizePort(string s)
    {
        var match = s.Split(':', StringSplitOptions.RemoveEmptyEntries);
        if (match.Length < 2)
        {
            return null;
        }

        var validPort = int.TryParse(match[1], out int port);
        if (validPort)
        {
            return port;
        }

        return null;
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
            var ipAddress = NormalizeIP(externalServerInput.Text);
            if (ipAddress == null)
            {
                MessageBox.Show("Invalid host name or IP address for external server.", "Invalid external server");
                return null;
            }
            var port = NormalizePort(externalServerInput.Text) ?? NetworkConfiguration.DEFAULT_PORT;
            return new IPEndPoint(ipAddress, port);
        }
        return new IPEndPoint(IPAddress.Parse("127.0.0.1"), NetworkConfiguration.DEFAULT_PORT);
    }

    private void AppendChatView(string whom, Library.Message msg)
    {
        var msgText = msg.Format((t) => $"{t.AddHours(7):yyyy/MM/dd HH:mm:ss}");
        chatView.AppendText($"{(chatView.Text == "" ? "" : Environment.NewLine)}{whom}{msgText}");
        chatView.SelectionStart = chatView.TextLength;
        chatView.ScrollToCaret();
        chatView.Refresh();
    }

    private async void OnSendMessage(object sender, EventArgs e)
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
                MessageBox.Show("Cannot send to nor receive from external server. Please recheck external server input.", "Failed connection");        
            }
            finally
            {
                chatInput.Clear();
            }
        }
    }
}
