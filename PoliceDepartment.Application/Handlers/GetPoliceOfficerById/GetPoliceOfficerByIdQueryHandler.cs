using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.GetPoliceOfficerById;

[UsedImplicitly]
internal sealed class GetPoliceOfficerByIdQueryHandler : IRequestHandler<GetPoliceOfficerByIdQuery, PoliceOfficer?>
{
    private readonly IPoliceOfficerRepository _policeOfficerRepository;
    
    public GetPoliceOfficerByIdQueryHandler(IPoliceOfficerRepository policeOfficerRepository, 
        ILogger<GetPoliceOfficerByIdQueryHandler> logger)
    {
        _policeOfficerRepository = policeOfficerRepository;
    }

    public async Task<PoliceOfficer?> Handle(GetPoliceOfficerByIdQuery request, CancellationToken cancellationToken)
    {
        var policeOfficer = await _policeOfficerRepository.GetByGuidAsync(request.Id);

        if (policeOfficer is null)
            throw new OfficerNotFoundException(request.Id);

        return policeOfficer;
    }
}