using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Repositories;

public interface IPoliceOfficerRepository
{
    Task<IEnumerable<PoliceOfficer>> GetAllAsync();
    Task<PoliceOfficer?> GetByGuidAsync(Guid id);
    Task<PoliceOfficer?> GetByBadgeNumberAsync(BadgeNumber badgeNumber);
    Task AddAsync(PoliceOfficer policeOfficer);
    Task RemoveAsync(PoliceOfficer policeOfficer);
    Task UpdateAsync(PoliceOfficer policeOfficer);
}