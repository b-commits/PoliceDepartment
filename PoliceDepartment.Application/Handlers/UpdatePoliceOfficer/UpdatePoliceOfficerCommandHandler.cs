using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.UpdatePoliceOfficer;

[UsedImplicitly]
internal sealed class UpdatePoliceOfficerCommandHandler(
    ILogger<UpdatePoliceOfficerCommandHandler> logger,
    IPoliceOfficerRepository repository)
    : IRequestHandler<UpdatePoliceOfficerCommand, PoliceOfficer>
{
    public async Task<PoliceOfficer> Handle(UpdatePoliceOfficerCommand request, CancellationToken cancellationToken)
    {
        var policeOfficer = repository.GetByGuidAsync(request.Id);

        if (policeOfficer is null)
            throw new OfficerNotFoundException(request.Id);

        var newPoliceOfficer = await repository.UpdateAsync(request.Officer);
        logger.LogInformation("Updated police officer with id '{Guid}'.", policeOfficer.Id);

        return newPoliceOfficer;
    }
}

