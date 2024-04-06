using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.DeletePoliceOfficer;

[UsedImplicitly]
internal sealed class DeletePoliceOfficerCommandHandler(
    IPoliceOfficerRepository policeOfficerRepository,
    ILogger<DeletePoliceOfficerCommandHandler> logger)
    : IRequestHandler<DeletePoliceOfficerCommand>
{
    public async Task Handle(DeletePoliceOfficerCommand request, CancellationToken cancellationToken)
    {
        await policeOfficerRepository.RemoveAsync(request.Id);
        
        logger.LogInformation("Police officer {id} has been deleted.", request.Id);
    }
}