using System.Runtime.Serialization;
namespace RoundAbout.Runtime;

public class RbException : Exception
{
    public RbException()
    {
    }

    public RbException(string? message) : base(message)
    {
    }

    public RbException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected RbException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public static RbException Wraps(Exception ex)
    {
        return new RbException(ex.Message, ex);
    }
}

public class MalformedNumberException : RbException
{
    public MalformedNumberException() : base("Read digits were malformed")
    {
    }

    public MalformedNumberException(string? message) : base(message)
    {
    }

    public MalformedNumberException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MalformedNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

public class NumberOutOfRangeException : RbException
{
    public NumberOutOfRangeException() : base("Value is out of range")
    {
    }

    public NumberOutOfRangeException(string? message) : base(message)
    {
    }

    public NumberOutOfRangeException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NumberOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}