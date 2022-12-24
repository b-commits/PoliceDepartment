namespace PoliceDepartment.Core.Exceptions;

internal class OperationalGroupMemberCountExceededException : BasePoliceDepartmentException
{
    public OperationalGroupMemberCountExceededException(int policeOfficersLimit) 
        : base($"A single Operational Group group cannot have more than {policeOfficersLimit} members.")
    {
    }
}