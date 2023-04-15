using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Infrastructure.Middleware;

public sealed class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly ILogger<ErrorHandlingMiddleware> logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        IWebHostEnvironment webHostEnvironment,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        this.next = next;
        this.webHostEnvironment = webHostEnvironment;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception.StackTrace);
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message, exceptionThrown) = exception switch
        {
            BasePoliceDepartmentException => (StatusCodes.Status400BadRequest, exception.Message, 
                exception.GetType().Name.Replace("Exception", string.Empty)),
            _ => (StatusCodes.Status500InternalServerError, 
                webHostEnvironment.IsDevelopment() ? exception.Message : "An error occurred.", 
                nameof(exception))
        };
        
        if (webHostEnvironment.IsDevelopment())
            logger.LogError(exception.StackTrace);

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new { Exception = exceptionThrown, Message = message });
    }
}
