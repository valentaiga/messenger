using Messenger.Identity.App.Grpc.Contracts.Models;

namespace Messenger.Identity.App.Grpc.Contracts;

[ServiceContract]
public interface IIdentityApp
{
    [OperationContract]
    Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request, CancellationToken ct = default);
}
