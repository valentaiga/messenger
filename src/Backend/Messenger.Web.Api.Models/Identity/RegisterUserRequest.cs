namespace Messenger.Web.Api.Models.Identity;

public sealed class RegisterUserRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
