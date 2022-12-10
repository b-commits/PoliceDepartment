namespace PoliceDepartment.Core.Exceptions;

internal class InvalidOperationalGroupNameException : BasePoliceDepartmentException
{
    protected internal InvalidOperationalGroupNameException(string name) 
        : base($"Operational group name {name} is invalid.")
    {
    }
}