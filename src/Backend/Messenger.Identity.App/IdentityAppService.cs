using System.Security.Cryptography;
using Messenger.Identity.App.Grpc.Contracts;
using Messenger.Identity.App.Grpc.Contracts.Models;

namespace Messenger.Identity.App;

// todo: add tests after business logic impl
public class IdentityAppService : IIdentityApp
{
    public async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request, CancellationToken ct = default)
    {
        return new AuthenticateUserResponse // 1
        {
            AccessToken = RandomNumberGenerator.GetHexString(36),
            RefreshToken = RandomNumberGenerator.GetHexString(36),
            DueDate = DateTime.UtcNow + TimeSpan.FromMinutes(10),
            UserId = 0
        };
    }
}
