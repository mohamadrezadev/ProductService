using System.Net;

namespace Application.Exceptions;

public class HttpErrorResponseException(
    HttpStatusCode statusCode,
    string errorResponse
) : Exception
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string ErrorResponse { get; } = errorResponse;
}