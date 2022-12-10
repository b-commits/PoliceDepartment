using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class OfficerNotFoundException : CustomException
{
    public OfficerNotFoundException(Guid id) : 
        base($"Officer with id {id} does not exist.")
    {
    }
}