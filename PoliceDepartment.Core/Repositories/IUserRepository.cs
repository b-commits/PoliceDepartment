using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Core.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(string email);
}