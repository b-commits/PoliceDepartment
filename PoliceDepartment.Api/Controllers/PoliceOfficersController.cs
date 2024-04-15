using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Application.Handlers.DeletePoliceOfficer;
using PoliceDepartment.Application.Handlers.GetPoliceOfficerById;
using PoliceDepartment.Application.Handlers.GetPoliceOfficers;
using PoliceDepartment.Application.Handlers.UpdatePoliceOfficer;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public sealed class PoliceOfficersController(
    IPoliceOfficerService policeOfficersService,
    ISender mediator)
    : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PoliceOfficer>>> Get()
        => Ok(await mediator.Send(new GetPoliceOfficersQuery()));
    

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PoliceOfficer>> Get(GetPoliceOfficerByIdQuery query)
        => Ok(await mediator.Send(query));
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PoliceOfficer>> Post(CreatePoliceOfficerCommand command) 
        => CreatedAtAction(nameof(Get), await mediator.Send(command));


    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Put(Guid id, UpdatePoliceOfficerCommand command) 
        => Ok(await mediator.Send(command with { Id = id }));   
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(DeletePoliceOfficerCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}