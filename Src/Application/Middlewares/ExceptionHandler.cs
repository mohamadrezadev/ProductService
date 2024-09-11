using Application.Exceptions;
using Application.Utils;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.Middlewares;

public class ExceptionHandler(RequestDelegate next)
{
    private const string InternalServerErrorMessage = "Internal Server Error";
    private const string ValidationErrorMessage = "Validation Error";
    private const string ExceptionHandlerOp = "ExceptionHandler";

    public async Task InvokeAsync(
        HttpContext httpContext,
        IHostEnvironment hostEnvironment,
        ILogger<ExceptionHandler> logger
    )
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.Log(LogLevel.Error, "An exception occurred: {ErrorMessage}",
                ExceptionHandlerOp, JsonConvert.SerializeObject(ex));
            

            await HandleExceptionAsync(logger, hostEnvironment, httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(
        ILogger<ExceptionHandler> logger,
        IHostEnvironment hostEnvironment,
        HttpContext context,
        Exception exception
    )
    {
        // Determine error message and status code
        var errStatus = StatusCodes.Status500InternalServerError;
        var errMessage = InternalServerErrorMessage;
        var errList = new List<string>();

        switch (exception)
        {
            // Handle custom exceptions
            case BaseCustomException customException:
            {
                var statusCodeAttribute = customException.GetType()
                    .GetCustomAttributes(typeof(HttpStatusCodeAttribute), inherit: false)
                    .FirstOrDefault() as HttpStatusCodeAttribute;

                errStatus = statusCodeAttribute?.StatusCode ?? StatusCodes.Status500InternalServerError;
                errMessage = customException.Message;
                break;
            }
            // Handle validation exceptions
            case ValidationException validationException:
            {
                errMessage = ValidationErrorMessage;
                errStatus = StatusCodes.Status400BadRequest;
                errList.AddRange(validationException.Errors.Select(e => e.ErrorMessage));
                break;
            }
            // Handle HTTP exceptions
            case HttpErrorResponseException httpException:
            {
                errMessage = httpException.ErrorResponse;
                errStatus = (int)httpException.StatusCode;
                break;
            }
            // Handle autoMapper exceptions
            case AutoMapperMappingException autoMapperException:
            {
                logger.Log(LogLevel.Critical, "Auto mapper error: {ErrorMessage}",
                    ExceptionHandlerOp, autoMapperException);
                break;
            }
        }

        // Handle internal exceptions
        if (errStatus >= StatusCodes.Status500InternalServerError && hostEnvironment.IsProduction())
        {
            logger.Log(LogLevel.Critical, "Internal server error: {ErrorMessage}",
                ExceptionHandlerOp, errMessage);

            errMessage = InternalServerErrorMessage;
        }

        // Return a standardized error response
        context.Response.StatusCode = errStatus;
        context.Response.ContentType = "application/problem+json";

        // Construct the error response
        var errors = errList.Count == 0 ? null : errList;
        var response = DefaultResult.Fail(errMessage, errors);

        logger.Log(LogLevel.Error, "Exception was thrown with {ErrorStatus} status and message: {ErrorMessage}",
            ExceptionHandlerOp, errStatus, errMessage);

        // Serialize response with camelCase configuration
        var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        });

        return context.Response.WriteAsync(json);
    }
}