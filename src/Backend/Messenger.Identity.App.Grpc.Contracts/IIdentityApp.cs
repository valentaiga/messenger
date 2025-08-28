using Messenger.Identity.App.Grpc.Contracts.Models;

namespace Messenger.Identity.App.Grpc.Contracts;

[ServiceContract]
public interface IIdentityApp
{
    [OperationContract]
    Task<GrpcAuthenticateUserResponse> AuthenticateUser(GrpcAuthenticateUserRequest request, CancellationToken ct = default);
}
