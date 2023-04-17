namespace PoliceDepartment.Application.Utilities;

internal interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}