using Messenger.Common.Exceptions;

namespace Messenger.WebApi.WebSockets;

public sealed class WebSocketsException : MessengerException
{
    public WebSocketsException(string message) : base(message)
    {
    }

    public WebSocketsException(string message, Exception inner) : base(message, inner)
    {
    }
}
