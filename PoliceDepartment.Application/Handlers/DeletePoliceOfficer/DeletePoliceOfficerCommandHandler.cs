using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.DeletePoliceOfficer;

[UsedImplicitly]
internal sealed class DeletePoliceOfficerCommandHandler(
    IPoliceOfficerRepository _policeOfficerRepository,
    ILogger<DeletePoliceOfficerCommandHandler> _logger)
    : IRequestHandler<DeletePoliceOfficerCommand, bool>
{
    public async Task<bool> Handle(DeletePoliceOfficerCommand request, CancellationToken cancellationToken)
    {
        await _policeOfficerRepository.RemoveAsync(request.Id);
        
        _logger.LogInformation("Police officer {id} has been deleted.", request.Id);

        return true;
    }
}