namespace PoliceDepartment.Core.Exceptions;

internal class InvalidBirthDateException : BasePoliceDepartmentException
{
    protected internal InvalidBirthDateException(int year) 
        : base($"An active officer can not be born in {year}.")
    {
    }
}