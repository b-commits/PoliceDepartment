namespace PoliceDepartment.Infrastructure.Auth;

internal record AzureAuthOptions
{
    public string ClientId { get; init; } = string.Empty;
    public string Instance { get; init; } = string.Empty;
    public string TenantId { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
}