namespace Application.Exceptions;

public class BaseCustomException : Exception
{
    protected BaseCustomException(string message) : base(message)
    {
    }
}