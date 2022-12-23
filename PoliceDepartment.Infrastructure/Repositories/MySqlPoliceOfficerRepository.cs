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

    public Task<List<PoliceOfficer>> GetAll()
        => _dbContext.PoliceOfficers.ToListAsync();

    public Task<PoliceOfficer?> GetByGuid(Guid id)
        => _dbContext.PoliceOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.Id == id);

    public Task<PoliceOfficer?> GetByBadgeNumber(BadgeNumber badgeNumber)
        => _dbContext.PoliceOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.BadgeNumber == badgeNumber);

    public async Task Add(PoliceOfficer policeOfficer)
    {
        await _dbContext.AddAsync(policeOfficer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Remove(PoliceOfficer policeOfficer)
    {
        _dbContext.PoliceOfficers.Remove(policeOfficer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(PoliceOfficer policeOfficer)
    {
        _dbContext.PoliceOfficers.Update(policeOfficer);
        await _dbContext.SaveChangesAsync();
    }


}