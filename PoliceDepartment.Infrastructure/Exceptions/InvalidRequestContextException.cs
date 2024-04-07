using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Infrastructure.Exceptions;

internal sealed class InvalidRequestContextException(string message)
    : BasePoliceDepartmentException($"The {message} operation is not within the scope of an HTTP request");