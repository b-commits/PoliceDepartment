namespace PoliceDepartment.Infrastructure.Auth;

internal record JwtOptions
{
    public string SigningKey { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public TimeSpan? Expiry { get; init; }
}