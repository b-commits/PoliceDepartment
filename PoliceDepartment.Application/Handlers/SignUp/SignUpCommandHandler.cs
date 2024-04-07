using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Enums;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.SignUp;

[UsedImplicitly]
internal sealed class SignUpCommandHandler(
    ILogger<SignUpCommandHandler> logger,
    IUserRepository userRepository,
    IPasswordManager passwordManager)
    : IRequestHandler<SignUpCommand>
{
    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.Password);

        var userExists = await userRepository.GetUserByEmailAsync(request.Email);

        if (userExists is not null)
        {
            logger.LogError("Cannot create a user because email '{email}' is already taken", request.Email);
            throw new Exception();
        }

        var user = new User(Guid.NewGuid(), request.Email, request.Username, securedPassword, UserRole.Reader);

        await userRepository.AddAsync(user);
        
        logger.LogInformation("Created user with email: '{email}'.", request.Email);
    }
}