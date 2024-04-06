using System.Text.RegularExpressions;
using PoliceDepartment.Core.Exceptions;

namespace PoliceDepartment.Core.ValueObjects;

public sealed partial record BadgeNumber
{
    public string Value { get; set; }
    
    [GeneratedRegex("^#-[0-9]{3}-[0-9]{3}-[0-9]{3}$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-PL")]
    private static partial Regex MyRegex();

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
        var badgeNumberFormat = MyRegex();
        return badgeNumberFormat.IsMatch(value);
    }
    
    public static implicit operator BadgeNumber(string value)
        => new(value);
}