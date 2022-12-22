using PoliceDepartment.Application.Commands;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Services;

public interface IPoliceOfficerService
{
    Task<IEnumerable<PoliceOfficer>> GetAll();
    Task<PoliceOfficer> GetByGuid(Guid id);
    Task<Guid> Add(CreatePoliceOfficerCommand command);
    Task<bool> Remove(DeletePoliceOfficerCommand command);
    Task<bool> Update(PoliceOfficer policeOfficer, Guid id);
}