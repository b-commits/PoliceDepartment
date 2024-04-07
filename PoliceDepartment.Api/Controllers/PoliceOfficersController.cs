using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Application.Handlers.DeletePoliceOfficer;
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
    public async Task<ActionResult<IEnumerable<PoliceOfficer>>> Get()
        => Ok(await policeOfficersService.GetAllAsync());
    

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PoliceOfficer>> Get(Guid id)
        => Ok(await policeOfficersService.GetByGuidAsync(id));
    
    [HttpPost]
    public async Task<ActionResult<PoliceOfficer>> Post(CreatePoliceOfficerCommand command) 
        => CreatedAtAction(nameof(Get), await mediator.Send(command));


    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(Guid id, UpdatePoliceOfficerCommand command)
    {
        return Ok(await mediator.Send(command with { Id = id }));   
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await policeOfficersService.RemoveAsync(new DeletePoliceOfficerCommand(id));
        return NoContent();
    }
    
}