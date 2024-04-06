using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Core.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
}