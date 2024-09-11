namespace Application.Exceptions;

public sealed class HttpStatusCodeAttribute(int statusCode) : Attribute
{
    public int StatusCode { get; } = statusCode;
}