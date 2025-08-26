using Messenger.Common.Exceptions;

namespace Messenger.Web.Api.WebSockets;

public sealed class WebSocketsException : MessengerException
{
    public WebSocketsException(string message) : base(message)
    {
    }

    public WebSocketsException(string message, Exception inner) : base(message, inner)
    {
    }
}
