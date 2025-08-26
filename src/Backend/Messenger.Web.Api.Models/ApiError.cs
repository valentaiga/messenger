namespace Messenger.Web.Api.Models;

public sealed class ApiError(string message, Guid traceIdentifier)
{
    public string Message { get; set; } = message;
    public Guid TraceIdentifier { get; set; } = traceIdentifier;
}
