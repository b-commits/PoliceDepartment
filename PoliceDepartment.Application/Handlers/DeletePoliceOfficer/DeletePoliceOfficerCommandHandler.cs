using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.DeletePoliceOfficer;

[UsedImplicitly]
internal sealed class DeletePoliceOfficerCommandHandler(
    IPoliceOfficerRepository _policeOfficerRepository,
    ILogger<DeletePoliceOfficerCommandHandler> _logger)
    : IRequestHandler<DeletePoliceOfficerCommand>
{
    public async Task Handle(DeletePoliceOfficerCommand request, CancellationToken cancellationToken)
    {
        await _policeOfficerRepository.RemoveAsync(request.Id);
        
        _logger.LogInformation("Police officer {id} has been deleted.", request.Id);
    }
}