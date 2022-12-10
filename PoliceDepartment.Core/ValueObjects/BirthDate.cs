using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public sealed record BirthDate
{
    public DateOnly Value { get; }
    
    public BirthDate(DateOnly value)
    {
        if (value.Year < 1950 || value.Year > DateOnly.MaxValue.Year - 20)
        {
            throw new InvalidBirthDateException(value.Year);
        }

        Value = value;
    }
    
    public static implicit operator BirthDate(DateOnly value)
        => new(value);
}