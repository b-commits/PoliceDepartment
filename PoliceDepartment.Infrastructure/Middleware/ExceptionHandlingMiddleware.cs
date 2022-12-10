using Microsoft.AspNetCore.Http;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Infrastructure.Middleware;

public sealed class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message, exceptionThrown) = exception switch
        {
            CustomException => (StatusCodes.Status400BadRequest, exception.Message, 
                exception.GetType().Name.Replace("Exception", string.Empty)),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred.", nameof(exception))
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new { Exception = exceptionThrown, Message = message });
    }
}
