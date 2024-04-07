using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Infrastructure.Middleware;

public sealed class GlobalExceptionHandler(
    IHostEnvironment webHostEnvironment,
    ILogger<GlobalExceptionHandler> logger,
    ProblemDetailsFactory problemDetailsFactory)
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
                GetExceptionName(exception)),
            _ => (StatusCodes.Status500InternalServerError, exception.Message, GetExceptionName(exception))
        };

        var problemDetails = problemDetailsFactory.CreateProblemDetails(
            httpContext, 
            statusCode, 
            $"An error has occurred: {exceptionName}", 
            detail: message);
        
        if (webHostEnvironment.IsDevelopment())
        {
            logger.LogError("{exceptionName}: {exception.StackTrace}", 
                exceptionName, exception.StackTrace);
            problemDetails.Extensions["stackTrace"] = exception.StackTrace;
        }
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken); 
        
        return true;
    }

    private static string GetExceptionName(Exception ex)
        => ex.GetType().Name.Replace("Exception", string.Empty);

}
