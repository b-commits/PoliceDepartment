using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Infrastructure.Middleware;

public sealed class GlobalExceptionHandler(
    IHostEnvironment webHostEnvironment,
    ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        var (statusCode, message, exceptionName) = exception switch
        {
            BasePoliceDepartmentException => (StatusCodes.Status400BadRequest, exception.Message, 
                exception.GetType().Name.Replace("Exception", string.Empty)),
            _ => (StatusCodes.Status500InternalServerError, 
                webHostEnvironment.IsDevelopment() ? exception.Message : "An error occurred.", 
                nameof(exception))
        };
        
        if (webHostEnvironment.IsDevelopment())
            logger.LogError(exception.StackTrace);
        
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = exceptionName,
            Status = statusCode,
            Detail = message
        };
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken); 
        
        return true;
    }
}
