using System.Diagnostics.CodeAnalysis;
using PoliceDepartment.Core.Enums;
using PoliceDepartment.Core.Exceptions;
using PoliceDepartment.Core.Primitives;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
public class OperationalGroup(
    Guid id,
    OperationalGroupName operationalGroupName,
    HashSet<PoliceOfficer> policeOfficers,
    DateOnly dateFormed) : IAuditableEntity
{
    public Guid Id { get; private init; } = id;
    public OperationalGroupName OperationalGroupName { get; private init; } = operationalGroupName;
    public OperationalGroupStatus OperationalGroupStatus { get; set; } = OperationalGroupStatus.AwaitingOrders;
    public HashSet<PoliceOfficer> PoliceOfficers { get; private init; } = policeOfficers;
    public DateOnly DateFormed { get; private init; } = dateFormed;
    public DateTime? DateDisbanded { get; set; } = null;
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }

    private const int MaxPoliceOfficers = 10;

    internal void Disband()
    {
        if (OperationalGroupStatus is OperationalGroupStatus.Disbanded) 
            return;
        
        OperationalGroupStatus = OperationalGroupStatus.Disbanded;
        DateDisbanded = DateTime.Today;
        PoliceOfficers.Clear();
    }

    internal void AddPoliceOfficer(PoliceOfficer policeOfficer)
    {
        if (PoliceOfficers.Count == MaxPoliceOfficers)
        {
            throw new OperationalGroupMemberCountExceededException(MaxPoliceOfficers);
        }

        PoliceOfficers.Add(policeOfficer);
    }

    internal void RemovePoliceOfficer(Guid policeOfficerId) => 
        PoliceOfficers.RemoveWhere(policeOfficer => policeOfficer.Id == policeOfficerId);
    

    public override string ToString() => 
        $"""
         [{Id}] Operational group {OperationalGroupName},
                 number of members: {PoliceOfficers.Count}, status: {OperationalGroupStatus}
         """;


}