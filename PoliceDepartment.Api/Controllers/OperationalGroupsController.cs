using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class OperationalGroupsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult Post(CreatePoliceOfficerCommand command)
        => Ok(mediator.Send(command));
}

