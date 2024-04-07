using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.SignUp;
using PoliceDepartment.Application.Handlers.SignIn;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UsersController(ISender mediator) : ControllerBase
{
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    public async Task<ActionResult> SignIn(SignInCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
    
}