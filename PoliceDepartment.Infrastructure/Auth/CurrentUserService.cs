using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Infrastructure.Auth;

internal sealed class CurrentUserService(
    IHttpContextAccessor httpContextAccessor,
    IUserRepository userRepository
    ) : ICurrentUserService
{
    public async Task<User?> GetAsync()
    {
        var email = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        
        return email is not null ? await userRepository.GetUserByEmailAsync(email) : null;
    }
}