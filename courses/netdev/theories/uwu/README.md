# Chat with uwu

A glorified chat bot that helps :wink:.

## Overview

### uwu.Client

uwu.Client uses `System.Net.Sockets.Socket` and async for sending messages and receiving replies from server.

It prefers IPv4 address over IPv6, but fallbacks to IPv6 for IPv6-only servers.

### uwu.Server

Server uses `System.Net.Sockets.UdpClient` and [Worker Service][dotnet-worker-service] (async) for receiving messages and sending replies to client.

It currently handles commands from `uwu.Library.MessageUtils.Commands`.

### uwu.Library

Both `uwu.Client` and `uwu.Server` use `uwu.Library` for parsing and creating a `Message` object, as well as some other utilities.

This allows us to optionally develop new features more quickly, like locally handling commands whenever the server is offline, or providing auto completion for command when typing a new message in uwu.Client.

## Contribute

Feel free to make a pull request :heart:.

## Public servers

A public server is available at fragrant-frog-1282.fly.dev, deployed on [fly.io][fly-io].

It might be slow to respond because there is only one instance in Hong Kong, so high ping is unavoidable.

Scaling up by running [multiple regions][fly-multiple-regions] in Fly is possible, see [adding one or more regions to your app][flyctl-regions-add].

### Running your own server on [fly.io][fly-io]

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

Note that for UDP to work, the server added support for resolving `fly-global-services` and binding its socket listener to that address. See [the `fly-global-services` Address][fly-global-services-address]. Also [UDP won't work over IPv6][fly-udp-wont-work-over-ipv6] (yet).

[dotnet-worker-service]: https://learn.microsoft.com/en-us/dotnet/core/extensions/workers
[fly-multiple-regions]: https://fly.io/docs/reference/regions/#fly-io-regions
[flyctl-regions-add]: https://fly.io/docs/flyctl/regions-add/
[fly-io]: https://fly.io/
[install-flyctl]: https://fly.io/docs/hands-on/install-flyctl/
[fly-global-services-address]: https://fly.io/docs/app-guides/udp-and-tcp/#the-fly-global-services-address
[fly-udp-wont-work-over-ipv6]: https://fly.io/docs/app-guides/udp-and-tcp/#udp-won-t-work-over-ipv6
