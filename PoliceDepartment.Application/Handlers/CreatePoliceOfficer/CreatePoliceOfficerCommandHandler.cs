using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.CreatePoliceOfficer;

[UsedImplicitly]
internal sealed class CreatePoliceOfficerCommandHandler(
    IPoliceOfficerRepository repository,
    ILogger<IPoliceOfficerRepository> logger)
    : IRequestHandler<CreatePoliceOfficerCommand, PoliceOfficer>
{
    public async Task<PoliceOfficer> Handle(CreatePoliceOfficerCommand request, CancellationToken cancellationToken)
    {
        var policeOfficer = new PoliceOfficer(request.Id, request.FirstName, request.LastName, request.BirthDate,
            request.BadgeNumber);

        await repository.AddAsync(policeOfficer);

        logger.LogInformation("Police officer {id} has been added", request.Id);

        return policeOfficer;
    }
}