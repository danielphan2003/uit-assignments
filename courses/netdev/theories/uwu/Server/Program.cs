using System.Net;
using System.Net.Sockets;

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

                // ignore lost connection
                uint IOC_IN = 0x80000000;
                uint IOC_VENDOR = 0x18000000;
                uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                udpClient.Client.IOControl((int) SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false)
                }, null);

                udpClient.Client.ReceiveTimeout = 200;
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, NetworkConfiguration.DEFAULT_PORT));

                return udpClient;
            })
            .AddHostedService<NetworkService>();
    })
    .Build();

host.Run();
