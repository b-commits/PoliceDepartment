using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

public sealed class PoliceOfficer
{
    public Guid Id { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public BadgeNumber BadgeNumber { get; set; }
    public BirthDate BirthDate { get; }

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
