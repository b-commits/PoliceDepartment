using Microsoft.Extensions.Configuration;

namespace PoliceDepartment.IntegrationTest;


public sealed class OptionsProvider
{
    private readonly IConfiguration _configuration;
    
    public OptionsProvider(IConfiguration configuration)
    {
        _configuration = GetConfigurationRoot();
    }

    public string GetConnectionString() 
        => _configuration.GetConnectionString("MySQL") ?? throw new InvalidOperationException();
    
    private static IConfiguration GetConfigurationRoot()
        => new ConfigurationBuilder()
            .AddJsonFile("appSettings.Test.json", false)
            .Build();
}