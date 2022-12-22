using System.Diagnostics.CodeAnalysis;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
public class OperationalGroup
{
    public Guid Id { get; }
    public OperationalGroupName OperationalGroupName { get; private init; }
    public OperationalGroupStatus OperationalGroupStatus { get; private init; }
    public IEnumerable<PoliceOfficer> PoliceOfficers { get; private init; }

    public OperationalGroup(Guid id, OperationalGroupName operationalGroupName, 
        OperationalGroupStatus lastName, IEnumerable<PoliceOfficer> policeOfficers)
    {
        Id = id;
        OperationalGroupName = operationalGroupName;
        OperationalGroupStatus = lastName;
        PoliceOfficers = policeOfficers;
    }

    public override string ToString()
        => $"[{Id}] Operational group {OperationalGroupName}, " +
           $"number of members: {PoliceOfficers.Count()}, status: {OperationalGroupStatus}";

}