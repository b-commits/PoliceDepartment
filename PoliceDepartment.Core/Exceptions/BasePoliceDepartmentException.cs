namespace PoliceDepartment.Core.Exceptions;

public class BasePoliceDepartmentException : Exception
{
    protected BasePoliceDepartmentException(string message) : base(message)
    {
    }
}