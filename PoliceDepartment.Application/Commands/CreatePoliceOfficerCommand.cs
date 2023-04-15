using MediatR;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Application.Commands;

public sealed record CreatePoliceOfficerCommand(
    string FirstName, 
    string LastName, 
    BadgeNumber BadgeNumber, 
    BirthDate BirthDate, 
    Guid Id = new()) : IRequest<PoliceOfficer>;