using System.Security.Cryptography;
using Messenger.Identity.App.Grpc.Contracts;
using Messenger.Identity.App.Grpc.Contracts.Models;
using ProtoBuf.Grpc;

namespace Messenger.Identity.App;

// todo: add tests after business logic impl
public class IdentityAppService : IIdentityApp
{
    public async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request, CallContext context = default)
    {
        return new AuthenticateUserResponse
        {
            AccessToken = RandomNumberGenerator.GetHexString(36),
            RefreshToken = RandomNumberGenerator.GetHexString(36),
            DueDate = DateTime.UtcNow + TimeSpan.FromMinutes(10),
            UserId = 0
        };
    }
}
