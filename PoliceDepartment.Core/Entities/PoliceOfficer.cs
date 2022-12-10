using System.Text.Json.Serialization;

namespace PoliceDepartment.Core.Entities;

public sealed class PoliceOfficer
{
    public Guid Id { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public string BadgeNumber { get; set; }
    public DateOnly BirthDate { get; }

    public PoliceOfficer(Guid id, string firstName, string lastName, DateOnly birthDate, string badgeNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        BadgeNumber = badgeNumber;
    }

    public override string ToString()
    {
        return $"[{Id}] Officer {FirstName} {LastName}, born {BirthDate}, badge number {BadgeNumber}.";
    }
}
