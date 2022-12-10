namespace PoliceDepartment.Core.Exceptions;

public class InvalidBirthDateException : CustomException
{
    protected internal InvalidBirthDateException(int year) 
        : base($"An active officer can not be born in {year}.")
    {
    }
}