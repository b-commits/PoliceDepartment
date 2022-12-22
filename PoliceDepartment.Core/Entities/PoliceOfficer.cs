using System.Diagnostics.CodeAnalysis;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
public sealed class PoliceOfficer
{
    public Guid Id { get; private init; }
    public string FirstName { get; private init; }
    public string LastName { get; private init; }
    public BadgeNumber BadgeNumber { get; private init; }
    public BirthDate BirthDate { get; private init; }

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
