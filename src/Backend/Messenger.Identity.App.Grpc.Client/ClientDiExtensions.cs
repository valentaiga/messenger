using Messenger.Common.Grpc.Client;
using Messenger.Identity.App.Grpc.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Identity.App.Grpc.Client;

public static class ClientDiExtensions
{
    public static IServiceCollection AddIdentityGrpcClient(this IServiceCollection services, string endpoint)
    {
        GrpcClientDiExtensions.AddGrpcClient<IIdentityApp>(services, endpoint);
        return services;
    }
}
