using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public record OperationalGroupName
{
    public string Value { get; }

    public OperationalGroupName(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length > 20)
        {
            throw new InvalidOperationalGroupNameException(value);
        }
        Value = value;
    }
    
    public static implicit operator OperationalGroupName(string value)
        => new(value);
    
}