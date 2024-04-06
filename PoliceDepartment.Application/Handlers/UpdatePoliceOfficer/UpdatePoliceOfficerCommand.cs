using MediatR;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.UpdatePoliceOfficer;

public sealed record UpdatePoliceOfficerCommand(Guid Id, PoliceOfficer Officer) : IRequest<PoliceOfficer>;