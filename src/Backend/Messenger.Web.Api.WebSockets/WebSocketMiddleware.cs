using Microsoft.AspNetCore.Http;

namespace Messenger.Web.Api.WebSockets;

public class WebSocketMiddleware : IMiddleware
{
    private readonly WebSocketsHandler _webSocketHandler;

    public WebSocketMiddleware(WebSocketsHandler webSocketHandler)
    {
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
            await next(context);
        }
    }
}
