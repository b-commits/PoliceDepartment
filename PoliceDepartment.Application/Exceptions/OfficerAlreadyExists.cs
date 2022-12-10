using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Application.Exceptions;

public class OfficerAlreadyExists : CustomException
{
    public OfficerAlreadyExists(Guid id) : 
        base($"Officer with id {id} already exists.")
    {
    }
}