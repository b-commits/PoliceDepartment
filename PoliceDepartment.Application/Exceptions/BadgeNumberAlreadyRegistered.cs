using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class BadgeNumberAlreadyRegistered : BasePoliceDepartmentException
{
    public BadgeNumberAlreadyRegistered(string badgeNumber) : 
        base($"Badge number '{badgeNumber}' is already registered.")
    {
    }
}