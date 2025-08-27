using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Messenger.Common.Grpc.Client;

public static class GrpcClientDiExtensions
{
    public static IServiceCollection AddGrpcClient<TGrpcService>(this IServiceCollection services, string endpoint) where TGrpcService : class
    {
        services.TryAddSingleton<GrpcClientFactory>();
        services.AddSingleton<TGrpcService>(sp => sp.GetRequiredService<GrpcClientFactory>().Get<TGrpcService>(endpoint));
        return services;
    }
}
