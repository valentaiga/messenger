using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Messenger.Web.WebSockets;

public class WebSocketsHandler
{
    private readonly ILogger<WebSocketsHandler> _logger;
    private readonly ConcurrentDictionary<long, WebSocket> _sockets = new();

    public WebSocketsHandler(ILogger<WebSocketsHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleWebSocketAsync(long socketId, WebSocket webSocket, CancellationToken cancellationToken)
    {
        if (!_sockets.TryAdd(socketId, webSocket))
            throw new WebSocketsException("Socket already exists");

        try
        {
            var buffer = new byte[4096];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), cancellationToken);

                switch (result.MessageType)
                {
                    case WebSocketMessageType.Text:
                    {
                        await HandleMessageAsync(socketId, buffer, result.Count);
                        break;
                    }
                    case WebSocketMessageType.Close:
                        await DisconnectSocket(socketId);
                        break;
                }
            }
        }
        catch (OperationCanceledException)
        {
            // ignore
        }
        catch (WebSocketException ex) when (ex.WebSocketErrorCode is WebSocketError.ConnectionClosedPrematurely)
        {
            // ignore
        }
        catch (Exception ex)
        {
            throw new WebSocketsException("Error during socket handling", ex);
        }
        finally
        {
            await DisconnectSocket(socketId);
        }
    }

    private async Task HandleMessageAsync(long socketId, byte[] buffer, int messageLength)
    {
        var message = buffer.AsMemory(0, messageLength);
        // todo vm: handle it
    }

    public async Task SendMessageAsync(long socketId, string message)
    {
        if (_sockets.TryGetValue(socketId, out var socket) &&
            socket.State == WebSocketState.Open)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(
                new ArraySegment<byte>(bytes),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }

    private async Task DisconnectSocket(long socketId)
    {
        if (_sockets.TryRemove(socketId, out var socket))
            try
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Unexpected error during socket closing");
            }
            finally
            {
                socket.Dispose();
            }
    }
}
