using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.SignUp;
using PoliceDepartment.Application.Handlers.SignIn;
using PoliceDepartment.Application.Handlers.WhoAmI;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class UsersController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> SignIn(SignInCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> WhoAmI()
    {
        return Ok(await mediator.Send(new WhoAmIQuery()));
    }
    
}