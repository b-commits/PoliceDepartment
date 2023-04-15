using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Infrastructure.Middleware;

public sealed class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly IWebHostEnvironment webHostEnvironment;

    public ErrorHandlingMiddleware(RequestDelegate next, 
        IWebHostEnvironment webHostEnvironment)
    {
        this.next = next;
        this.webHostEnvironment = webHostEnvironment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception exception)
        {
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

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new { Exception = exceptionThrown, Message = message });
    }
}
