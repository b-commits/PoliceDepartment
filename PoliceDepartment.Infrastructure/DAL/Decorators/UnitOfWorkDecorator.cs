using MediatR;

namespace PoliceDepartment.Infrastructure.DAL.Decorators;

internal sealed class UnitOfWorkDecorator<T>: IRequestHandler<T> where T : IRequest
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IRequestHandler<T> requestHandler;

    public UnitOfWorkDecorator(IUnitOfWork unitOfWork, IRequestHandler<T> requestHandler)
    {
        this.unitOfWork = unitOfWork;
        this.requestHandler = requestHandler;
    }
    
    public async Task Handle(T request, CancellationToken cancellationToken)
    {
        await unitOfWork.ExecuteAsync(() => requestHandler.Handle(request, cancellationToken));
    }
}