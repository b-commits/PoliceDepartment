using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PoliceDepartment.IntegrationTest;

internal sealed class PoliceDepartmentTestApp : WebApplicationFactory<Program>
{
    public HttpClient Client { get; }
    
    public PoliceDepartmentTestApp()
    {
        Client = WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("test");
        }).CreateClient();
    }
}