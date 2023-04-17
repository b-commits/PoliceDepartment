using Microsoft.AspNetCore.Identity;
using PoliceDepartment.Application.Security;

namespace PoliceDepartment.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<string> passwordHasher;

    public PasswordManager(IPasswordHasher<string> passwordHasher)
    {
        this.passwordHasher = passwordHasher;
    }
    
    public string Secure(string password)
    {
        var hashedPassword = passwordHasher.HashPassword(default!, password);
        return hashedPassword;
    }

    public bool Validate(string password, string securedPassword)
    {
        return passwordHasher.VerifyHashedPassword(default!, Secure(password), password) ==
               PasswordVerificationResult.Success;
    }
}