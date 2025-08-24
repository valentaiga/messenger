namespace Messenger.Web.Api.Models.Identity;

public class UpdateProfileRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
