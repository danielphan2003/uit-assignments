# Chat with uwu

A glorified chat bot that helps :wink:.

## Overview

### uwu.Client

uwu.Client uses `System.Net.Sockets.Socket` and async for sending messages and receiving replies from server.

It prefers IPv4 address over IPv6, but fallbacks to IPv6 for IPv6-only servers.

### uwu.Server

Server uses `System.Net.Sockets.UdpClient` and [Worker Service][dotnet-worker-service] (async) for receiving messages and sending replies to client.

It currently handles commands from `uwu.Library.MessageUtils.Commands`, and listens on 0.0.0.0:5667.

### uwu.Library

Both `uwu.Client` and `uwu.Server` use `uwu.Library` for parsing and creating a `Message` object, as well as some other utilities.

This allows us to optionally develop new features more quickly, like locally handling commands whenever the server is offline, or providing auto completion for command when typing a new message in uwu.Client.

## Develop

There are two targets: `Client`, `Server`.

Before running anything, you should have [.NET SDK 7.0][dotnet-sdk-7] installed.

To run a specific targets, run `dotnet run --project <target>`. 

To build a specific targets, run `dotnet publish -c Release <target>`. The published folder can then be used to e.g. run on a server.

## Contribute

Feel free to make a pull request :heart:.

## Public servers

A public server is available at fragrant-frog-1282.fly.dev, deployed on [fly.io][fly-io].

Currently there is only one instance in Hong Kong and Singapore.

The Singapore one has a lower latency for most Viet Nam users, while the Hong Kong one serves as a backup when it's sharking time.

## Self hosting

### Locally

Prerequisites:
- [.NET SDK 7.0][dotnet-sdk-7].

After that, run `dotnet run --project Server`.

### On [fly.io][fly-io]

Create a new app by [installing `flyctl`][install-flyctl] and running `fly launch`.

In `fly.toml`, replace all of the `[[services]]` block with:
```toml
[[services]]
  http_checks = []
  internal_port = 5667
  processes = ["app"]
  protocol = "udp"
  script_checks = []
    [[services.ports]]
    port = "5667"
```

Deploy it with `fly deploy` and use the provided domain name for the external server setting in uwu.Client.

Note that for UDP to work on Fly, the server added support for resolving `fly-global-services` and binding its socket listener to that address. See [the `fly-global-services` Address][fly-global-services-address]. Also [UDP won't work over IPv6][fly-udp-wont-work-over-ipv6] (yet).

#### Latency & multiple regions

In order to improve latency, you can run [multiple regions][fly-multiple-regions] closer to you.

See more about [adding one or more regions to your app][flyctl-regions-add].

[dotnet-sdk-7]: https://dotnet.microsoft.com/en-us/download
[dotnet-worker-service]: https://learn.microsoft.com/en-us/dotnet/core/extensions/workers
[fly-multiple-regions]: https://fly.io/docs/reference/regions/#fly-io-regions
[flyctl-regions-add]: https://fly.io/docs/flyctl/regions-add/
[fly-io]: https://fly.io/
[install-flyctl]: https://fly.io/docs/hands-on/install-flyctl/
[fly-global-services-address]: https://fly.io/docs/app-guides/udp-and-tcp/#the-fly-global-services-address
[fly-udp-wont-work-over-ipv6]: https://fly.io/docs/app-guides/udp-and-tcp/#udp-won-t-work-over-ipv6
