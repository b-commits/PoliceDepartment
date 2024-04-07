using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public sealed record Username
{
    public string Value { get; set;  }

    private const int maxUserNameLength = 20;

    public Username(string value)
    {
        if (value.Length > maxUserNameLength || HasIllegalCharacter(value))
            throw new InvalidUsernameException($"Username cannot be longer than {maxUserNameLength} character");
        
        Value = value;
    }
    
    private static bool HasIllegalCharacter(string name)
    {
        char[] illegalCharacters = ['-', '#', '$'];
        return name.ToCharArray().Any(c => illegalCharacters.Contains(c));
    }
    
    public static implicit operator Username(string value)
        => new(value);

}