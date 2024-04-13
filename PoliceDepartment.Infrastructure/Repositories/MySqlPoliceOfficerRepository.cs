using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Repositories;

internal sealed class MySqlPoliceOfficerRepository(
    PoliceDepartmentDbContext dbContext, 
    IConfiguration configuration) : IPoliceOfficerRepository
{
    public async Task<IEnumerable<PoliceOfficer>> GetAllAsync()
    {
        var limit = configuration.GetValue<int>("GetAllApiResultLimit");
        return await dbContext.PoliceOfficers!.Take(limit).ToListAsync();
    } 
    
    public Task<PoliceOfficer?> GetByGuidAsync(Guid id)
        => dbContext.PoliceOfficers!.SingleOrDefaultAsync(policeOfficer => policeOfficer.Id == id);

    public Task<PoliceOfficer?> GetByBadgeNumberAsync(BadgeNumber badgeNumber)
        => dbContext.PoliceOfficers!.SingleOrDefaultAsync(policeOfficer => policeOfficer.BadgeNumber == badgeNumber);

    public async Task AddAsync(PoliceOfficer policeOfficer) 
            => await dbContext.AddAsync(policeOfficer);

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
        var newPoliceOfficer = dbContext.Update(policeOfficer).Entity;
        await dbContext.SaveChangesAsync();
        return newPoliceOfficer;
    }
}