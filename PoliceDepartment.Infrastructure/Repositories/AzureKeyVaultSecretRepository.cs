using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using PoliceDepartment.Application.Utilities;
using Uri = System.Uri;

namespace PoliceDepartment.Infrastructure.Repositories;

internal sealed class AzureKeyVaultSecretRepository : ISecretRepository
{
    private readonly IConfiguration _configuration;

    public AzureKeyVaultSecretRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Get()
    {
        var keyVaultName = _configuration.GetValue<string>("KeyVaultName");
        var secretName = _configuration.GetValue<string>("KeyVaultSecretName");
        
        var client = new SecretClient(
            vaultUri: new Uri($"https://{keyVaultName}.azwebsite.com"), 
            credential: new DefaultAzureCredential());

        var secret = client.GetSecretAsync(secretName).Result.Value.Value;

        return secret;
    }

    public async Task Set(string secret)
    {
        var keyVaultName = _configuration.GetValue<string>("KeyVaultName");
        var secretName = _configuration.GetValue<string>("KeyVaultSecretName");
        
        var client = new SecretClient(
            vaultUri: new Uri($"https://{keyVaultName}.azwebsite.com"), 
            credential: new DefaultAzureCredential());

        await client.SetSecretAsync(secretName, secret);
    }
}