using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Decorators;

internal sealed class RequestHandlerUnitOfWorkDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<RequestHandlerUnitOfWorkDecorator<TRequest, TResponse>> logger;
    private readonly IRequestHandler<TRequest, TResponse> requestHandler;

    public RequestHandlerUnitOfWorkDecorator(
        IUnitOfWork unitOfWork, 
        IRequestHandler<TRequest, TResponse> requestHandler, 
        ILogger<RequestHandlerUnitOfWorkDecorator<TRequest, TResponse>> logger)
    {
        this.unitOfWork = unitOfWork;
        this.requestHandler = requestHandler;
        this.logger = logger;
    }
        
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Running decorated {Decorator} with type {Type}.",
            nameof(RequestHandlerUnitOfWorkDecorator<TRequest, TResponse>), typeof(TRequest));
        
        TResponse? response = null;
        await unitOfWork.ExecuteAsync(async () => response = await requestHandler.Handle(request, cancellationToken));
        
        return response ?? throw new InvalidCastException();
    }

}