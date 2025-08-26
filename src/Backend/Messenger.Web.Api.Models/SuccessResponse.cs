namespace Messenger.Web.Api.Models;

public sealed class SuccessResponse(bool success)
{
    public bool Success { get; set; } = success;
}
