using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Web.Api.WebSockets;

public static class WebSocketsDiExtensions
{
    public static IApplicationBuilder UseWebSocketHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<WebSocketMiddleware>();
    }

    public static IServiceCollection AddWebSocketHandler(this IServiceCollection services)
    {
        services.AddSingleton<WebSocketMiddleware>();
        services.AddSingleton<WebSocketsHandler>();
        return services;
    }
}
