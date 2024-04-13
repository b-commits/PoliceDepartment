using MediatR;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.GetPoliceOfficers;

internal record GetPoliceOfficersQuery() : IRequest<IEnumerable<PoliceOfficer>>;