using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Mappers;
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
        var policeOfficer = PoliceOfficerMapper.Map(request);

        await repository.AddAsync(policeOfficer);

        logger.LogInformation("Police officer {id} has been added.", request.Id);

        return policeOfficer;
    }
}