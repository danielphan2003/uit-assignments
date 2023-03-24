# Chat with uwu

A glorified chat bot that helps :wink:.

## Overview

### Client

Client uses System.Net.Sockets.Socket and async for sending message and receiving reply from server.

It prefers IPv4 address over IPv6, but fallbacks to IPv6 for IPv6-only servers.

### Server

Server uses System.Net.Sockets.UdpClient and Worker Service (async) for receiving message and sending reply to client.

### Library

Both uwu.Client and uwu.Server use uwu.Library for parsing and creating Message, as well as some other utilities.

All available commands are in `MessageUtils.Commands`. You can add new MessageCommand to it, and the server will be able to handle that new command.

This allows us to develop new features more quickly, like locally handling commands whenever the server is offline, or providing auto completion for command when typing a new message in Client.

## Contribute

Feel free to make a pull request :heart:.

## Public servers

A public server is available at fragrant-frog-1282.fly.dev, deployed on https://fly.io/

### Running your own server on fly.io

Create a new app with https://fly.io/docs/hands-on/install-flyctl/ and replaces `[[services]]` with:
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

Note that for UDP to work on fly.io, the server added support for resolving `fly-global-services` and binding its socket listener to that address. See [the `fly-global-services` Address][fly-global-services-address].

A limitation for running on fly.io is that [UDP won't work over IPv6][fly-udp-wont-work-over-ipv6] yet. 

[fly-global-services-address]: https://fly.io/docs/app-guides/udp-and-tcp/#the-fly-global-services-address
[fly-udp-wont-work-over-ipv6]: https://fly.io/docs/app-guides/udp-and-tcp/#udp-won-t-work-over-ipv6
