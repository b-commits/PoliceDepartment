namespace PoliceDepartment.Core.Exceptions;

internal class IncorrectBadgeFormatException : BasePoliceDepartmentException
{
    protected internal IncorrectBadgeFormatException(string badgeNumber) 
        : base($"Badge {badgeNumber} has an incorrect badge format.")
    {
    }
}