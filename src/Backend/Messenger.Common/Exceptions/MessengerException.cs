namespace Messenger.Common.Exceptions;

public class MessengerException : Exception
{
    public MessengerException(string message) : base(message)
    {
    }

    public MessengerException(string message, Exception inner) : base(message, inner)
    {
    }
}
