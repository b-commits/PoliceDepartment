using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Repositories;

public sealed class MySqlPoliceOfficerRepository : IPoliceOfficerRepository
{
    private readonly PoliceDepartmentDbContext _dbContext;

    public MySqlPoliceOfficerRepository(PoliceDepartmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PoliceOfficer>> GetAllAsync() 
        => await _dbContext.PoliceOfficers.ToListAsync();
   

    public Task<PoliceOfficer?> GetByGuidAsync(Guid id)
        => _dbContext.PoliceOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.Id == id);

    public Task<PoliceOfficer?> GetByBadgeNumberAsync(BadgeNumber badgeNumber)
        => _dbContext.PoliceOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.BadgeNumber == badgeNumber);

    public async Task AddAsync(PoliceOfficer policeOfficer)
    {
        await _dbContext.AddAsync(policeOfficer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(PoliceOfficer policeOfficer)
    {
        _dbContext.PoliceOfficers.Remove(policeOfficer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PoliceOfficer policeOfficer)
    {
        _dbContext.PoliceOfficers.Update(policeOfficer);
        await _dbContext.SaveChangesAsync();
    }


}