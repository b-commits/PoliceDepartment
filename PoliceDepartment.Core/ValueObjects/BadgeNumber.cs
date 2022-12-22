using System.Text.RegularExpressions;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public sealed record BadgeNumber
{
    public string Value { get; set; }

    public BadgeNumber(string value)
    {
        if (!HasCorrectBadgeFormat(value) || string.IsNullOrEmpty(value))
        {
            throw new IncorrectBadgeFormatException(value);
        }
        Value = value;
    }

    private static bool HasCorrectBadgeFormat(string value)
    {
        var badgeNumberFormat = new Regex("^#-[0-9]{3}-[0-9]{3}-[0-9]{3}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return badgeNumberFormat.IsMatch(value);
    }
    
    public static implicit operator BadgeNumber(string value)
        => new(value);
    
}