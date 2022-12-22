using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Commands;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliceOfficersController : ControllerBase
{
    private readonly IPoliceOfficerService _policeOfficersService;

    public PoliceOfficersController(IPoliceOfficerService policeOfficersService)
    {
        _policeOfficersService = policeOfficersService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PoliceOfficer>>> Get() 
        => Ok(await _policeOfficersService.GetAll());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PoliceOfficer>> Get(Guid id) 
        => Ok(await _policeOfficersService.GetByGuid(id));

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(DeletePoliceOfficerCommand command) 
        => Ok(await _policeOfficersService.Remove(command));

    [HttpPost]
    public async Task<ActionResult<PoliceOfficer>> Post(CreatePoliceOfficerCommand command)
        => CreatedAtAction(nameof(Get), new { Id = await _policeOfficersService.Add(command) });

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(PoliceOfficer policeOfficer, Guid id) 
        => Ok(await _policeOfficersService.Update(policeOfficer, id));
}