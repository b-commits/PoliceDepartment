namespace PoliceDepartment.Infrastructure.Helpers;

internal static class AzureOnPremiseMySqlConnectionStringNormalizer
{
    internal static string Normalize(string? rawAzureOnPremiseMySqlConnectionString) {
        var dictionary = rawAzureOnPremiseMySqlConnectionString!
                .Split(';')
                .Where(keyValuePair => keyValuePair.Contains('='))
                .Select(kvp => kvp.Split(['='], 2))
                .ToDictionary(kvp => kvp[0].Trim(), kvp => kvp[1].Trim(), StringComparer.InvariantCultureIgnoreCase);
        var dataSource = dictionary["Data Source"];
        var dataSourceTokens = dataSource.Split(":");
        return $"Server={dataSourceTokens[0]};Port={dataSourceTokens[1]};Database={dictionary["Database"]};Uid={dictionary["User Id"]};Pwd={dictionary["Password"]};";
    }
}