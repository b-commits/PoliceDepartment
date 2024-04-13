using MediatR;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.GetPoliceOfficerById;

internal sealed record GetPoliceOfficerByIdQuery(Guid Id) : IRequest<PoliceOfficer?>;