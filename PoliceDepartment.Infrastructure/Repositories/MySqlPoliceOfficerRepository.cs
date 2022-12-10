using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Repositories;

internal sealed class MySqlPoliceOfficerRepository : IPoliceOfficerRepository
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

    public Task Add(PoliceOfficer policeOfficer)
    {
        _dbContext.AddAsync(policeOfficer);
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public Task Remove(PoliceOfficer policeOfficer)
    {
        _dbContext.PoliceOfficers.Remove(policeOfficer);
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public Task Update(PoliceOfficer policeOfficer)
    {
        _dbContext.PoliceOfficers.Update(policeOfficer);
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }


}