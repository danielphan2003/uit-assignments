using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using uwu.Library;
using uwu.Server;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            .AddSingleton(c =>
            {
                var udpClient = new UdpClient()
                {
                    ExclusiveAddressUse = false,
                };

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // ignore lost connection only on Windows
                    uint IOC_IN = 0x80000000;
                    uint IOC_VENDOR = 0x18000000;
                    uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                    udpClient.Client.IOControl((int) SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
                }

                udpClient.Client.ReceiveTimeout = 200;
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                var runningOnFlyio = new List<string>() {"FLY_APP_NAME", "FLY_ALLOC_ID", "FLY_REGION"}
                    .Select((f) => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(f)))
                    .Contains(true);

                var ipAddress = runningOnFlyio ? Dns.GetHostAddresses("fly-global-services")[0] : IPAddress.Any;

                udpClient.Client.Bind(new IPEndPoint(ipAddress, NetworkConfiguration.DEFAULT_PORT));

                return udpClient;
            })
            .AddHostedService<ChatbotService>();
    })
    .Build();

host.Run();
