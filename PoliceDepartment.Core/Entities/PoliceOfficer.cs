using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

public sealed class PoliceOfficer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public BadgeNumber BadgeNumber { get; private set; }
    public BirthDate BirthDate { get; private set; }

    public PoliceOfficer()
    {
    }

    public PoliceOfficer(
        Guid id, string firstName, string lastName, 
        BirthDate birthDate, BadgeNumber badgeNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        BadgeNumber = badgeNumber;
    }

    public override string ToString()
        => $"[{Id}] Officer {FirstName} {LastName}, " + 
           $"born {BirthDate}, badge number {BadgeNumber}.";
    
}
