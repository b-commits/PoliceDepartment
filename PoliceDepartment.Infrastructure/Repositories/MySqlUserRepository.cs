using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.Infrastructure.Repositories;

public class MySqlUserRepository(PoliceDepartmentDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}