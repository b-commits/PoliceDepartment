using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.SignUp;

[UsedImplicitly]
internal sealed class SignUpCommandHandler(
    TimeProvider timeProvider,
    ILogger<SignUpCommandHandler> logger,
    IUserRepository userRepository,
    IPasswordManager passwordManager)
    : IRequestHandler<SignUpCommand>
{
    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.Password);

        var user = new User(request.UserId, 
            request.Email, 
            request.Username,
            securedPassword,
            request.Role);

        await userRepository.AddAsync(user);
        
        logger.LogInformation("Created user with email: '{email}'.", request.Email);
    }
}