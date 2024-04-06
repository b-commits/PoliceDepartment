using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Repositories;

public sealed class MySqlPoliceOfficerRepository(PoliceDepartmentDbContext dbContext) : IPoliceOfficerRepository
{
    public async Task<IEnumerable<PoliceOfficer>> GetAllAsync() 
        => await dbContext.PoliceOfficers.ToListAsync();
   

    public Task<PoliceOfficer?> GetByGuidAsync(Guid id)
        => dbContext.PoliceOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.Id == id);

    public Task<PoliceOfficer?> GetByBadgeNumberAsync(BadgeNumber badgeNumber)
        => dbContext.PoliceOfficers.SingleOrDefaultAsync(policeOfficer => policeOfficer.BadgeNumber == badgeNumber);

    public async Task AddAsync(PoliceOfficer policeOfficer)
    {
        await dbContext.AddAsync(policeOfficer);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var policeOfficer = await GetByGuidAsync(id);

        if (policeOfficer != null)
        {
            dbContext.PoliceOfficers?.Remove(policeOfficer);
        } 
        
        await dbContext.SaveChangesAsync();
    }

    public async Task<PoliceOfficer> UpdateAsync(PoliceOfficer policeOfficer)
    {
        var newPoliceOfficer = dbContext.PoliceOfficers.Update(policeOfficer).Entity;
        await dbContext.SaveChangesAsync();
        return newPoliceOfficer;
    }


}