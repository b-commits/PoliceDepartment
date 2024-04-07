using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Infrastructure.Exceptions;

namespace PoliceDepartment.Infrastructure.Auth;

internal sealed class CurrentUserService(
    IHttpContextAccessor httpContextAccessor,
    IUserRepository userRepository
    ) : ICurrentUserService
{
    public async Task<User?> GetAsync()
    {
        if (httpContextAccessor.HttpContext is null)
            throw new InvalidRequestContextException(nameof(CurrentUserService));
        
        var email = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        
        return email is not null ? await userRepository.GetUserByEmailAsync(email) : null;
    }
}