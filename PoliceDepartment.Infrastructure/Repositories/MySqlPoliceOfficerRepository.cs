using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Repositories;

internal sealed class MySqlPoliceOfficerRepository : IPoliceOfficerRepository
{
    private readonly DbSet<PoliceOfficer> _policeOfficers;

    public MySqlPoliceOfficerRepository(PoliceDepartmentDbContext dbContext)
    {
        _policeOfficers = dbContext.PoliceOfficers;
    }

    public async Task<IEnumerable<PoliceOfficer>> GetAll()
        => await _policeOfficers.ToListAsync();

    public Task<PoliceOfficer?> GetByGuid(Guid id)
        => _policeOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.Id == id);

    public Task<PoliceOfficer?> GetByBadgeNumber(BadgeNumber badgeNumber)
        => _policeOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.BadgeNumber == badgeNumber);

    public async Task Add(PoliceOfficer policeOfficer)
        => await _policeOfficers.AddAsync(policeOfficer);

    public void Remove(PoliceOfficer policeOfficer)
        => _policeOfficers.Remove(policeOfficer);

    public void Update(PoliceOfficer policeOfficer)
        => _policeOfficers.Update(policeOfficer);
    
    
}