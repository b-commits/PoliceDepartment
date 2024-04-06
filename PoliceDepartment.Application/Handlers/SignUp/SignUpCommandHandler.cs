using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.SignUp;

[UsedImplicitly]
internal sealed class SignUpCommandHandler : IRequestHandler<SignUpCommand>
{
    private readonly IPasswordManager passwordManager;
    private readonly TimeProvider timeProvider;
    private readonly ILogger<SignUpCommandHandler> logger;

    public SignUpCommandHandler(
        TimeProvider timeProvider, 
        ILogger<SignUpCommandHandler> logger, 
        IPasswordManager passwordManager)
    {
        this.timeProvider = timeProvider;
        this.logger = logger;
        this.passwordManager = passwordManager;
    }

    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.Password);

        var user = new User(request.UserId, request.Email, securedPassword, 
            request.Password, request.Role, timeProvider.GetUtcNow().Date);
        
        logger.LogInformation("Created user with email: '{email}'.", request.Email);
    }
}