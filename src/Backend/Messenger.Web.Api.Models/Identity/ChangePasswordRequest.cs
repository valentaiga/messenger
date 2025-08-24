namespace Messenger.Web.Api.Models.Identity;

public sealed class ChangePasswordRequest
{
    public required string Email { get; set; }
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
}
