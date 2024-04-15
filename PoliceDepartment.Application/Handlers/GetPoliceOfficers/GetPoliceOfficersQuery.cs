using MediatR;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.GetPoliceOfficers;

public record GetPoliceOfficersQuery() : IRequest<IEnumerable<PoliceOfficer>>;