using Microsoft.EntityFrameworkCore;
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

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        if (dbContext.Users != null) 
            return await dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);

        return null;
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        if (dbContext.Users != null) 
            return await dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);

        return null;
    }
    
    
}