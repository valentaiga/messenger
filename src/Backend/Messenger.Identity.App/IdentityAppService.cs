using System.Security.Cryptography;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Messenger.Identity.App.Grpc.Contracts;

namespace Messenger.Identity.App;

// todo: add tests after business logic impl
public class IdentityAppService : IdentityApp.IdentityAppBase
{
    public override async Task<GrpcAuthenticateUserResponse> AuthenticateUser(GrpcAuthenticateUserRequest request, ServerCallContext context)
    {
        return new GrpcAuthenticateUserResponse
        {
            AccessToken = RandomNumberGenerator.GetHexString(36),
            RefreshToken = RandomNumberGenerator.GetHexString(36),
            DueDate = Timestamp.FromDateTime(DateTime.UtcNow + TimeSpan.FromMinutes(10)),
            UserId = 0
        };
    }
}
