using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

internal sealed record BirthDate
{
    public DateOnly Value { get; }
    

    public BirthDate(DateOnly value)
    {
        if (value.Year < 1950 || value.Year > DateOnly.MaxValue.Year - 20)
        {
            throw new InvalidBirthDateException(value.Year);
        }
    }
}