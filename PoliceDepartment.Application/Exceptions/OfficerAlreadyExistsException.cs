using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class OfficerAlreadyExistsException(Guid id) 
    : BasePoliceDepartmentException($"Officer with id '{id}' already exists.");