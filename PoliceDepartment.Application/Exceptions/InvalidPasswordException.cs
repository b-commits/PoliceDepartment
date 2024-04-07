using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class InvalidPasswordException() : BasePoliceDepartmentException("Invalid password provided.");