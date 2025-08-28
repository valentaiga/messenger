namespace Messenger.Identity.App.Grpc.Contracts.Models;

[ProtoContract]
public class GrpcAuthenticateUserRequest
{
    [ProtoMember(1)]
    public required string Email { get; set; }

    [ProtoMember(2)]
    public required string Password { get; set; }
}
