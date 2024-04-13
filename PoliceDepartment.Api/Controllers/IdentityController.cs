using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.SignUp;
using PoliceDepartment.Application.Handlers.SignIn;
using PoliceDepartment.Application.Handlers.WhoAmI;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class IdentityController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SignIn(SignInCommand command) 
        => Ok(await mediator.Send(command));
    

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> WhoAmI() 
        => Ok(await mediator.Send(new WhoAmIQuery()));
}