namespace Messenger.Identity.App.Grpc.Contracts.Models;

[ProtoContract]
public class AuthenticateUserResponse
{
    [DataMember(Order = 1)]
    public required string AccessToken { get; set; }

    [DataMember(Order = 2)]
    public required string RefreshToken { get; set; }

    [DataMember(Order = 3)]
    public required DateTime DueDate { get; set; }

    [DataMember(Order = 4)]
    public required long UserId { get; set; }
}
