using System.Diagnostics.CodeAnalysis;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
public sealed class PoliceOfficer(
    Guid id,
    string firstName,
    string lastName,
    BirthDate birthDate,
    BadgeNumber badgeNumber)
{
    public Guid Id { get; private init; } = id;
    public string FirstName { get; private init; } = firstName;
    public string LastName { get; private init; } = lastName;
    public BadgeNumber BadgeNumber { get; private init; } = badgeNumber;
    public BirthDate BirthDate { get; private init; } = birthDate;

    public override string ToString()
        => $"[{Id}] Officer {FirstName} {LastName}, " + 
           $"born {BirthDate}, badge number {BadgeNumber}.";
    
}
