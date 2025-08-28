using Messenger.Common.Grpc.Client;
using Messenger.Identity.App.Grpc.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Identity.App.Grpc.Client;

public static class ClientDiExtensions
{
    public static IServiceCollection AddIdentityGrpcClient(this IServiceCollection services, string configSectionPath)
    {
        services.AddGrpcClient<IdentityApp.IdentityAppClient>(configSectionPath, channel => new IdentityApp.IdentityAppClient(channel));
        return services;
    }
}
