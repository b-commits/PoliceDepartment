using JetBrains.Annotations;
using MediatR;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.GetPoliceOfficers;

[UsedImplicitly]
internal sealed class GetPoliceOfficersQueryHandler : IRequestHandler<GetPoliceOfficersQuery, IEnumerable<PoliceOfficer>>
{
    private readonly IPoliceOfficerRepository _policeOfficerRepository;

    public GetPoliceOfficersQueryHandler(IPoliceOfficerRepository policeOfficerRepository)
    {
        _policeOfficerRepository = policeOfficerRepository;
    }

    public Task<IEnumerable<PoliceOfficer>> Handle(GetPoliceOfficersQuery request, CancellationToken cancellationToken)
    {
        return _policeOfficerRepository.GetAllAsync();
    }
}