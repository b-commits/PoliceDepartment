using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class BadgeNumberAlreadyRegisteredException(string badgeNumber)
    : BasePoliceDepartmentException($"Badge number '{badgeNumber}' is already registered.");