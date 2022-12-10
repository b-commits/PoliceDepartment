using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Repositories;

public interface IPoliceOfficerRepository
{
    Task<IEnumerable<PoliceOfficer>> GetAll();
    Task<PoliceOfficer?> GetByGuid(Guid id);
    Task<PoliceOfficer?> GetByBadgeNumber(BadgeNumber badgeNumber);
    Task Add(PoliceOfficer policeOfficer);
    void Remove(PoliceOfficer policeOfficer);
    void Update(PoliceOfficer policeOfficer);
}