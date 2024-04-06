using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public sealed record BirthDate
{
    public DateOnly Value { get; }

    private const int MinimalBirthYear = 1950;

    public BirthDate(DateOnly value)
    {
        if (value.Year < MinimalBirthYear || value.Year > DateOnly.MaxValue.Year - 20)
        {
            throw new InvalidBirthDateException(value.Year);
        }

        Value = value;
    }
    
    public static implicit operator BirthDate(DateOnly value)
        => new(value);
}