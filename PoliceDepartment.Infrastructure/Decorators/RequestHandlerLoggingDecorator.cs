using MediatR;
using Microsoft.Extensions.Logging;

namespace PoliceDepartment.Infrastructure.Decorators;

internal sealed class RequestHandlerLoggingDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
    private readonly ILogger<RequestHandlerLoggingDecorator<TRequest, TResponse>> _logger;
    private readonly IRequestHandler<TRequest, TResponse> _requestHandler;

    public RequestHandlerLoggingDecorator(
        ILogger<RequestHandlerLoggingDecorator<TRequest, TResponse>> logger, 
        IRequestHandler<TRequest, TResponse> requestHandler)
    {
        _logger = logger;
        _requestHandler = requestHandler;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Logging decorator executed with: '{TRequest}', '{TResponse}",
            typeof(TRequest), typeof(TResponse));

        return await _requestHandler.Handle(request, cancellationToken);
    }
}