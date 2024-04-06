using System.Diagnostics.CodeAnalysis;
using PoliceDepartment.Core.Exceptions;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
public class OperationalGroup
{
    public Guid Id { get; private init; }
    public OperationalGroupName OperationalGroupName { get; private init; }
    public OperationalGroupStatus OperationalGroupStatus { get; set; }
    public HashSet<PoliceOfficer> PoliceOfficers { get; private init; }
    public DateOnly DateFormed { get; private init; }
    public DateTime? DateDisbanded { get; set; }
    
    private const int MaxPoliceOfficers = 10;

    public OperationalGroup(Guid id, OperationalGroupName operationalGroupName, 
        HashSet<PoliceOfficer> policeOfficers, DateOnly dateFormed)
    {
        Id = id;
        OperationalGroupName = operationalGroupName;
        OperationalGroupStatus = OperationalGroupStatus.AwaitingOrders;
        PoliceOfficers = policeOfficers;
        DateFormed = dateFormed;
        DateDisbanded = null;
    }

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
        @$"[{Id}] Operational group {OperationalGroupName}, 
        number of members: {PoliceOfficers.Count}, status: {OperationalGroupStatus}";
}