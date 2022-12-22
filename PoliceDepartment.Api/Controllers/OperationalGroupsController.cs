using Microsoft.AspNetCore.Mvc;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class OperationalGroupsController : ControllerBase
{
    [HttpPost]
    public ActionResult Post(OperationalGroup group, long id)
    {
        var modelState = ModelState;
        Console.WriteLine(group);
        return Ok();
    }
}


public class OperationalGroup
{
    public string Name { get; set; }
}