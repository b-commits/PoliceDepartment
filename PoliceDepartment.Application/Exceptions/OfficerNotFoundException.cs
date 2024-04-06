using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class OfficerNotFoundException(Guid id)
    : BasePoliceDepartmentException($"Officer with id '{id}' does not exist.");