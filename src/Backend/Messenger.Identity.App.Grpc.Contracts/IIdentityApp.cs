using Messenger.Identity.App.Grpc.Contracts.Models;

namespace Messenger.Identity.App.Grpc.Contracts;

[Service]
public interface IIdentityApp
{
    [Operation]
    Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request, CancellationToken ct = default);
}
