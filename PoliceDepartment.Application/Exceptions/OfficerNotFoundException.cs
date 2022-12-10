using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class OfficerNotFoundException : BasePoliceDepartmentException
{
    public OfficerNotFoundException(Guid id) : 
        base($"Officer with id {id} does not exist.")
    {
    }
}