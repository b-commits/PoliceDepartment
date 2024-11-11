using PoliceDepartment.Core.Primitives;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

public sealed class PoliceOfficer(
    Guid id,
    string firstName,
    string lastName,
    BirthDate birthDate,
    BadgeNumber badgeNumber) : IAuditableEntity
{
    public Guid Id { get; private init; } = id;
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public BadgeNumber BadgeNumber { get; private set; } = badgeNumber;
    public BirthDate BirthDate { get; private set; } = birthDate;
    
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }

    public override string ToString()
        => $"[{Id}] Officer {FirstName} {LastName}, " + 
           $"born {BirthDate}, badge number {BadgeNumber}.";

    public void UpdatePoliceOfficer(PoliceOfficer policeOfficer)
    {
        BadgeNumber = policeOfficer.BadgeNumber;
        FirstName = policeOfficer.FirstName;
        BadgeNumber = policeOfficer.BadgeNumber;
        BirthDate = policeOfficer.BirthDate;
    }
    
}
