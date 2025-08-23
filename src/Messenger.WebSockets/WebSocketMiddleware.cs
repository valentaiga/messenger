using Microsoft.AspNetCore.Http;

namespace Messenger.WebSockets;

public class WebSocketMiddleware : IMiddleware
{
    private readonly RequestDelegate _next;
    private readonly WebSocketsHandler _webSocketHandler;

    public WebSocketMiddleware(RequestDelegate next, WebSocketsHandler webSocketHandler)
    {
        _next = next;
        _webSocketHandler = webSocketHandler;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var userId = 0L;
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await _webSocketHandler.HandleWebSocketAsync(userId, webSocket, context.RequestAborted);
        }
        else
        {
            await _next(context);
        }
    }
}
