using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.SignUp;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UsersController(ISender mediator) : ControllerBase
{
    public async Task<ActionResult> Post(SignUpCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}