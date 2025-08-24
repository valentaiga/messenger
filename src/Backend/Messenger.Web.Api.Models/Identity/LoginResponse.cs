namespace Messenger.Web.Api.Models.Identity;

public sealed class LoginResponse
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime DueDate { get; set; }
}
