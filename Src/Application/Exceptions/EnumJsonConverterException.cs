using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Application.Exceptions;

[HttpStatusCode(StatusCodes.Status500InternalServerError)]
public class EnumJsonConverterException(JsonTokenType tokenType)
    : BaseCustomException($"Unexpected token parsing enum. Expected a string or number, got {tokenType}.");