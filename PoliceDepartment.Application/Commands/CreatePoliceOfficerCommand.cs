using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Application.Commands;

public record CreatePoliceOfficerCommand(string FirstName, string LastName,
    BadgeNumber BadgeNumber, BirthDate BirthDate, Guid Id = new());