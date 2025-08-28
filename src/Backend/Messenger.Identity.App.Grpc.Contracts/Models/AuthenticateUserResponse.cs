namespace Messenger.Identity.App.Grpc.Contracts.Models;

[ProtoContract]
public class AuthenticateUserResponse
{
    [ProtoMember(1)]
    public required string AccessToken { get; set; }

    [ProtoMember(2)]
    public required string RefreshToken { get; set; }

    [ProtoMember(3)]
    public required DateTime DueDate { get; set; }

    [ProtoMember(4)]
    public required long UserId { get; set; }
}
