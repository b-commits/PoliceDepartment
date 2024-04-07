using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.SignUp;
using PoliceDepartment.Application.Handlers.SignIn;
using PoliceDepartment.Application.Handlers.WhoAmI;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UsersController(ISender mediator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> SignIn(SignInCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    public async Task<ActionResult> WhoAmI()
    {
        return Ok(await mediator.Send(new WhoAmIQuery()));
    }
    
}