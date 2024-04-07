namespace PoliceDepartment.Core.Exceptions;

internal class OperationalGroupMemberCountExceededException(int policeOfficersLimit)
    : BasePoliceDepartmentException(
        $"A single Operational Group group cannot have more than {policeOfficersLimit} members.");