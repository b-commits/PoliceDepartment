using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class BadgeNumberAlreadyRegistered(string badgeNumber)
    : BasePoliceDepartmentException($"Badge number '{badgeNumber}' is already registered.");