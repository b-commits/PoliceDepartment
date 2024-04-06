namespace PoliceDepartment.IntegrationTest.Controllers;

public class ControllerTests
{
    protected HttpClient Client { get; }

    public ControllerTests(OptionsProvider optionsProvider)
    {
        var app = new PoliceDepartmentTestApp();
        Client = app.Client;
    }
    
}