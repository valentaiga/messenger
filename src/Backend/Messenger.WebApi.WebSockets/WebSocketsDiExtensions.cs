using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.WebApi.WebSockets;

public static class WebSocketsDiExtensions
{
    public static IApplicationBuilder UseWebSocketHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<WebSocketMiddleware>();
    }

    public static IServiceCollection AddWebSocketHandler(this IServiceCollection services)
    {
        services.AddSingleton<WebSocketsHandler>();
        return services;
    }
}
