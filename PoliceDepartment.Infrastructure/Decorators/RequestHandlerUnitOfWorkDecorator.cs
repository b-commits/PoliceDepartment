using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Decorators;

internal sealed class RequestHandlerUnitOfWorkDecorator<T>: IRequestHandler<T> where T : IRequest
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<RequestHandlerUnitOfWorkDecorator<T>> logger;
    private readonly IRequestHandler<T> requestHandler;

    public RequestHandlerUnitOfWorkDecorator(IUnitOfWork unitOfWork, 
        IRequestHandler<T> requestHandler, 
        ILogger<RequestHandlerUnitOfWorkDecorator<T>> logger)
    {
        this.unitOfWork = unitOfWork;
        this.requestHandler = requestHandler;
        this.logger = logger;
    }
    
    public async Task Handle(T request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Running decoratored {decorator} with type {type}.", 
            nameof(RequestHandlerUnitOfWorkDecorator<T>), typeof(T));
        await unitOfWork.ExecuteAsync(() => requestHandler.Handle(request, cancellationToken));
    }
}