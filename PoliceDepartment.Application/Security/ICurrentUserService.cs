using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Security;

public interface ICurrentUserService
{
    Task<User?> GetAsync();
}