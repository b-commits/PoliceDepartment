using MediatR;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.GetPoliceOfficerById;

public sealed record GetPoliceOfficerByIdQuery(Guid Id) : IRequest<PoliceOfficer?>;