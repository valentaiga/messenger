using Messenger.Identity.App.Grpc.Contracts.Models;

namespace Messenger.Identity.App.Grpc.Contracts;

[ServiceContract(Name = "IdentityApp")]
public interface IIdentityApp
{
    [OperationContract]
    Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request, CallContext context = default);
}
