using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Commands;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers;

[UsedImplicitly]
internal sealed class CreatePoliceOfficerCommandHandler : IRequestHandler<CreatePoliceOfficerCommand, PoliceOfficer>
{
    private readonly IPoliceOfficerRepository repository;
    private readonly ILogger<IPoliceOfficerRepository> logger;

    public CreatePoliceOfficerCommandHandler(IPoliceOfficerRepository repository, 
        ILogger<IPoliceOfficerRepository> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<PoliceOfficer> Handle(CreatePoliceOfficerCommand request, CancellationToken cancellationToken)
    {
        var policeOfficer = new PoliceOfficer(request.Id, request.FirstName, request.LastName, request.BirthDate,
            request.BadgeNumber);

        await repository.AddAsync(policeOfficer);

        logger.LogInformation("Police officer {id} has been added", request.Id);

        return policeOfficer;
    }
}