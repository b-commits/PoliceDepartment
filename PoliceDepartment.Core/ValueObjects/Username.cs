using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public sealed record Username
{
    public string Name { get;  }

    private const int maxUserNameLength = 20;

    public Username(string name)
    {
        if (name.Length > maxUserNameLength || HasIllegalCharacter(name))
            throw new InvalidUsernameException($"Username cannot be longer than {maxUserNameLength} character");
        
        Name = name;
    }
    
    private static bool HasIllegalCharacter(string name)
    {
        char[] illegalCharacters = ['-', '#', '$'];
        return name.ToCharArray().Any(c => illegalCharacters.Contains(c));
    }

}