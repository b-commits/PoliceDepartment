using System.Net;
using Shouldly;

namespace PoliceDepartment.IntegrationTest.Controllers;

public class PoliceOfficerControllerTests : IClassFixture<OptionsProvider>
{
    public PoliceOfficerControllerTests(OptionsProvider optionsProvider)
    {
        var connectionString = optionsProvider.GetConnectionString();
    }
    
    [Fact]
    public async Task Get_ShouldReturnAllPoliceOfficersHttp200()
    {
        var app = new PoliceDepartmentTestApp();
        var response = await app.Client.GetAsync("/PoliceOfficers");
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        content.ShouldNotBeNull();
    }
}