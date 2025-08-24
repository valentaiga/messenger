namespace Messenger.Web.Api.Models.Identity;

public sealed class LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
