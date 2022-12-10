using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

public class OperationalGroup
{
    public Guid Id { get; }
    public OperationalGroupName OperationalGroupName { get; }
    public OperationalGroupStatus OperationalGroupStatus { get; }
    public IEnumerable<PoliceOfficer> PoliceOfficers { get; }

    public OperationalGroup(Guid id, OperationalGroupName operationalGroupName, OperationalGroupStatus lastName, IEnumerable<PoliceOfficer> policeOfficers)
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