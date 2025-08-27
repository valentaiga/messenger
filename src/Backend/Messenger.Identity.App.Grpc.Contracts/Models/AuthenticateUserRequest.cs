namespace Messenger.Identity.App.Grpc.Contracts.Models;

[DataContract]
public class AuthenticateUserRequest
{
    [DataMember(Order = 1)]
    public required string Email { get; set; }

    [DataMember(Order = 2)]
    public required string Password { get; set; }
}
