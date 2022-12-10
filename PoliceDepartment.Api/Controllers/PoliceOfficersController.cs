using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Application.Commands;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliceOfficersController : ControllerBase
{
    private readonly PoliceOfficersService _policeOfficersService = new();

    [HttpGet]
    public ActionResult<IEnumerable<PoliceOfficer>> Get() => Ok(_policeOfficersService.GetAll());

    [HttpGet("{id:guid}")]
    public ActionResult<PoliceOfficer> Get(Guid id) => Ok(_policeOfficersService.GetByGuid(id));

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id) => Ok(_policeOfficersService.Remove(id));

    [HttpPost]
    public ActionResult<PoliceOfficer> Post(CreatePoliceOfficerCommand policeOfficer)
        => CreatedAtAction(nameof(Get), new { Id = _policeOfficersService.Add(policeOfficer) }, null);

    [HttpPut("{id:guid}")]
    public ActionResult Put(PoliceOfficer policeOfficer, Guid id) 
        => Ok(_policeOfficersService.Update(policeOfficer, id));
}