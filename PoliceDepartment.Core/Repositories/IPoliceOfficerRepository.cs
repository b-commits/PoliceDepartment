using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Repositories;

public interface IPoliceOfficerRepository
{
    Task<List<PoliceOfficer>> GetAll();
    Task<PoliceOfficer?> GetByGuid(Guid id);
    Task<PoliceOfficer?> GetByBadgeNumber(BadgeNumber badgeNumber);
    Task Add(PoliceOfficer policeOfficer);
    Task Remove(PoliceOfficer policeOfficer);
    Task Update(PoliceOfficer policeOfficer);
}