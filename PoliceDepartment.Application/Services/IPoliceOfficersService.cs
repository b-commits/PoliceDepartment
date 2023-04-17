using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Application.Handlers.DeletePoliceOfficer;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Services;

public interface IPoliceOfficerService
{
    Task<IEnumerable<PoliceOfficer>> GetAllAsync();
    Task<PoliceOfficer> GetByGuidAsync(Guid id);
    Task<Guid> AddAsync(CreatePoliceOfficerCommand command);
    Task RemoveAsync(DeletePoliceOfficerCommand command);
    Task<bool> Update(PoliceOfficer policeOfficer, Guid id);
}